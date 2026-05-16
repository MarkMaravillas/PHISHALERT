using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class OtpVerificationForm : Form
    {
        private string validOTP;
        private DateTime expiryTime;
        private string userEmail;

        public bool IsVerified { get; private set; } = false;

        public OtpVerificationForm(string otp, DateTime expiry, string email = "")
        {
            InitializeComponent();

            this.validOTP = otp;
            this.expiryTime = expiry;
            this.userEmail = email;

            StartCountdownTimer();
        }

        private void StartCountdownTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) =>
            {
                if (DateTime.Now > expiryTime)
                {
                    timer.Stop();
                    MessageBox.Show("Your verification token has expired. Please try signing up again.", "Expired OTP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            };
            timer.Start();
        }

        public void btnVerify_Click(object sender, EventArgs e)
        {
            if (DateTime.Now > expiryTime)
            {
                MessageBox.Show("This code has expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (txtOtp.Text.Trim() == validOTP)
            {
                IsVerified = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect code. Please double-check your email and try again.", "Validation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOtp.Clear();
                txtOtp.Focus();
            }
        }

        public void btnResend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Email address not available. Unable to resend OTP.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate a new OTP
            this.validOTP = GenerateOTP();

            // expiration time
            this.expiryTime = DateTime.Now.AddMinutes(5);

            // Send new otp
            if (SendOTPEmail(userEmail, this.validOTP))
            {
                // clear the input field
                txtOtp.Clear();
                txtOtp.Focus();
                MessageBox.Show("A new OTP has been sent to your email. Please check your inbox.", "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to resend OTP. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private bool SendOTPEmail(string email, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage();


                mail.From = new MailAddress("phishalert.otp.test@gmail.com", "PhishAlert Security");
                mail.To.Add(email);
                mail.Subject = "PhishAlert OTP Verification (Resend)";

                mail.IsBodyHtml = true;
                mail.Body = $@"
                    <div style='font-family: Arial, sans-serif; padding: 20px; border: 1px solid #ddd; max-width: 500px;'>
                        <h2 style='color: #654321;'>PhishAlert Verification</h2>
                        <p>Use the following code to complete your registration:</p>
                        <div style='font-size: 24px; font-weight: bold; background-color: #f5ebe4; padding: 10px; text-align: center; margin: 20px 0;'>
                            {otp}
                        </div>
                        <p style='color: #888; font-size: 12px;'>This code expires in 5 minutes.</p>
                    </div>";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;

                // email and 16 character app password for the test email account
                smtp.Credentials = new NetworkCredential("phishalert.otp.test@gmail.com", "rcetlqnmdwyjxtmn");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email failed to send: " + ex.Message, "SMTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void txtOtp_TextChanged(object sender, EventArgs e)
        {

        }

        private void OtpVerificationForm_Load(object sender, EventArgs e)
        {

        }
    }
}