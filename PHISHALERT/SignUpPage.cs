using System;
using System.Drawing;
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
            // Mock authentication - set logged in state and navigate to dashboard
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                mainForm.SetLoggedIn(true);
                mainForm.ShowDashboard();
            }
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            // Navigate to Login page
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                mainForm.ShowLogin();
            }
        }
    }
}
