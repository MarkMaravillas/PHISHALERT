using System;
using System.Drawing;
using System.Windows.Forms;

namespace PHISHALERT
{
    public partial class PatternLibraryPage : UserControl
    {
        private readonly TextBox _txtSearch;
        private readonly FlowLayoutPanel _patternFlow;
        private readonly Panel _scrollHost;
        private readonly FlowLayoutPanel _categoryFlow;

        public PatternLibraryPage()
        {
            SuspendLayout();
            BackColor = PhishAlertUi.PageBack;
            Dock = DockStyle.Fill;
            Padding = PhishAlertUi.PagePadding;

            var root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = PhishAlertUi.PageBack
            };
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(BuildHeader(), 0, 0);
            root.Controls.Add(BuildSearchRow(out _txtSearch), 0, 1);
            root.Controls.Add(BuildCategoryStrip(out _categoryFlow), 0, 2);
            root.Controls.Add(BuildListSection(out _scrollHost, out _patternFlow), 0, 3);

            Controls.Add(root);
            ResumeLayout(true);

            Resize += (_, __) =>
            {
                SyncCategoryStripWidth();
                PhishAlertUi.SyncVerticalFlowToScrollHost(_scrollHost, _patternFlow);
            };
            HandleCreated += (_, __) =>
            {
                SyncCategoryStripWidth();
                PhishAlertUi.SyncVerticalFlowToScrollHost(_scrollHost, _patternFlow);
            };
        }

        private void SyncCategoryStripWidth()
        {
            if (_categoryFlow == null)
                return;
            var parent = _categoryFlow.Parent;
            if (parent != null)
                _categoryFlow.Width = Math.Max(100, parent.ClientSize.Width - parent.Padding.Horizontal);
            int w = _categoryFlow.ClientSize.Width - _categoryFlow.Padding.Horizontal;
            if (w < 100)
                return;
            int cols = w >= 720 ? 3 : w >= 440 ? 2 : 1;
            int gap = PhishAlertUi.Gap;
            int usable = w - gap * Math.Max(0, cols - 1);
            int cw = usable / cols;
            cw = Math.Max(160, cw);
            foreach (Control c in _categoryFlow.Controls)
                c.Width = cw;
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
                Padding = new Padding(0, 0, 0, PhishAlertUi.PadSm)
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            var lblTitle = new Label
            {
                Text = "Pattern Library",
                Font = PhishAlertUi.FontPageTitle,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 4)
            };
            var lblSub = new Label
            {
                Text = "Manage and analyze phishing patterns",
                Font = PhishAlertUi.FontPageSubtitle,
                ForeColor = PhishAlertUi.TextSecondary,
                AutoSize = true,
                Dock = DockStyle.Fill
            };
            
            tlp.Controls.Add(lblTitle, 0, 0);
            tlp.Controls.Add(lblSub, 0, 1);
            return tlp;
        }

        private static Control BuildSearchRow(out TextBox txtSearch)
        {
            var row = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0, 0, 0, PhishAlertUi.PadSm)
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            row.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

            var lblSearch = new Label
            {
                Text = "Search",
                Font = new Font(PhishAlertUi.FontCaption, FontStyle.Bold),
                ForeColor = PhishAlertUi.TextPrimary,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                UseCompatibleTextRendering = false
            };

            txtSearch = new TextBox
            {
                Font = PhishAlertUi.FontBody,
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 4, 0, 0),
                MinimumSize = new Size(0, 28)
            };

            row.Controls.Add(lblSearch, 0, 0);
            row.Controls.Add(txtSearch, 1, 0);
            
            var btnAddPattern = new Button
            {
                Text = "+ Add",
                Font = PhishAlertUi.FontSmall,
                BackColor = PhishAlertUi.Accent,
                ForeColor = PhishAlertUi.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                AutoSize = true,
                Margin = new Padding(PhishAlertUi.PadSm, 0, 0, 0)
            };
            btnAddPattern.Click += (s, e) => MessageBox.Show("Add Custom Pattern feature coming soon!");
            
            row.Controls.Add(btnAddPattern, 2, 0);
            return row;
        }

        private static Control BuildCategoryStrip(out FlowLayoutPanel categoryFlow)
        {
            var wrap = new Panel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0, 0, 0, PhishAlertUi.PadMd)
            };

            categoryFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = PhishAlertUi.PageBack,
                Padding = new Padding(0)
            };

            categoryFlow.Controls.Add(MakeCategoryCard("Common Patterns", "High-signal rules shared across tenants."));
            categoryFlow.Controls.Add(MakeCategoryCard("Recent Patterns", "Newly observed lures from the last 7 days."));
            categoryFlow.Controls.Add(MakeCategoryCard("Custom Patterns", "Org-specific keywords and sender rules."));

            wrap.Controls.Add(categoryFlow);
            return wrap;
        }

        private static Panel MakeCategoryCard(string title, string blurb)
        {
            var outer = new Panel
            {
                Margin = new Padding(PhishAlertUi.Gap / 2, 0, PhishAlertUi.Gap / 2, PhishAlertUi.Gap),
                BackColor = PhishAlertUi.PageBack,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            var inner = new Panel
            {
                Dock = DockStyle.Top,
                BackColor = PhishAlertUi.Card,
                Padding = PhishAlertUi.CardInnerPadding,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                MinimumSize = new Size(160, 72)
            };
            var lblTitle = new Label
            {
                Text = title,
                Font = PhishAlertUi.FontCardTitle,
                ForeColor = PhishAlertUi.TextPrimary,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(360, 0)
            };
            var lblBlurb = new Label
            {
                Text = blurb,
                Font = PhishAlertUi.FontSmall,
                ForeColor = PhishAlertUi.TextMuted,
                Dock = DockStyle.Top,
                AutoSize = true,
                MaximumSize = new Size(360, 0),
                Padding = new Padding(0, PhishAlertUi.PadSm / 2, 0, 0)
            };
            inner.Controls.Add(lblTitle);
            inner.Controls.Add(lblBlurb);
            outer.Controls.Add(inner);
            return outer;
        }

        private static Control BuildListSection(out Panel scrollHost, out FlowLayoutPanel patternFlow)
        {
            var outer = new Panel { Dock = DockStyle.Fill, BackColor = PhishAlertUi.PageBack };

            var shell = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = PhishAlertUi.RecentHeader,
                Padding = new Padding(0)
            };
            shell.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            shell.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var listTitle = new Label
            {
                Text = "Available Patterns",
                Font = PhishAlertUi.FontListSectionTitle,
                ForeColor = PhishAlertUi.TextOnDark,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(PhishAlertUi.PadMd, PhishAlertUi.PadMd, PhishAlertUi.PadMd, PhishAlertUi.PadSm),
                Padding = new Padding(0)
            };

            scrollHost = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = PhishAlertUi.RecentHeader,
                Padding = new Padding(PhishAlertUi.PadMd, 0, PhishAlertUi.PadMd, PhishAlertUi.PadMd)
            };

            patternFlow = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Top,
                BackColor = PhishAlertUi.RecentHeader,
                Padding = new Padding(0)
            };

            var patterns = new[]
            {
                Tuple.Create("Urgent Account Verification", "Account Takeover", "245 matches", "Active", Color.FromArgb(50, 150, 50)),
                Tuple.Create("Fake Shipping Notification", "Delivery Scam", "189 matches", "Active", Color.FromArgb(50, 150, 50)),
                Tuple.Create("CEO Wire Transfer Request", "BEC", "132 matches", "Active", Color.FromArgb(50, 150, 50)),
                Tuple.Create("Password Expiry Notice", "Credential Harvest", "98 matches", "Active", Color.FromArgb(50, 150, 50))
            };
            foreach (var p in patterns)
                patternFlow.Controls.Add(BuildPatternRow(p.Item1, p.Item2, p.Item3, p.Item4, p.Item5));

            scrollHost.Controls.Add(patternFlow);
            shell.Controls.Add(listTitle, 0, 0);
            shell.Controls.Add(scrollHost, 0, 1);
            outer.Controls.Add(shell);
            return outer;
        }

        private static Panel BuildPatternRow(string name, string type, string matches, string status, Color statusColor)
        {
            Color statusText = statusColor.G >= statusColor.R
                ? Color.FromArgb(38, 110, 58)
                : Color.FromArgb(190, 48, 48);

            var row = new Panel
            {
                Margin = new Padding(0, 0, 0, PhishAlertUi.Gap),
                BackColor = PhishAlertUi.CardMuted,
                Padding = new Padding(PhishAlertUi.PadMd, PhishAlertUi.PadSm + 2, PhishAlertUi.PadMd, PhishAlertUi.PadSm + 2),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            var tlp = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                ColumnCount = 3,
                RowCount = 1,
                BackColor = PhishAlertUi.CardMuted
            };
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));

            var stack = new TableLayoutPanel
            {
                AutoSize = true,
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                BackColor = PhishAlertUi.CardMuted
            };
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            stack.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));

            var lblName = new Label
            {
                Text = name,
                Font = PhishAlertUi.FontEmphasis,
                ForeColor = PhishAlertUi.TextPrimary,
                AutoEllipsis = true,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                UseCompatibleTextRendering = false
            };
            var lblType = new Label
            {
                Text = type,
                Font = PhishAlertUi.FontSmall,
                ForeColor = PhishAlertUi.TextMuted,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                UseCompatibleTextRendering = false
            };
            stack.Controls.Add(lblName, 0, 0);
            stack.Controls.Add(lblType, 0, 1);

            var lblMatches = new Label
            {
                Text = matches,
                Font = PhishAlertUi.FontBody,
                ForeColor = PhishAlertUi.TextMuted,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                UseCompatibleTextRendering = false
            };

            var statusHost = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = PhishAlertUi.CardMuted
            };
            var statusPill = new RoundedPanel
            {
                Width = 78,
                Height = 30,
                CornerRadius = 14,
                BackColor = Color.White
            };
            var lblStatus = new Label
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
            statusPill.Controls.Add(lblStatus);
            statusHost.Resize += (_, __) =>
            {
                statusPill.Left = System.Math.Max(0, (statusHost.Width - statusPill.Width) / 2);
                statusPill.Top = System.Math.Max(0, (statusHost.Height - statusPill.Height) / 2);
            };
            statusHost.Controls.Add(statusPill);

            tlp.Controls.Add(stack, 0, 0);
            tlp.Controls.Add(lblMatches, 1, 0);
            tlp.Controls.Add(statusHost, 2, 0);

            row.Controls.Add(tlp);
            return row;
        }
    }
}
