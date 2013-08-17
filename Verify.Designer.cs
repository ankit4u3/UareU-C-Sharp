namespace UareUWindowsMSSQLCSharp
{
    partial class Verify
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.verifyPicBox = new System.Windows.Forms.PictureBox();
            this.VerifyMessageLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Loadbtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.verifyPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // verifyPicBox
            // 
            this.verifyPicBox.Location = new System.Drawing.Point(48, 95);
            this.verifyPicBox.Name = "verifyPicBox";
            this.verifyPicBox.Size = new System.Drawing.Size(286, 340);
            this.verifyPicBox.TabIndex = 0;
            this.verifyPicBox.TabStop = false;
            // 
            // VerifyMessageLbl
            // 
            this.VerifyMessageLbl.AutoSize = true;
            this.VerifyMessageLbl.Location = new System.Drawing.Point(80, 55);
            this.VerifyMessageLbl.Name = "VerifyMessageLbl";
            this.VerifyMessageLbl.Size = new System.Drawing.Size(0, 13);
            this.VerifyMessageLbl.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Loadbtn
            // 
            this.Loadbtn.Location = new System.Drawing.Point(136, 23);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(75, 23);
            this.Loadbtn.TabIndex = 2;
            this.Loadbtn.Text = "Load Image";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 519);
            this.Controls.Add(this.Loadbtn);
            this.Controls.Add(this.VerifyMessageLbl);
            this.Controls.Add(this.verifyPicBox);
            this.Name = "Verify";
            this.Text = "LoadBMP and Verify";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Verify_FormClosed);
            this.Load += new System.EventHandler(this.Verify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.verifyPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox verifyPicBox;
        private System.Windows.Forms.Label VerifyMessageLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

