using System;
using System.Drawing;
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class ScanEmailPage : UserControl
    {
        private readonly SplitContainer _split;

        public ScanEmailPage()
        {
            SuspendLayout();
            BackColor = PhishAlertUi.PageBack;
            Dock = DockStyle.Fill;
            Padding = PhishAlertUi.PagePadding;

            _split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterWidth = 8,
                BackColor = PhishAlertUi.PageBack
            };

            var pnlEmailDetails = BuildEmailDetailsPanel();
            var pnlScanResults = BuildScanResultsPanel();

            pnlEmailDetails.Dock = DockStyle.Fill;
            pnlScanResults.Dock = DockStyle.Fill;
            _split.Panel1.Controls.Add(pnlEmailDetails);
            _split.Panel2.Controls.Add(pnlScanResults);

            Controls.Add(_split);

            HandleCreated += (_, __) =>
            {
                if (IsHandleCreated)
                    BeginInvoke(new Action(ApplySplitterRatio));
            };
            Resize += (_, __) => ApplySplitterRatio();

            ResumeLayout(true);
        }

        private void ApplySplitterRatio()
        {
            if (!_split.IsHandleCreated)
                return;

            int w = _split.ClientSize.Width;
            int sw = _split.SplitterWidth;
            if (w <= sw + 20)
                return;

            const int preferPanel1 = 280;
            const int preferPanel2 = 260;
            int available = w - sw;

            int min1 = preferPanel1;
            int min2 = preferPanel2;
            if (min1 + min2 > available)
            {
                int floor = 60;
                min2 = Math.Max(floor, Math.Min(preferPanel2, available / 2 - 4));
                min1 = Math.Max(floor, available - min2);
                min1 = Math.Max(floor, Math.Min(preferPanel1, min1));
                min2 = Math.Max(floor, Math.Min(preferPanel2, available - min1));
                if (min1 + min2 > available)
                {
                    min1 = Math.Max(floor, available / 2);
                    min2 = available - min1;
                }
            }

            int hi = w - min2 - sw;
            int lo = min1;
            if (hi < lo)
                return;

            try
            {
                _split.Panel1MinSize = 25;
                _split.Panel2MinSize = 25;

                _split.Panel1MinSize = min1;
                _split.Panel2MinSize = min2;

                int target = (int)(w * 0.56);
                int d = Math.Max(lo, Math.Min(target, hi));
                if (d != _split.SplitterDistance)
                    _split.SplitterDistance = d;
            }
            catch (InvalidOperationException)
            {
                try
                {
                    _split.Panel1MinSize = 25;
                    _split.Panel2MinSize = 25;
                    int mid = Math.Max(25, (w - sw) / 2);
                    _split.SplitterDistance = Math.Min(mid, w - sw - 25);
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        private static Panel BuildEmailDetailsPanel()
        {
            var shell = new Panel
            {
                BackColor = PhishAlertUi.Card,
                Padding = PhishAlertUi.CardInnerPadding
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 8,
                BackColor = PhishAlertUi.Card
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));

            var title = new Label
            {
                Text = "Email Details",
                Font = PhishAlertUi.FontSectionTitle,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, PhishAlertUi.PadSm)
            };

            var lblSender = new Label
            {
                Text = "Sender Email",
                Font = PhishAlertUi.FontCaption,
                ForeColor = PhishAlertUi.TextMuted,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            var txtSender = new TextBox
            {
                Font = PhishAlertUi.FontBody,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, PhishAlertUi.Gap)
            };

            var lblSubject = new Label
            {
                Text = "Subject Line",
                Font = PhishAlertUi.FontCaption,
                ForeColor = PhishAlertUi.TextMuted,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            var txtSubject = new TextBox
            {
                Font = PhishAlertUi.FontBody,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, PhishAlertUi.Gap)
            };

            var lblBody = new Label
            {
                Text = "Email Body",
                Font = PhishAlertUi.FontCaption,
                ForeColor = PhishAlertUi.TextMuted,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            var txtBody = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = PhishAlertUi.FontBody,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, PhishAlertUi.Gap),
                MinimumSize = new Size(0, 80)
            };

            var btnScan = new Button
            {
                Text = "Scan Email",
                Font = new Font(PhishAlertUi.FontBody, FontStyle.Bold),
                ForeColor = PhishAlertUi.TextPrimary,
                BackColor = PhishAlertUi.Accent,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Fill,
                Cursor = Cursors.Hand
            };
            btnScan.FlatAppearance.BorderSize = 0;

            layout.Controls.Add(title, 0, 0);
            layout.Controls.Add(lblSender, 0, 1);
            layout.Controls.Add(txtSender, 0, 2);
            layout.Controls.Add(lblSubject, 0, 3);
            layout.Controls.Add(txtSubject, 0, 4);
            layout.Controls.Add(lblBody, 0, 5);
            layout.Controls.Add(txtBody, 0, 6);
            layout.Controls.Add(btnScan, 0, 7);

            shell.Controls.Add(layout);
            return shell;
        }

        private static Panel BuildScanResultsPanel()
        {
            var shell = new Panel
            {
                BackColor = PhishAlertUi.Card,
                Padding = PhishAlertUi.CardInnerPadding
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = PhishAlertUi.Card
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var title = new Label
            {
                Text = "Scan Results",
                Font = PhishAlertUi.FontSectionTitle,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, PhishAlertUi.PadSm)
            };

            var icon = new Label
            {
                Text = "\u2709",
                Font = new Font("Segoe UI Symbol", 32F),
                ForeColor = PhishAlertUi.Sidebar,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var message = new Label
            {
                Text = "Enter email details and click Scan Email.",
                Font = PhishAlertUi.FontBody,
                ForeColor = PhishAlertUi.TextMuted,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                Padding = new Padding(PhishAlertUi.PadSm, PhishAlertUi.PadSm, PhishAlertUi.PadSm, PhishAlertUi.PadSm)
            };

            layout.Controls.Add(title, 0, 0);
            layout.Controls.Add(icon, 0, 1);
            layout.Controls.Add(message, 0, 2);

            shell.Controls.Add(layout);
            return shell;
        }
    }
}
