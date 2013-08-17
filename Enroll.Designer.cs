namespace UareUWindowsMSSQLCSharp
{
    partial class Enroll
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
            this.userIDlbl = new System.Windows.Forms.Label();
            this.userIDTb = new System.Windows.Forms.TextBox();
            this.messagelbl = new System.Windows.Forms.Label();
            this.enrollPicBox = new System.Windows.Forms.PictureBox();
            this.sacwebmp = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // userIDlbl
            // 
            this.userIDlbl.AutoSize = true;
            this.userIDlbl.Location = new System.Drawing.Point(65, 378);
            this.userIDlbl.Name = "userIDlbl";
            this.userIDlbl.Size = new System.Drawing.Size(102, 13);
            this.userIDlbl.TabIndex = 0;
            this.userIDlbl.Text = "Please enter UserID";
            this.userIDlbl.Visible = false;
            // 
            // userIDTb
            // 
            this.userIDTb.Location = new System.Drawing.Point(206, 371);
            this.userIDTb.Name = "userIDTb";
            this.userIDTb.Size = new System.Drawing.Size(100, 20);
            this.userIDTb.TabIndex = 1;
            this.userIDTb.Visible = false;
            // 
            // messagelbl
            // 
            this.messagelbl.AutoSize = true;
            this.messagelbl.Location = new System.Drawing.Point(102, 9);
            this.messagelbl.Name = "messagelbl";
            this.messagelbl.Size = new System.Drawing.Size(99, 13);
            this.messagelbl.TabIndex = 3;
            this.messagelbl.Text = "Please Scan Finger";
            // 
            // enrollPicBox
            // 
            this.enrollPicBox.Location = new System.Drawing.Point(32, 104);
            this.enrollPicBox.Name = "enrollPicBox";
            this.enrollPicBox.Size = new System.Drawing.Size(260, 247);
            this.enrollPicBox.TabIndex = 4;
            this.enrollPicBox.TabStop = false;
            // 
            // sacwebmp
            // 
            this.sacwebmp.Location = new System.Drawing.Point(115, 41);
            this.sacwebmp.Name = "sacwebmp";
            this.sacwebmp.Size = new System.Drawing.Size(75, 23);
            this.sacwebmp.TabIndex = 5;
            this.sacwebmp.Text = "Save BMP";
            this.sacwebmp.UseVisualStyleBackColor = true;
            this.sacwebmp.Click += new System.EventHandler(this.sacwebmp_Click);
            // 
            // Enroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 390);
            this.Controls.Add(this.sacwebmp);
            this.Controls.Add(this.enrollPicBox);
            this.Controls.Add(this.messagelbl);
            this.Controls.Add(this.userIDTb);
            this.Controls.Add(this.userIDlbl);
            this.Name = "Enroll";
            this.Text = "Enroll";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Enroll_FormClosed);
            this.Load += new System.EventHandler(this.Enroll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enrollPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userIDlbl;
        private System.Windows.Forms.TextBox userIDTb;
        private System.Windows.Forms.Label messagelbl;
        private System.Windows.Forms.PictureBox enrollPicBox;
        private System.Windows.Forms.Button sacwebmp;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}