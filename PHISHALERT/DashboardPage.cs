using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class DashboardPage : UserControl
    {
        private static readonly Color ScoreHigh = Color.FromArgb(210, 55, 55);
        private static readonly Color ScoreLow = Color.FromArgb(46, 140, 70);

        private readonly FlowLayoutPanel _recentFlow;
        private readonly Panel _recentScrollHost;

        public DashboardPage()
        {
            SuspendLayout();
            BackColor = PhishAlertUi.PageBack;
            Dock = DockStyle.Fill;
            Padding = PhishAlertUi.PagePadding;

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = PhishAlertUi.PageBack
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(BuildHeader(), 0, 0);

            var body = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = PhishAlertUi.PageBack
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            body.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            body.Controls.Add(BuildSummaryCards(), 0, 0);
            body.Controls.Add(BuildRecentScansSection(out _recentScrollHost, out _recentFlow), 0, 1);

            root.Controls.Add(body, 0, 1);

            Controls.Add(root);
            ResumeLayout(true);

            Resize += (_, __) => PhishAlertUi.SyncVerticalFlowToScrollHost(_recentScrollHost, _recentFlow);
            HandleCreated += (_, __) => PhishAlertUi.SyncVerticalFlowToScrollHost(_recentScrollHost, _recentFlow);
        }

        private static Control BuildHeader()
        {
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0, 0, 0, PhishAlertUi.PadMd)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var title = new Label
            {
                Text = "DashBoard",
                Font = PhishAlertUi.FontPageTitle,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 4)
            };
            var subtitle = new Label
            {
                Text = "Monitor phishing threats and email security",
                Font = PhishAlertUi.FontPageSubtitle,
                ForeColor = PhishAlertUi.TextSecondary,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            tlp.Controls.Add(title, 0, 0);
            tlp.Controls.Add(subtitle, 0, 1);
            return tlp;
        }

        private static Control BuildSummaryCards()
        {
            var tlp = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0, 0, 0, PhishAlertUi.PadMd)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 128F));

            tlp.Controls.Add(MakeStatCard("120", "Emails Scanned", PhishAlertUi.TextPrimary), 0, 0);
            tlp.Controls.Add(MakeStatCard("37", "Threats Found", ScoreHigh), 1, 0);
            tlp.Controls.Add(MakeStatCard("83", "Safe Emails", ScoreLow), 2, 0);
            return tlp;
        }

        private static Control MakeStatCard(string number, string caption, Color numberColor)
        {
            var card = new RoundedPanel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(PhishAlertUi.Gap / 2, 0, PhishAlertUi.Gap / 2, 0),
                BackColor = PhishAlertUi.Card,
                CornerRadius = 14,
                Padding = new Padding(PhishAlertUi.PadMd + 2, PhishAlertUi.PadMd + 4, PhishAlertUi.PadMd + 2, PhishAlertUi.PadMd + 2)
            };

            var num = new Label
            {
                Text = number,
                Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                ForeColor = numberColor,
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 44,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            var cap = new Label
            {
                Text = caption,
                Font = PhishAlertUi.FontBody,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = false,
                Dock = DockStyle.Top,
                Height = 28,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            card.Controls.Add(cap);
            card.Controls.Add(num);
            return card;
        }

        private Control BuildRecentScansSection(out Panel scrollHost, out FlowLayoutPanel flow)
        {
            var outer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0, PhishAlertUi.Gap, 0, 0)
            };

            var chrome = new RoundedPanel
            {
                Dock = DockStyle.Fill,
                BackColor = PhishAlertUi.Card,
                CornerRadius = 16,
                Padding = new Padding(0)
            };

            var inner = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            inner.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            inner.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            inner.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var headerHost = new Panel
            {
                Dock = DockStyle.Fill,
                Height = 52,
                BackColor = Color.Transparent
            };
            var headerBar = new DashboardHeaderBarPanel(PhishAlertUi.DashboardListHeaderBar, 12)
            {
                Dock = DockStyle.Fill
            };
            var listTitle = new Label
            {
                Text = "Recent Scans",
                Font = PhishAlertUi.FontSectionTitle,
                ForeColor = PhishAlertUi.DashboardListHeaderText,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(PhishAlertUi.PadMd + 4, 14, PhishAlertUi.PadMd, 10),
                BackColor = Color.Transparent
            };
            headerHost.Controls.Add(headerBar);
            headerHost.Controls.Add(listTitle);

            scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = PhishAlertUi.Card,
                Padding = new Padding(PhishAlertUi.PadMd, PhishAlertUi.PadSm, PhishAlertUi.PadMd, PhishAlertUi.PadMd)
            };

            flow = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                BackColor = PhishAlertUi.Card,
                Padding = new Padding(0)
            };

            var scans = new[]
            {
                Tuple.Create("Urgent: update your account", "2 min ago", "95", "Critical"),
                Tuple.Create("Re: Invoice Payment Required", "5 min ago", "15", "Safe"),
                Tuple.Create("Security Alert: Verify Identity", "8 min ago", "92", "Critical"),
                Tuple.Create("Meeting Tomorrow at 2pm", "15 min ago", "15", "Safe"),
                Tuple.Create("Prize Winner Notification", "30 min ago", "75", "Critical")
            };

            foreach (var s in scans)
                flow.Controls.Add(BuildScanRow(s.Item1, s.Item2, s.Item3, s.Item4));

            scrollHost.Controls.Add(flow);
            inner.Controls.Add(headerHost, 0, 0);
            inner.Controls.Add(scrollHost, 0, 1);
            chrome.Controls.Add(inner);
            outer.Controls.Add(chrome);
            return outer;
        }

        private static Color ScoreColorFromValue(string scoreText)
        {
            int v;
            if (!int.TryParse(scoreText, out v))
                return PhishAlertUi.TextPrimary;
            return v >= 70 ? ScoreHigh : ScoreLow;
        }

        private static Color StatusTextColor(string status)
        {
            return status != null && status.IndexOf("Safe", StringComparison.OrdinalIgnoreCase) >= 0
                ? ScoreLow
                : ScoreHigh;
        }

        private static Panel BuildScanRow(string subject, string time, string score, string status)
        {
            Color scoreHue = ScoreColorFromValue(score);
            Color statusText = StatusTextColor(status);

            var row = new RoundedPanel
            {
                Margin = new Padding(0, 0, 0, PhishAlertUi.Gap),
                BackColor = PhishAlertUi.CardMuted,
                CornerRadius = 12,
                Padding = new Padding(PhishAlertUi.PadMd, PhishAlertUi.PadSm + 4, PhishAlertUi.PadMd, PhishAlertUi.PadSm + 4),
                MinimumSize = new Size(0, 96),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = Color.Transparent
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));

            var stack = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));

            var lblSubject = new Label
            {
                Text = subject,
                Font = PhishAlertUi.FontEmphasis,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent,
                UseCompatibleTextRendering = false
            };
            var lblTime = new Label
            {
                Text = time,
                Font = PhishAlertUi.FontSmall,
                ForeColor = PhishAlertUi.TextSecondary,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent,
                UseCompatibleTextRendering = false
            };
            stack.Controls.Add(lblSubject, 0, 0);
            stack.Controls.Add(lblTime, 0, 1);

            var riskColumn = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = Color.Transparent
            };
            riskColumn.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            riskColumn.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));

            var circleHost = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 2)
            };
            var circle = new Panel
            {
                Size = new Size(44, 44),
                BackColor = Color.White,
                Location = new Point(22, 0)
            };
            ApplyCircularRegion(circle);
            var lblScore = new Label
            {
                Text = score,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = scoreHue,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                UseCompatibleTextRendering = false
            };
            circle.Controls.Add(lblScore);
            circleHost.Resize += (_, __) =>
            {
                circle.Left = System.Math.Max(0, (circleHost.Width - circle.Width) / 2);
            };
            circleHost.Controls.Add(circle);

            var lblRiskCaption = new Label
            {
                Text = "Risk Score",
                Font = PhishAlertUi.FontSmall,
                ForeColor = PhishAlertUi.TextPrimary,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                BackColor = Color.Transparent,
                UseCompatibleTextRendering = false
            };
            riskColumn.Controls.Add(circleHost, 0, 0);
            riskColumn.Controls.Add(lblRiskCaption, 0, 1);

            var statusPill = new RoundedPanel
            {
                Width = 88,
                Height = 32,
                CornerRadius = 16,
                BackColor = Color.White
            };
            var statusLabel = new Label
            {
                Text = status,
                Font = PhishAlertUi.FontBadge,
                ForeColor = statusText,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                UseCompatibleTextRendering = false
            };
            statusPill.Controls.Add(statusLabel);

            var statusHost = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            statusHost.Resize += (_, __) =>
            {
                statusPill.Left = System.Math.Max(0, statusHost.Width - statusPill.Width);
                statusPill.Top = System.Math.Max(0, (statusHost.Height - statusPill.Height) / 2);
            };
            statusHost.Controls.Add(statusPill);

            tlp.Controls.Add(stack, 0, 0);
            tlp.Controls.Add(riskColumn, 1, 0);
            tlp.Controls.Add(statusHost, 2, 0);

            row.Controls.Add(tlp);
            return row;
        }

        private static void ApplyCircularRegion(Panel circle)
        {
            void UpdateRegion(object sender, EventArgs e)
            {
                if (circle.Width < 4 || circle.Height < 4)
                    return;
                using (var path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, circle.Width - 1, circle.Height - 1);
                    circle.Region = new Region(path);
                }
            }
            circle.SizeChanged += UpdateRegion;
            circle.HandleCreated += UpdateRegion;
        }
    }
}
