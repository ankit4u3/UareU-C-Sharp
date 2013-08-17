using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPUruNet;
using System.Threading;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Enroll : Form
    {
        private Reader reader;
        private bool reset = false;
        private int fingerindex;//indexfinger
        private int count;
        private List<Fmd> preEnrollmentFmd;
        private DataResult<Fmd> enrollmentFmd, fmd1, fmd2;
        public Form_Main _sender;
        

        public Enroll()
        {
            InitializeComponent();          
        }
        private void InitializeReaders()
        {
            ReaderCollection rc = ReaderCollection.GetReaders();
            if (rc.Count == 0)
            {
                //UpdateEnrollMessage("Fingerprint Reader not found. Please check if reader is plugged in and try again", null);
                MessageBox.Show("Fingerprint Reader not found. Please check if reader is plugged in and try again");
            }
            else
            {
                reader = rc[0];
                Constants.ResultCode readersResult = reader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
            }
        }
       private void Enroll_Load(object sender, EventArgs e)
        {
           InitializeReaders();
            try
            {               
                Constants.ResultCode result = reader.GetStatus();
                if (result == Constants.ResultCode.DP_SUCCESS)
                {
                    StartEnrollment(result);
                }
                else
                    MessageBox.Show("Reader status is:" + result);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void StartEnrollment(Constants.ResultCode readerResult)
        {
            fingerindex = 0;
            preEnrollmentFmd = new List<Fmd>();           

            CheckReaderStatus();

            if (readerResult == Constants.ResultCode.DP_SUCCESS)
            {
                reader.On_Captured += new Reader.CaptureCallback(reader_On_Captured);
                EnrollmentCapture();
            }
            else
            {
                messagelbl.Text = "Could not perform capture. Reader result code :" + readerResult.ToString();
            }
        
        }

        private void EnrollmentCapture()
        {
            count =0;
            Constants.ResultCode captureResult = reader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, reader.Capabilities.Resolutions[0]);
            if (captureResult != Constants.ResultCode.DP_SUCCESS)
            { 
             MessageBox.Show("CaptureResult: " + captureResult.ToString());
            }
        }

        void reader_On_Captured(CaptureResult capResult)
        {
            if (capResult.Quality == Constants.CaptureQuality.DP_QUALITY_GOOD)
            {
                count++;
                DataResult<Fmd> fmd = FeatureExtraction.CreateFmdFromFid(capResult.Data, Constants.Formats.Fmd.DP_PRE_REGISTRATION);
            
                // Get view bytes to create bitmap.
                foreach (Fid.Fiv fiv in capResult.Data.Views)
                {
                    //Ask user to press finger to get fingerprint
                    UpdateEnrollMessage("Click save button to save fingerprint", HelperFunctions.CreateBitmap(fiv.RawImage, fiv.Width, fiv.Height));
                    break;
                }
            
                //preEnrollmentFmd.Add(fmd.Data);
                //enrollmentFmd = DPUruNet.Enrollment.CreateEnrollmentFmd(Constants.Formats.Fmd.DP_REGISTRATION, preEnrollmentFmd);
            
                ////if (enrollmentFmd.ResultCode == Constants.ResultCode.DP_SUCCESS)
                //{
                //    if (fingerindex == 0)
                //    {
                //        fmd1 = enrollmentFmd;
                //        fingerindex++;
                //        count = 0;
                //        preEnrollmentFmd.Clear();
                //        UpdateEnrollMessage("Please swipe 2nd finger", null);
                //    }
                //    else if (fingerindex == 1)
                //    {
                //        fmd2 = enrollmentFmd;
                //        preEnrollmentFmd.Clear();
                //        UpdateEnrollMessage("User " + userIDTb.Text.ToString() + " Successfully Enrolled!", null);
                //        string userid = userIDTb.Text.ToString();
                //        HelperFunctions.updateFMDUserIDList(fmd1.Data, fmd2.Data, userid);
                       
                //        if (!CheckIfUserExists())
                //        {
                //            SaveEnrolledFmd(userIDTb.Text.ToString(), Fmd.SerializeXml(fmd1.Data), Fmd.SerializeXml(fmd2.Data));
                //        }

                //    }

               // }
              
            }

        }


        private bool CheckIfUserExists()
        {
            bool userExists = false;
            string query = "select * from Users where UserID = '" + userIDTb.Text.ToString() + "'";
            SqlDataReader dataReader = HelperFunctions.ConnectDBnExecuteSelectScript(query);
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            if (dt.Rows.Count != 0)
            {
                userExists = true;
            }
            else
            {
                userExists = false;
            }
            return userExists;
            dataReader.Close();

        }
        
        public void SaveEnrolledFmd(string userName, string xmlFMD1, string xmlFMD2)
        {
            string saveFmdScript = "Insert into Users values ('" + userName + "', '" + xmlFMD1 + "', '" + xmlFMD2 + "' )";
            // Save user and his relative FMD into database
            HelperFunctions.ConnectDBnExecuteScript(saveFmdScript);
        }


        delegate void UpdateEnrollMessageCallback(string text1, Bitmap image);
        private void UpdateEnrollMessage(string text, Bitmap image)
        {
            if (this.messagelbl.InvokeRequired)
            {
                UpdateEnrollMessageCallback callBack = new UpdateEnrollMessageCallback(UpdateEnrollMessage);
                this.Invoke(callBack, new object[] { text, image });
            }
            else
            {
                messagelbl.Text = text;
                if (image != null)
                {
                    enrollPicBox.Image = image;
                    enrollPicBox.Refresh();
                }
            }

        }

        public void CancelCaptureAndCloseReader()
        {
            if (reader != null)
            {
                reader.CancelCapture();
                reader.Dispose();
            }
        }

        public void CheckReaderStatus()
        {
            //If reader is busy, sleep
            if (reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY)
            {
                Thread.Sleep(50);
            }
            else if ((reader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                reader.Calibrate();
            }
            else if ((reader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + reader.Status.Status);
            }
        }

        private void Enroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            CancelCaptureAndCloseReader();
        }

        private void sacwebmp_Click(object sender, EventArgs e)
        {
            if (enrollPicBox.Image != null)
            {
                saveFileDialog1.Filter = "Bitmap Files (*.bmp)|*.bmp";
                saveFileDialog1.Title = "Save fingerprint as";
                string filename = (saveFileDialog1.ShowDialog() == DialogResult.Cancel) ? "" : saveFileDialog1.FileName;

                if (filename != "")
                    enrollPicBox.Image.Save(filename, ImageFormat.Bmp);
            }
        }
  
      
    }
}
