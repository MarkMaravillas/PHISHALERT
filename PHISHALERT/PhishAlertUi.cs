using System;
using System.Drawing;
using System.Windows.Forms;

namespace PHISHALERT
{
    /// <summary>Shared colors, spacing, typography, and layout helpers for consistent pages.</summary>
    internal static class PhishAlertUi
    {
        public static readonly Color PageBack = Color.FromArgb(245, 233, 214);
        public static readonly Color Card = Color.FromArgb(209, 178, 140);
        public static readonly Color CardMuted = Color.FromArgb(198, 168, 132);
        public static readonly Color Sidebar = Color.FromArgb(92, 61, 30);
        public static readonly Color Accent = Color.FromArgb(212, 160, 23);
        public static readonly Color AccentActive = Color.FromArgb(180, 130, 70);
        public static readonly Color RecentHeader = Color.FromArgb(180, 140, 100);
        /// <summary>Recent Scans block header bar (mockup dark brown).</summary>
        public static readonly Color DashboardListHeaderBar = Color.FromArgb(78, 52, 34);
        /// <summary>Title text on dashboard list header.</summary>
        public static readonly Color DashboardListHeaderText = Color.FromArgb(232, 214, 190);
        public static readonly Color TextPrimary = Color.FromArgb(50, 50, 50);
        public static readonly Color TextSecondary = Color.FromArgb(100, 100, 100);
        public static readonly Color TextMuted = Color.FromArgb(80, 80, 80);
        public static readonly Color TextOnDark = Color.White;

        public static readonly Font FontPageTitle = new Font("Segoe UI", 22F, FontStyle.Bold);
        public static readonly Font FontPageSubtitle = new Font("Segoe UI", 11F);
        public static readonly Font FontSectionTitle = new Font("Segoe UI", 14F, FontStyle.Bold);
        public static readonly Font FontListSectionTitle = new Font("Segoe UI", 13F, FontStyle.Bold);
        public static readonly Font FontCardTitle = new Font("Segoe UI", 11F, FontStyle.Bold);
        public static readonly Font FontEmphasis = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font FontBody = new Font("Segoe UI", 10F);
        public static readonly Font FontCaption = new Font("Segoe UI", 9.5F);
        public static readonly Font FontSmall = new Font("Segoe UI", 9F);
        public static readonly Font FontBadge = new Font("Segoe UI", 8.5F, FontStyle.Bold);

        public const int SidebarWidth = 260;
        public const int PadLg = 24;
        public const int PadMd = 16;
        public const int PadSm = 12;
        public const int Gap = 10;

        public static Padding PagePadding => new Padding(PadLg);
        public static Padding CardInnerPadding => new Padding(PadMd);

        public static void StyleNavButton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 11F);
            b.ForeColor = TextPrimary;
            b.BackColor = Accent;
            b.Margin = new Padding(PadSm, 4, PadSm, 4);
            b.Height = 44;
        }

        /// <summary>
        /// Sizes a vertical FlowLayoutPanel to the scroll host inner width. Does not set child heights
        /// so auto-sized rows can grow vertically (avoids clipped text).
        /// </summary>
        public static void SyncVerticalFlowToScrollHost(Panel scrollHost, FlowLayoutPanel flow)
        {
            if (scrollHost == null || flow == null)
                return;
            int w = scrollHost.ClientSize.Width - scrollHost.Padding.Horizontal;
            if (scrollHost.AutoScroll && scrollHost.VerticalScroll.Visible)
                w -= SystemInformation.VerticalScrollBarWidth;
            w = Math.Max(160, w);
            flow.Width = w;
            int childW = Math.Max(120, w - flow.Padding.Horizontal);
            foreach (Control c in flow.Controls)
                c.Width = childW;
        }
    }
}
