using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PHISHALERT
{
    /// <summary>Panel with anti-aliased rounded rectangle fill and optional border.</summary>
    internal class RoundedPanel : Panel
    {
        public int CornerRadius { get; set; } = 12;

        public RoundedPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            int r = System.Math.Max(2, System.Math.Min(CornerRadius, System.Math.Min(bounds.Width, bounds.Height) / 2));
            using (var path = CreateRoundedRectangle(bounds, r))
            using (var fill = new SolidBrush(BackColor))
            {
                g.FillPath(fill, path);
            }
        }

        protected override void OnSizeChanged(System.EventArgs e)
        {
            base.OnSizeChanged(e);
            ApplyRegion();
        }

        private void ApplyRegion()
        {
            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            if (bounds.Width <= 1 || bounds.Height <= 1)
            {
                Region = null;
                return;
            }
            int r = System.Math.Max(2, System.Math.Min(CornerRadius, System.Math.Min(bounds.Width, bounds.Height) / 2));
            using (var path = CreateRoundedRectangle(bounds, r))
                Region = new Region(path);
        }

        public static GraphicsPath CreateRoundedRectangle(Rectangle bounds, int radius)
        {
            int d = System.Math.Min(radius * 2, System.Math.Min(bounds.Width, bounds.Height));
            var path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        /// <summary>Flat bottom, rounded top — for section header bars.</summary>
        public static GraphicsPath CreateRoundedTopBar(Rectangle bounds, int radius)
        {
            int r = System.Math.Max(1, System.Math.Min(radius, System.Math.Min(bounds.Width / 2, bounds.Height)));
            int d = r * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.Left, bounds.Top, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Top, d, d, 270, 90);
            path.AddLine(bounds.Right, bounds.Top + r, bounds.Right, bounds.Bottom);
            path.AddLine(bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom);
            path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top + r);
            path.CloseFigure();
            return path;
        }
    }

    /// <summary>Dark header strip with rounded top corners (matches dashboard mockup).</summary>
    internal sealed class DashboardHeaderBarPanel : Panel
    {
        private readonly Color _fill;
        private readonly int _radius;

        public DashboardHeaderBarPanel(Color fill, int radius = 12)
        {
            _fill = fill;
            _radius = radius;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;
            int r = System.Math.Max(4, System.Math.Min(_radius, bounds.Height - 1));
            using (var path = RoundedPanel.CreateRoundedTopBar(bounds, r))
            using (var brush = new SolidBrush(_fill))
                g.FillPath(brush, path);
        }
    }
}
