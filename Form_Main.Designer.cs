namespace UareUWindowsMSSQLCSharp
{
    partial class Form_Main
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
            this.enrollbtn = new System.Windows.Forms.Button();
            this.verifybtn = new System.Windows.Forms.Button();
            this.readerNotFoundlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // enrollbtn
            // 
            this.enrollbtn.Location = new System.Drawing.Point(145, 33);
            this.enrollbtn.Name = "enrollbtn";
            this.enrollbtn.Size = new System.Drawing.Size(164, 23);
            this.enrollbtn.TabIndex = 0;
            this.enrollbtn.Text = "Capture fingerprint and Save";
            this.enrollbtn.UseVisualStyleBackColor = true;
            this.enrollbtn.Click += new System.EventHandler(this.enrollbtn_Click);
            // 
            // verifybtn
            // 
            this.verifybtn.Location = new System.Drawing.Point(189, 79);
            this.verifybtn.Name = "verifybtn";
            this.verifybtn.Size = new System.Drawing.Size(75, 23);
            this.verifybtn.TabIndex = 1;
            this.verifybtn.Text = "Verify";
            this.verifybtn.UseVisualStyleBackColor = true;
            this.verifybtn.Click += new System.EventHandler(this.verifybtn_Click);
            // 
            // readerNotFoundlbl
            // 
            this.readerNotFoundlbl.AutoSize = true;
            this.readerNotFoundlbl.Location = new System.Drawing.Point(122, 146);
            this.readerNotFoundlbl.Name = "readerNotFoundlbl";
            this.readerNotFoundlbl.Size = new System.Drawing.Size(240, 13);
            this.readerNotFoundlbl.TabIndex = 3;
            this.readerNotFoundlbl.Text = "Reader is not connected. Please connect reader.";
            this.readerNotFoundlbl.Visible = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 168);
            this.Controls.Add(this.readerNotFoundlbl);
            this.Controls.Add(this.verifybtn);
            this.Controls.Add(this.enrollbtn);
            this.Name = "Form_Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button enrollbtn;
        private System.Windows.Forms.Button verifybtn;
        private System.Windows.Forms.Label readerNotFoundlbl;
    }
}

