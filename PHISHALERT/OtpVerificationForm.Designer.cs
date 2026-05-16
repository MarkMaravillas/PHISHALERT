namespace PHISHALERT
{
    partial class OtpVerificationForm
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
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.btnResend = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOtp
            // 
            this.txtOtp.Location = new System.Drawing.Point(316, 142);
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(100, 26);
            this.txtOtp.TabIndex = 0;
            // 
            // btnResend
            // 
            this.btnResend.Location = new System.Drawing.Point(235, 174);
            this.btnResend.Name = "btnResend";
            this.btnResend.Size = new System.Drawing.Size(75, 28);
            this.btnResend.TabIndex = 1;
            this.btnResend.Text = "Resend";
            this.btnResend.UseVisualStyleBackColor = true;
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(417, 174);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 28);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            // 
            // OtpVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnResend);
            this.Controls.Add(this.txtOtp);
            this.Name = "OtpVerificationForm";
            this.Text = "OtpVerificationForm";
            this.Load += new System.EventHandler(this.OtpVerificationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.Button btnResend;
        private System.Windows.Forms.Button btnVerify;
    }
}