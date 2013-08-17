using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DPUruNet;

namespace UareUWindowsMSSQLCSharp
{
    public partial class Form_Main : Form
    {
        private Reader reader;

        public Reader GetReader
        {
            get
            {
                return reader;
            }
        
        }
        public Form_Main()
        {
            InitializeComponent();
            CheckReaderPluggedin();
     
            //Load all users from database to use in identify function. This data being
            //considerably large we would want to load this once at the statrtup of 
            //application
           // HelperFunctions.LoadAllUsers();
        }
   
        private void CheckReaderPluggedin()
        {
            ReaderCollection rc = ReaderCollection.GetReaders();
            //If reader count is zero, inform user
            if (rc.Count == 0)
            {
                readerNotFoundlbl.Visible = true;
            }
        }

        private void enrollbtn_Click(object sender, EventArgs e)
        {
            // Launch EnrollForm
            Enroll enrollForm = new Enroll();
            enrollForm._sender = this;
            enrollForm.ShowDialog();
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            //Launch VerifyForm
            Verify verify = new Verify();
            verify._sender = this;
            verify.ShowDialog();
        }

       


    }
}
