namespace UsbKeyTester
{
    partial class TestUsbKeyForm
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
            this.DriveDropDownBox = new System.Windows.Forms.ComboBox();
            this.DriveSelectLbl = new System.Windows.Forms.Label();
            this.RunBtn = new System.Windows.Forms.Button();
            this.CreateFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckFileProgressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // DriveDropDownBox
            // 
            this.DriveDropDownBox.FormattingEnabled = true;
            this.DriveDropDownBox.Location = new System.Drawing.Point(71, 12);
            this.DriveDropDownBox.Name = "DriveDropDownBox";
            this.DriveDropDownBox.Size = new System.Drawing.Size(139, 21);
            this.DriveDropDownBox.TabIndex = 0;
            // 
            // DriveSelectLbl
            // 
            this.DriveSelectLbl.Location = new System.Drawing.Point(-2, 15);
            this.DriveSelectLbl.Name = "DriveSelectLbl";
            this.DriveSelectLbl.Size = new System.Drawing.Size(67, 23);
            this.DriveSelectLbl.TabIndex = 1;
            this.DriveSelectLbl.Text = "Select drive:";
            // 
            // RunBtn
            // 
            this.RunBtn.Location = new System.Drawing.Point(100, 97);
            this.RunBtn.Name = "RunBtn";
            this.RunBtn.Size = new System.Drawing.Size(75, 23);
            this.RunBtn.TabIndex = 2;
            this.RunBtn.Text = "Run";
            this.RunBtn.UseVisualStyleBackColor = true;
            this.RunBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // CreateFileProgressBar
            // 
            this.CreateFileProgressBar.Location = new System.Drawing.Point(71, 39);
            this.CreateFileProgressBar.Name = "CreateFileProgressBar";
            this.CreateFileProgressBar.Size = new System.Drawing.Size(139, 23);
            this.CreateFileProgressBar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Create File";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-2, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Check file";
            // 
            // CheckFileProgressBar
            // 
            this.CheckFileProgressBar.Location = new System.Drawing.Point(71, 68);
            this.CheckFileProgressBar.Name = "CheckFileProgressBar";
            this.CheckFileProgressBar.Size = new System.Drawing.Size(139, 23);
            this.CheckFileProgressBar.TabIndex = 5;
            // 
            // TestUsbKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 129);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CheckFileProgressBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateFileProgressBar);
            this.Controls.Add(this.RunBtn);
            this.Controls.Add(this.DriveSelectLbl);
            this.Controls.Add(this.DriveDropDownBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestUsbKeyForm";
            this.Text = "Test Usb Key Form";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar CheckFileProgressBar;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar CreateFileProgressBar;

        private System.Windows.Forms.Button RunBtn;

        private System.Windows.Forms.Label DriveSelectLbl;

        #endregion

        private System.Windows.Forms.ComboBox DriveDropDownBox;
    }
}