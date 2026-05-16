using System;
using System.Drawing;
using System.Net;        // fNetworkCredential
using System.Net.Mail;   // for MailMessage and SmtpClient
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class SignUpPage : UserControl
    {
        private TextBox txtUsername;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private Button btnSignUp;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private Label lblLogin;
        private Panel pnlSignUpContainer;
        private Panel pnlForm;
        private string generatedOTP;
        private DateTime otpExpiry;

        public SignUpPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Main container
            this.pnlSignUpContainer = new Panel
            {
                BackColor = Color.FromArgb(245, 235, 220),
                Dock = DockStyle.Fill,
                Padding = new Padding(50)
            };

            // Form panel
            this.pnlForm = new Panel
            {
                BackColor = Color.FromArgb(255, 255, 255),
                Width = 400,
                Height = 600,
                AutoSize = false,
                Anchor = AnchorStyles.None
            };

            // Title
            this.lblTitle = new Label
            {
                Text = "PhishAlert",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 67, 33),
                AutoSize = true,
                Location = new Point(50, 30)
            };

            // Subtitle
            this.lblSubtitle = new Label
            {
                Text = "Create Your Account",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(50, 75)
            };

            // Username label
            this.lblUsername = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(50, 125)
            };

            // Username textbox
            this.txtUsername = new TextBox
            {
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Width = 300,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 150)
            };

            // Email label
            this.lblEmail = new Label
            {
                Text = "Email",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(50, 205)
            };

            // Email textbox
            this.txtEmail = new TextBox
            {
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Width = 300,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 230)
            };

            // Password label
            this.lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(50, 285)
            };

            // Password textbox
            this.txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Width = 300,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 310),
                UseSystemPasswordChar = true
            };

            // Confirm Password label
            this.lblConfirmPassword = new Label
            {
                Text = "Confirm Password",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(50, 365)
            };

            // Confirm Password textbox
            this.txtConfirmPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Width = 300,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 390),
                UseSystemPasswordChar = true
            };

            // Sign Up button
            this.btnSignUp = new Button
            {
                Text = "Sign Up",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(218, 165, 32),
                ForeColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Width = 300,
                Height = 45,
                Location = new Point(50, 455),
                Cursor = Cursors.Hand
            };
            this.btnSignUp.Click += new EventHandler(this.btnSignUp_Click);

            // Login link
            this.lblLogin = new Label
            {
                Text = "Already have an account? Log In",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 130, 180),
                AutoSize = true,
                Location = new Point(50, 515),
                Cursor = Cursors.Hand
            };
            this.lblLogin.Click += new EventHandler(this.lblLogin_Click);

            // Add controls to form panel
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.lblSubtitle);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblEmail);
            this.pnlForm.Controls.Add(this.txtEmail);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.lblConfirmPassword);
            this.pnlForm.Controls.Add(this.txtConfirmPassword);
            this.pnlForm.Controls.Add(this.btnSignUp);
            this.pnlForm.Controls.Add(this.lblLogin);

            // Center form panel
            this.pnlSignUpContainer.Controls.Add(this.pnlForm);

            // Add main container to user control
            this.Controls.Add(this.pnlSignUpContainer);

            // Center form on resize
            this.Resize += (sender, e) => CenterForm();

            this.Name = "SignUpPage";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }

        private void CenterForm()
        {
            if (pnlForm != null && pnlSignUpContainer != null)
            {
                int x = (pnlSignUpContainer.Width - pnlForm.Width) / 2;
                int y = (pnlSignUpContainer.Height - pnlForm.Height) / 2;
                pnlForm.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Validate all fields are filled
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter an email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm your password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            // Validate that passwords match
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match. Please re-enter your password and confirmation.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtConfirmPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // 1. Generate the unique 6-digit code
            generatedOTP = GenerateOTP();

            // 2. Set an expiration window of exactly 5 minutes from right now
            otpExpiry = DateTime.Now.AddMinutes(5);

            // 3. Send the code directly to the email typed in your text box
            SendOTPEmail(txtEmail.Text, generatedOTP);

            // 4. Open your new verification popup window modally (pass email for resend functionality)
            using (OtpVerificationForm otpForm = new OtpVerificationForm(generatedOTP, otpExpiry, txtEmail.Text))
            {
                otpForm.ShowDialog();

                // 5. Check if they successfully matched the code inside the form
                if (otpForm.IsVerified)
                {
                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Navigate to the main application dashboard
                    var mainForm = this.FindForm() as Form1;
                    if (mainForm != null)
                    {
                        mainForm.SetLoggedIn(true);
                        mainForm.ShowDashboard();
                    }
                }
                else
                {
                    MessageBox.Show("Registration incomplete. You must verify your email address to continue.", "Verification Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                mainForm.ShowLogin();
            }
        }


        private string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }

        private void SendOTPEmail(string email, string otp)
        {
            try
            {
                MailMessage mail = new MailMessage();

                // email test account
                mail.From = new MailAddress("phishalert.otp.test@gmail.com", "PhishAlert Security");
                mail.To.Add(email);
                mail.Subject = "PhishAlert OTP Verification";

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

                // email and 16 character google app password
                smtp.Credentials = new NetworkCredential("phishalert.otp.test@gmail.com", "rcetlqnmdwyjxtmn");
                smtp.EnableSsl = true;

                smtp.Send(mail);
                MessageBox.Show("OTP code has been sent successfully!", "Email Dispatched", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email failed to send: " + ex.Message, "SMTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}