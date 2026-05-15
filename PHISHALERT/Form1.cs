using System;
using System.Drawing;
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class Form1 : Form
    {
        private readonly DashboardPage dashboardPage;
        private readonly ScanEmailPage scanEmailPage;
        private readonly PatternLibraryPage patternLibraryPage;
        private readonly LoginPage loginPage;
        private readonly SignUpPage signUpPage;
        private Button btnLogout;
        private bool isLoggedIn = false;

        public Form1()
        {
            InitializeComponent();
            dashboardPage = new DashboardPage();
            scanEmailPage = new ScanEmailPage();
            patternLibraryPage = new PatternLibraryPage();
            loginPage = new LoginPage();
            signUpPage = new SignUpPage();
            InitializePages();
            this.Load += Form1_Load;
            this.Resize += (_, __) => LayoutSidebarNavButtons();
            this.btnDashboard.Click += btnDashboard_Click;
            this.btnScanEmail.Click += btnScanEmail_Click;
            this.btnPatterns.Click += btnPatterns_Click;
        }

        private void LayoutSidebarNavButtons()
        {
            int inner = this.pnlSidebar.ClientSize.Width - this.pnlSidebar.Padding.Horizontal;
            inner = System.Math.Max(100, inner);
            int x = this.pnlSidebar.Padding.Left;
            this.btnDashboard.Width = inner;
            this.btnDashboard.Left = x;
            this.btnScanEmail.Width = inner;
            this.btnScanEmail.Left = x;
            this.btnPatterns.Width = inner;
            this.btnPatterns.Left = x;
        }

        private void InitializePages()
        {
            foreach (var page in new Control[] { dashboardPage, scanEmailPage, patternLibraryPage, loginPage, signUpPage })
            {
                page.Dock = DockStyle.Fill;
                page.Visible = false;
                this.pnlMainContent.Controls.Add(page);
            }
            ShowLogin(); // Start with login page
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayoutSidebarNavButtons();
            ResetButtonColors();
            // Initialize as logged out state
            SetLoggedIn(false);
            this.btnDashboard.BackColor = PhishAlertUi.Accent;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                ResetButtonColors();
                this.btnDashboard.BackColor = PhishAlertUi.AccentActive;
                ShowDashboard();
            }
        }

        private void btnScanEmail_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                ResetButtonColors();
                this.btnScanEmail.BackColor = PhishAlertUi.AccentActive;
                ShowScanEmail();
            }
        }

        private void btnPatterns_Click(object sender, EventArgs e)
        {
            if (isLoggedIn)
            {
                ResetButtonColors();
                this.btnPatterns.BackColor = PhishAlertUi.AccentActive;
                ShowPatternLibrary();
            }
        }

        private static void ShowOnly(Control host, Control visible)
        {
            foreach (Control c in host.Controls)
                c.Visible = ReferenceEquals(c, visible);
            visible.BringToFront();
        }

        private void ShowPatternLibrary()
        {
            ShowOnly(this.pnlMainContent, patternLibraryPage);
        }

        public void ShowDashboard()
        {
            ShowOnly(this.pnlMainContent, dashboardPage);
        }

        private void ShowScanEmail()
        {
            ShowOnly(this.pnlMainContent, scanEmailPage);
        }

        public void ShowLogin()
        {
            ShowOnly(this.pnlMainContent, loginPage);
        }

        public void ShowSignUp()
        {
            ShowOnly(this.pnlMainContent, signUpPage);
        }

        private void ResetButtonColors()
        {
            this.btnDashboard.BackColor = PhishAlertUi.Accent;
            this.btnScanEmail.BackColor = PhishAlertUi.Accent;
            this.btnPatterns.BackColor = PhishAlertUi.Accent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Log out user
            isLoggedIn = false;
            ShowLogin();
            HideSidebarNavigation();
        }

        private void HideSidebarNavigation()
        {
            // Hide navigation buttons when logged out
            btnDashboard.Visible = false;
            btnScanEmail.Visible = false;
            btnPatterns.Visible = false;
            btnLogout.Visible = false;
        }

        private void ShowSidebarNavigation()
        {
            // Show navigation buttons when logged in
            btnDashboard.Visible = true;
            btnScanEmail.Visible = true;
            btnPatterns.Visible = true;
            btnLogout.Visible = true;
        }

        public void SetLoggedIn(bool loggedIn)
        {
            isLoggedIn = loggedIn;
            if (loggedIn)
            {
                ShowSidebarNavigation();
            }
            else
            {
                HideSidebarNavigation();
            }
        }
    }
}
