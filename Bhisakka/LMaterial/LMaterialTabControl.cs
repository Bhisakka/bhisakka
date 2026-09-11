using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Material 3 primary tabs: text labels on the surface with a rounded
    /// primary indicator under the active tab and a hairline divider.
    /// The native chrome is repainted after every WM_PAINT.
    /// </summary>
    public class LMaterialTabControl : TabControl
    {
        private const int WM_PAINT = 0x000F;
        private int _hoverIndex = -1;

        public LMaterialTabControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SizeMode = TabSizeMode.Normal;
            ItemSize = new Size(0, 44);
            Padding = new Point(20, 3);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            Font = LMaterialTypography.Get(LMaterialTypeRole.LabelLarge);
            foreach (TabPage page in TabPages)
            {
                page.BackColor = s.Surface;
                page.ForeColor = s.OnSurface;
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            var page = e.Control as TabPage;
            if (page != null)
            {
                page.BackColor = LMaterialTheme.Scheme.Surface;
                page.ForeColor = LMaterialTheme.Scheme.OnSurface;
                page.UseVisualStyleBackColor = false;
                LMaterialScrollBars.Attach(page);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int idx = -1;
            for (int i = 0; i < TabCount; i++)
                if (GetTabRect(i).Contains(e.Location)) { idx = i; break; }
            if (idx != _hoverIndex) { _hoverIndex = idx; Invalidate(); }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverIndex != -1) { _hoverIndex = -1; Invalidate(); }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && IsHandleCreated && !DesignMode)
            {
                using (var g = Graphics.FromHwnd(Handle))
                    PaintChrome(g);
            }
        }

        private void PaintChrome(Graphics g)
        {
            var s = LMaterialTheme.Scheme;
            var client = ClientRectangle;
            if (client.Width <= 0 || client.Height <= 0) return;

            var display = DisplayRectangle;

            // Cover native header + borders with the surface color.
            var old = g.Clip;
            g.SetClip(display, System.Drawing.Drawing2D.CombineMode.Exclude);
            using (var b = new SolidBrush(s.Surface)) g.FillRectangle(b, client);
            g.Clip = old;

            if (TabCount == 0) return;
            LMaterialDrawing.ApplyQuality(g);

            int headerBottom = GetTabRect(0).Bottom;
            using (var p = new Pen(s.OutlineVariant, 1f))
                g.DrawLine(p, 0, headerBottom - 1, client.Width, headerBottom - 1);

            for (int i = 0; i < TabCount; i++)
            {
                var rect = GetTabRect(i);
                bool selected = i == SelectedIndex;
                Color content = selected ? s.Primary : (i == _hoverIndex ? s.OnSurface : s.OnSurfaceVariant);

                if (i == _hoverIndex && !selected)
                {
                    var hover = new RectangleF(rect.X + 2, rect.Y + 4, rect.Width - 4, rect.Height - 8);
                    LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.HoverOpacity),
                        hover, LMaterialTheme.ShapeSmall);
                }

                LMaterialDrawing.DrawText(g, TabPages[i].Text, Font, content, rect, ContentAlignment.MiddleCenter);

                if (selected)
                {
                    float iw = Math.Max(24, rect.Width - 40);
                    var ind = new RectangleF(rect.X + (rect.Width - iw) / 2f, headerBottom - 4, iw, 3.5f);
                    using (var path = LMaterialDrawing.RoundedRect(ind, 2f, 2f, 0f, 0f))
                    using (var b = new SolidBrush(s.Primary))
                        g.FillPath(b, path);
                }
            }
        }
    }
}
