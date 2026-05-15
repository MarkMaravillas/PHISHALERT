namespace PHISHALERT
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblPhishAlert;
        private System.Windows.Forms.Label lblEmailScanner;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnScanEmail;
        private System.Windows.Forms.Button btnPatterns;
        private System.Windows.Forms.Label lblSignUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSignUp = new System.Windows.Forms.Label();
            this.btnPatterns = new System.Windows.Forms.Button();
            this.btnScanEmail = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblEmailScanner = new System.Windows.Forms.Label();
            this.lblPhishAlert = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(61)))), ((int)(((byte)(30)))));
            this.pnlSidebar.Controls.Add(this.label3);
            this.pnlSidebar.Controls.Add(this.label2);
            this.pnlSidebar.Controls.Add(this.label1);
            this.pnlSidebar.Controls.Add(this.lblSignUp);
            this.pnlSidebar.Controls.Add(this.btnPatterns);
            this.pnlSidebar.Controls.Add(this.btnScanEmail);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblEmailScanner);
            this.pnlSidebar.Controls.Add(this.lblPhishAlert);
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(12, 24, 12, 24);
            this.pnlSidebar.Size = new System.Drawing.Size(260, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 611);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 8;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(15, 626);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 7;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(15, 586);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 6;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblSignUp
            // 
            this.lblSignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSignUp.AutoSize = true;
            this.lblSignUp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSignUp.ForeColor = System.Drawing.Color.White;
            this.lblSignUp.Location = new System.Drawing.Point(15, 571);
            this.lblSignUp.Name = "lblSignUp";
            this.lblSignUp.Size = new System.Drawing.Size(0, 15);
            this.lblSignUp.TabIndex = 5;
            this.lblSignUp.Click += new System.EventHandler(this.lblSignUp_Click);
            // 
            // btnPatterns
            // 
            this.btnPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPatterns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.btnPatterns.FlatAppearance.BorderSize = 0;
            this.btnPatterns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPatterns.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPatterns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnPatterns.Location = new System.Drawing.Point(12, 219);
            this.btnPatterns.Margin = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.btnPatterns.Name = "btnPatterns";
            this.btnPatterns.Size = new System.Drawing.Size(236, 44);
            this.btnPatterns.TabIndex = 4;
            this.btnPatterns.Text = "Pattern Library";
            this.btnPatterns.UseVisualStyleBackColor = false;
            // 
            // btnScanEmail
            // 
            this.btnScanEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.btnScanEmail.FlatAppearance.BorderSize = 0;
            this.btnScanEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScanEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnScanEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnScanEmail.Location = new System.Drawing.Point(12, 164);
            this.btnScanEmail.Margin = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.btnScanEmail.Name = "btnScanEmail";
            this.btnScanEmail.Size = new System.Drawing.Size(236, 44);
            this.btnScanEmail.TabIndex = 3;
            this.btnScanEmail.Text = "Scan Email";
            this.btnScanEmail.UseVisualStyleBackColor = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(160)))), ((int)(((byte)(23)))));
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnDashboard.Location = new System.Drawing.Point(12, 109);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(236, 44);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            // 
            // lblEmailScanner
            // 
            this.lblEmailScanner.AutoSize = true;
            this.lblEmailScanner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblEmailScanner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblEmailScanner.Location = new System.Drawing.Point(12, 65);
            this.lblEmailScanner.Name = "lblEmailScanner";
            this.lblEmailScanner.Size = new System.Drawing.Size(93, 19);
            this.lblEmailScanner.TabIndex = 1;
            this.lblEmailScanner.Text = "Email Scanner";
            // 
            // lblPhishAlert
            // 
            this.lblPhishAlert.AutoSize = true;
            this.lblPhishAlert.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPhishAlert.ForeColor = System.Drawing.Color.White;
            this.lblPhishAlert.Location = new System.Drawing.Point(12, 12);
            this.lblPhishAlert.Name = "lblPhishAlert";
            this.lblPhishAlert.Size = new System.Drawing.Size(132, 32);
            this.lblPhishAlert.TabIndex = 0;
            this.lblPhishAlert.Text = "PhishAlert";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(12, 640);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(12, 4, 12, 4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(236, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(235)))), ((int)(((byte)(220)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(260, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(940, 700);
            this.pnlMainContent.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(960, 620);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhishAlert - Email Scanner";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
