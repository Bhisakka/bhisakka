using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>Shared GDI+ helpers for LMaterial controls: rounded shapes, shadows, state layers, text.</summary>
    public static class LMaterialDrawing
    {
        public static GraphicsPath RoundedRect(RectangleF r, float radius)
        {
            return RoundedRect(r, radius, radius, radius, radius);
        }

        public static GraphicsPath RoundedRect(RectangleF r, float tl, float tr, float br, float bl)
        {
            var path = new GraphicsPath();
            if (r.Width <= 0 || r.Height <= 0) { path.AddRectangle(new RectangleF(r.X, r.Y, Math.Max(1, r.Width), Math.Max(1, r.Height))); return path; }
            float max = Math.Min(r.Width, r.Height) / 2f;
            tl = Clamp(tl, 0, max); tr = Clamp(tr, 0, max); br = Clamp(br, 0, max); bl = Clamp(bl, 0, max);
            if (tl <= 0 && tr <= 0 && br <= 0 && bl <= 0) { path.AddRectangle(r); return path; }

            path.StartFigure();
            if (tl > 0) path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90); else path.AddLine(r.X, r.Y, r.X, r.Y);
            if (tr > 0) path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90); else path.AddLine(r.Right, r.Y, r.Right, r.Y);
            if (br > 0) path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90); else path.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
            if (bl > 0) path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90); else path.AddLine(r.X, r.Bottom, r.X, r.Bottom);
            path.CloseFigure();
            return path;
        }

        private static float Clamp(float v, float min, float max)
        {
            return v < min ? min : (v > max ? max : v);
        }

        public static void FillRounded(Graphics g, Color color, RectangleF r, float radius)
        {
            if (color.A == 0) return;
            using (var path = RoundedRect(r, radius))
            using (var b = new SolidBrush(color))
                g.FillPath(b, path);
        }

        public static void StrokeRounded(Graphics g, Color color, float width, RectangleF r, float radius)
        {
            if (color.A == 0 || width <= 0) return;
            var inset = new RectangleF(r.X + width / 2f, r.Y + width / 2f, r.Width - width, r.Height - width);
            using (var path = RoundedRect(inset, Math.Max(0, radius - width / 2f)))
            using (var p = new Pen(color, width))
                g.DrawPath(p, path);
        }

        /// <summary>Draws a soft drop shadow under a rounded rect (cheap layered approximation of M3 elevation).</summary>
        public static void PaintShadow(Graphics g, RectangleF r, float radius, int elevation)
        {
            if (elevation <= 0) return;
            int layers = elevation * 2 + 2;
            Color shadow = LMaterialTheme.Scheme.Shadow;
            for (int i = layers; i >= 1; i--)
            {
                float spread = i * 0.75f;
                int alpha = (int)(26f / layers * (layers - i + 1) / 2f) + 2;
                var rr = new RectangleF(r.X - spread / 2f, r.Y - spread / 2f + elevation * 0.8f, r.Width + spread, r.Height + spread);
                using (var path = RoundedRect(rr, radius + spread / 2f))
                using (var b = new SolidBrush(Color.FromArgb(alpha, shadow)))
                    g.FillPath(b, path);
            }
        }

        /// <summary>Fills an M3 state layer (hover/focus/press) clipped to a shape.</summary>
        public static void PaintStateLayer(Graphics g, GraphicsPath shape, Color contentColor, float opacity)
        {
            if (opacity <= 0f) return;
            using (var b = new SolidBrush(LMaterialTheme.Alpha(contentColor, opacity)))
                g.FillPath(b, shape);
        }

        public static void ApplyQuality(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        }

        public static void DrawText(Graphics g, string text, Font font, Color color, Rectangle bounds, ContentAlignment align)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis;
            switch (align)
            {
                case ContentAlignment.TopLeft: flags |= TextFormatFlags.Left | TextFormatFlags.Top; break;
                case ContentAlignment.TopCenter: flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.Top; break;
                case ContentAlignment.TopRight: flags |= TextFormatFlags.Right | TextFormatFlags.Top; break;
                case ContentAlignment.MiddleLeft: flags |= TextFormatFlags.Left | TextFormatFlags.VerticalCenter; break;
                case ContentAlignment.MiddleCenter: flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter; break;
                case ContentAlignment.MiddleRight: flags |= TextFormatFlags.Right | TextFormatFlags.VerticalCenter; break;
                case ContentAlignment.BottomLeft: flags |= TextFormatFlags.Left | TextFormatFlags.Bottom; break;
                case ContentAlignment.BottomCenter: flags |= TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom; break;
                default: flags |= TextFormatFlags.Right | TextFormatFlags.Bottom; break;
            }
            TextRenderer.DrawText(g, text, font, bounds, color, flags);
        }

        public static Size MeasureText(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
        }

        /// <summary>Draws an M3 check mark inside the given square bounds.</summary>
        public static void DrawCheckMark(Graphics g, Rectangle box, Color color, float width)
        {
            using (var pen = new Pen(color, width))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;
                float x = box.X, y = box.Y, w = box.Width, h = box.Height;
                var p1 = new PointF(x + w * 0.22f, y + h * 0.53f);
                var p2 = new PointF(x + w * 0.42f, y + h * 0.72f);
                var p3 = new PointF(x + w * 0.78f, y + h * 0.30f);
                g.DrawLines(pen, new[] { p1, p2, p3 });
            }
        }

        /// <summary>Draws a chevron (expand arrow). Direction: 0=down, 1=up, 2=right, 3=left.</summary>
        public static void DrawChevron(Graphics g, Rectangle box, Color color, int direction)
        {
            using (var pen = new Pen(color, 1.6f))
            {
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                float cx = box.X + box.Width / 2f, cy = box.Y + box.Height / 2f;
                float s = Math.Min(box.Width, box.Height) * 0.28f;
                PointF a, b, c;
                switch (direction)
                {
                    case 1: a = new PointF(cx - s, cy + s / 2); b = new PointF(cx, cy - s / 2); c = new PointF(cx + s, cy + s / 2); break;
                    case 2: a = new PointF(cx - s / 2, cy - s); b = new PointF(cx + s / 2, cy); c = new PointF(cx - s / 2, cy + s); break;
                    case 3: a = new PointF(cx + s / 2, cy - s); b = new PointF(cx - s / 2, cy); c = new PointF(cx + s / 2, cy + s); break;
                    default: a = new PointF(cx - s, cy - s / 2); b = new PointF(cx, cy + s / 2); c = new PointF(cx + s, cy - s / 2); break;
                }
                g.DrawLines(pen, new[] { a, b, c });
            }
        }
    }
}
