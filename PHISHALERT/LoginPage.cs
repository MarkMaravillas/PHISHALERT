using Microsoft.Data.SqlClient; // Added for SQL Server LocalDB connectivity
using System;
using System.Drawing;
using System.Text.RegularExpressions; // For email validation
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class LoginPage : UserControl
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblSignUp;
        private Panel pnlLoginContainer;
        private Panel pnlForm;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Main container
            this.pnlLoginContainer = new Panel
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
                Height = 500,
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
                Text = "Email Scanner Login",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(50, 75)
            };

            // Username label
            this.lblUsername = new Label
            {
                Text = "Username or Email",
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

            // Password label
            this.lblPassword = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(50, 50, 50),
                AutoSize = true,
                Location = new Point(50, 205)
            };

            // Password textbox
            this.txtPassword = new TextBox
            {
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                Width = 300,
                Height = 40,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(50, 230),
                UseSystemPasswordChar = true
            };

            // Login button
            this.btnLogin = new Button
            {
                Text = "Log In",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(218, 165, 32),
                ForeColor = Color.FromArgb(50, 50, 50),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Width = 300,
                Height = 45,
                Location = new Point(50, 295),
                Cursor = Cursors.Hand
            };
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // Sign up link
            this.lblSignUp = new Label
            {
                Text = "Don't have an account? Sign Up",
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 130, 180),
                AutoSize = true,
                Location = new Point(50, 365),
                Cursor = Cursors.Hand
            };
            this.lblSignUp.Click += new EventHandler(this.lblSignUp_Click);

            // Add controls to form panel
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.lblSubtitle);
            this.pnlForm.Controls.Add(this.lblUsername);
            this.pnlForm.Controls.Add(this.txtUsername);
            this.pnlForm.Controls.Add(this.lblPassword);
            this.pnlForm.Controls.Add(this.txtPassword);
            this.pnlForm.Controls.Add(this.btnLogin);
            this.pnlForm.Controls.Add(this.lblSignUp);

            // Center the form panel
            this.pnlLoginContainer.Controls.Add(this.pnlForm);

            // Add main container to user control
            this.Controls.Add(this.pnlLoginContainer);

            // Center form on resize
            this.Resize += (sender, e) => CenterForm();

            this.Name = "LoginPage";
            this.Size = new Size(1200, 700);
            this.ResumeLayout(false);
        }

        private void CenterForm()
        {
            if (pnlForm != null && pnlLoginContainer != null)
            {
                int x = (pnlLoginContainer.Width - pnlForm.Width) / 2;
                int y = (pnlLoginContainer.Height - pnlForm.Height) / 2;
                pnlForm.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string identifier = txtUsername.Text; // This text box handles username or email inputs
            string enteredPassword = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(identifier) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please enter your credentials.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate if identifier appears to be an email, ensure it's valid format
            if (identifier.Contains("@") && !IsValidEmail(identifier))
            {
                MessageBox.Show("Please enter a valid email address or username.", "Invalid Email Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PhishAlertDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // This query searches both the Username and Email columns for a match
                    string selectQuery = "SELECT PasswordHash FROM Users WHERE Username = @identifier OR Email = @identifier";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@identifier", identifier);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Matching credential found
                            {
                                string storedHash = reader.GetString(0);

                                // Compare the plain-text login attempt against the hashed string
                                if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash))
                                {
                                    MessageBox.Show("Login Successful! Welcome back.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    var mainForm = this.FindForm() as Form1;
                                    if (mainForm != null)
                                    {
                                        mainForm.SetLoggedIn(true);
                                        mainForm.ShowDashboard();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid credentials entered.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else // No matching user profile
                            {
                                MessageBox.Show("Invalid credentials entered.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            // Navigate to Sign Up page
            var mainForm = this.FindForm() as Form1;
            if (mainForm != null)
            {
                mainForm.ShowSignUp();
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                // RFC 5322 simplified email validation regex
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }
    }
}