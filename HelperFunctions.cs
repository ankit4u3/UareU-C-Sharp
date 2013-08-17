using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using DPUruNet;
using System.Drawing.Imaging;
using System.Drawing;

namespace UareUWindowsMSSQLCSharp
{
    class HelperFunctions
    {
        private static Fmd[] fmd1s;
        private static Fmd[] fmd2s;

        private static Fmd[] allDBFmd1s;
        private static Fmd[] allDBFmd2s;

        public static Fmd[] GetAllFmd1s
        {
            get { return allDBFmd1s; }
            
        }

        public static Fmd[] GetAllFmd2s
        {
            get { return allDBFmd2s; }

        } 
        private static string[] allUserNames;
        public static string[] GetAllUserNames
        {
            get { return allUserNames; }
        }

        private static int[] allfingerIDs;
        public static int[] GetallfingerIDs
        {
            get { return allfingerIDs; }
        }

        public static SqlDataReader ConnectDBnExecuteSelectScript(string Script)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=CustomerInfo; Integrated Security=True; Connect Timeout=0; Trusted_Connection=Yes";
                //"server=localhost;User Id=root;Persist Security Info=True;database=customerInfo;Password=sql";
            SqlDataReader dataReader = null;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(Script, conn);
                dataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error opening connection" + ex.Message);
            }

            return dataReader;
        }

        public static void LoadAllUsers()
        {
            string allUsers = "Select * from users";
            LoadAllFmdsUserIDs(allUsers);
            
        }
        public static void updateFMDUserIDList(Fmd fmd1, Fmd fmd2, String userid)
        {
            Array.Resize(ref allUserNames, (allUserNames.Length) + 1);
            allUserNames[(allUserNames.Length) - 1] = userid;

            Array.Resize(ref allDBFmd1s, (allDBFmd1s.Length) + 1);
            allDBFmd1s[(allDBFmd1s.Length) - 1] = fmd1;

            Array.Resize(ref allDBFmd2s, (allDBFmd2s.Length) + 1);
            allDBFmd2s[(allDBFmd2s.Length) - 1] = fmd2; 
                       
        }

        public static void LoadAllFmdsUserIDs(string SelectQuery)
        {
            SqlDataReader lReader = ConnectDBnExecuteSelectScript(SelectQuery);
            int i = 0;

            // populate all fmds and usernames
            DataTable dt = new DataTable();
            dt.Load(lReader);
            allDBFmd1s = new Fmd[dt.Rows.Count];
            allDBFmd2s = new Fmd[dt.Rows.Count];
            allUserNames = new string[dt.Rows.Count];
           // allfingerIDs = new int[dt.Rows.Count];
            if (dt.Rows.Count != 0)
            {
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    if ((dr["FMD1"].ToString().Length != 0) && (dr["FMD2"].ToString().Length != 0))
                    {
                        allDBFmd1s[i] = Fmd.DeserializeXml(dr["FMD1"].ToString());
                        allDBFmd2s[i] = Fmd.DeserializeXml(dr["FMD2"].ToString());
                        allUserNames[i] = dr["UserID"].ToString().TrimEnd();                       
                        i++;
                    }
                }
            }
            lReader.Close();
          }


        //public static Fmd NumberOfRecordsForUserID(string SelectQuery)
        //{
        //    SqlDataReader lReader = ConnectDBnExecuteSelectScript(SelectQuery);
        //    int i = 0;

        //    // populate fmds and usernames for a given userid
        //    DataTable dt = new DataTable();
        //    dt.Load(lReader);
        //     if (dt.Rows.Count != 0)
        //    {
        //        foreach (System.Data.DataRow dr in dt.Rows)
        //        {
        //            if ((dr["FMD1"].ToString().Length != 0) && (dr["FMD2"].ToString().Length != 0))
        //            {
        //                fmd1s[i] = Fmd.DeserializeXml(dr["FMD1"].ToString());
        //                fmd2s[i] = Fmd.DeserializeXml(dr["FMD1"].ToString());
        //                i++;
        //            }
        //        }
        //    }
        //    lReader.Close();
        //    return fmds;
        //}

        public static void ConnectDBnExecuteScript(string Script)
        {
            string connectionString = "Data Source=localhost; Initial Catalog=CustomerInfo; Integrated Security=True; Connect Timeout=0; Trusted_Connection=Yes";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand sqlCommand = new SqlCommand(Script, conn);
                sqlCommand.ExecuteScalar();

            }
            catch (SqlException ex)
            {
                //If database already has a record for that userid then let customer know that there is a duplicate
                if (ex.Message.Contains("Duplicate"))
                {
                    MessageBox.Show("Userid already exists in Database. Please user another UserID");
                }
                else
                    MessageBox.Show("Error when connecting to Database" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public static Bitmap CreateBitmap(Byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];
            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt32() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }


 
    }
}
