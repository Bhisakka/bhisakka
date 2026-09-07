using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>M3 surface roles a container can take.</summary>
    public enum LMaterialSurfaceRole
    {
        Surface, SurfaceDim, SurfaceBright,
        SurfaceContainerLowest, SurfaceContainerLow, SurfaceContainer,
        SurfaceContainerHigh, SurfaceContainerHighest,
        PrimaryContainer, SecondaryContainer, TertiaryContainer, ErrorContainer
    }

    internal static class LMaterialSurfaceRoles
    {
        public static Color Container(LMaterialSurfaceRole role)
        {
            var s = LMaterialTheme.Scheme;
            switch (role)
            {
                case LMaterialSurfaceRole.SurfaceDim: return s.SurfaceDim;
                case LMaterialSurfaceRole.SurfaceBright: return s.SurfaceBright;
                case LMaterialSurfaceRole.SurfaceContainerLowest: return s.SurfaceContainerLowest;
                case LMaterialSurfaceRole.SurfaceContainerLow: return s.SurfaceContainerLow;
                case LMaterialSurfaceRole.SurfaceContainer: return s.SurfaceContainer;
                case LMaterialSurfaceRole.SurfaceContainerHigh: return s.SurfaceContainerHigh;
                case LMaterialSurfaceRole.SurfaceContainerHighest: return s.SurfaceContainerHighest;
                case LMaterialSurfaceRole.PrimaryContainer: return s.PrimaryContainer;
                case LMaterialSurfaceRole.SecondaryContainer: return s.SecondaryContainer;
                case LMaterialSurfaceRole.TertiaryContainer: return s.TertiaryContainer;
                case LMaterialSurfaceRole.ErrorContainer: return s.ErrorContainer;
                default: return s.Surface;
            }
        }

        public static Color Content(LMaterialSurfaceRole role)
        {
            var s = LMaterialTheme.Scheme;
            switch (role)
            {
                case LMaterialSurfaceRole.PrimaryContainer: return s.OnPrimaryContainer;
                case LMaterialSurfaceRole.SecondaryContainer: return s.OnSecondaryContainer;
                case LMaterialSurfaceRole.TertiaryContainer: return s.OnTertiaryContainer;
                case LMaterialSurfaceRole.ErrorContainer: return s.OnErrorContainer;
                default: return s.OnSurface;
            }
        }
    }

    /// <summary>Material 3 surface panel with a surface role and optional rounded corners.</summary>
    public class LMaterialPanel : Panel
    {
        private LMaterialSurfaceRole _role = LMaterialSurfaceRole.Surface;
        private int _cornerRadius = LMaterialTheme.ShapeNone;

        public LMaterialPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        [Category("LMaterial"), DefaultValue(LMaterialSurfaceRole.Surface)]
        public LMaterialSurfaceRole SurfaceRole
        {
            get { return _role; }
            set { _role = value; ApplyTheme(); Invalidate(); }
        }

        [Category("LMaterial"), DefaultValue(LMaterialTheme.ShapeNone)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected virtual void ApplyTheme()
        {
            BackColor = LMaterialSurfaceRoles.Container(_role);
            ForeColor = LMaterialSurfaceRoles.Content(_role);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;
            if (_cornerRadius == 0)
            {
                using (var b = new SolidBrush(BackColor)) g.FillRectangle(b, ClientRectangle);
                return;
            }
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);
            float radius = LMaterialTheme.ResolveRadius(_cornerRadius, Height);
            LMaterialDrawing.FillRounded(g, BackColor, new RectangleF(0, 0, Width, Height), radius);
        }
    }

    public enum LMaterialCardVariant { Elevated, Filled, Outlined }

    /// <summary>Material 3 card (Elevated / Filled / Outlined, ShapeMedium corners).</summary>
    public class LMaterialCard : Panel
    {
        private LMaterialCardVariant _variant = LMaterialCardVariant.Elevated;

        public LMaterialCard()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            Padding = new Padding(16);
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        [Category("LMaterial"), DefaultValue(LMaterialCardVariant.Elevated)]
        public LMaterialCardVariant Variant
        {
            get { return _variant; }
            set { _variant = value; ApplyTheme(); Invalidate(); }
        }

        protected override Size DefaultSize { get { return new Size(240, 160); } }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            switch (_variant)
            {
                case LMaterialCardVariant.Filled: BackColor = s.SurfaceContainerHighest; break;
                case LMaterialCardVariant.Outlined: BackColor = s.Surface; break;
                default: BackColor = s.SurfaceContainerLow; break;
            }
            ForeColor = s.OnSurface;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            var rect = new RectangleF(3, 2, Width - 6, Height - 7);
            float radius = LMaterialTheme.ShapeMedium;

            if (_variant == LMaterialCardVariant.Elevated)
                LMaterialDrawing.PaintShadow(g, rect, radius, 1);
            LMaterialDrawing.FillRounded(g, BackColor, rect, radius);
            if (_variant == LMaterialCardVariant.Outlined)
                LMaterialDrawing.StrokeRounded(g, s.OutlineVariant, 1f, rect, radius);
        }
    }

    /// <summary>Material 3 group box: rounded outline-variant frame with a title-small primary label.</summary>
    public class LMaterialGroupBox : GroupBox
    {
        public LMaterialGroupBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            LMaterialTheme.Register(this, delegate
            {
                Font = LMaterialTypography.Get(LMaterialTypeRole.TitleSmall);
                ForeColor = LMaterialTheme.Scheme.Primary;
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            Size ts = LMaterialDrawing.MeasureText(Text, Font);
            int top = ts.Height / 2;
            var frame = new RectangleF(0.5f, top + 0.5f, Width - 1f, Height - top - 1f);
            LMaterialDrawing.StrokeRounded(g, s.OutlineVariant, 1f, frame, LMaterialTheme.ShapeMedium);

            if (!string.IsNullOrEmpty(Text))
            {
                using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                    g.FillRectangle(b, 14, 0, ts.Width + 8, ts.Height);
                LMaterialDrawing.DrawText(g, Text, Font, ForeColor,
                    new Rectangle(18, 0, ts.Width + 4, ts.Height), ContentAlignment.MiddleLeft);
            }
        }
    }

    /// <summary>FlowLayoutPanel bound to the LMaterial surface color.</summary>
    public class LMaterialFlowLayoutPanel : FlowLayoutPanel
    {
        public LMaterialFlowLayoutPanel()
        {
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, delegate
            {
                BackColor = LMaterialTheme.Scheme.Surface;
                ForeColor = LMaterialTheme.Scheme.OnSurface;
            });
        }
    }

    /// <summary>TableLayoutPanel bound to the LMaterial surface color.</summary>
    public class LMaterialTableLayoutPanel : TableLayoutPanel
    {
        public LMaterialTableLayoutPanel()
        {
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, delegate
            {
                BackColor = LMaterialTheme.Scheme.Surface;
                ForeColor = LMaterialTheme.Scheme.OnSurface;
            });
        }
    }

    /// <summary>SplitContainer whose splitter is drawn as an M3 divider with a drag handle.</summary>
    public class LMaterialSplitContainer : SplitContainer
    {
        public LMaterialSplitContainer()
        {
            DoubleBuffered = true;
            SplitterWidth = 9;
            LMaterialScrollBars.Attach(Panel1);
            LMaterialScrollBars.Attach(Panel2);
            LMaterialTheme.Register(this, delegate
            {
                var s = LMaterialTheme.Scheme;
                BackColor = s.Surface;
                Panel1.BackColor = s.Surface;
                Panel2.BackColor = s.Surface;
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            LMaterialDrawing.ApplyQuality(g);
            var s = LMaterialTheme.Scheme;
            var r = SplitterRectangle;
            if (r.Width <= 0 || r.Height <= 0) return;

            using (var p = new Pen(s.OutlineVariant, 1f))
            {
                if (Orientation == Orientation.Vertical)
                    g.DrawLine(p, r.X + r.Width / 2f, r.Y, r.X + r.Width / 2f, r.Bottom);
                else
                    g.DrawLine(p, r.X, r.Y + r.Height / 2f, r.Right, r.Y + r.Height / 2f);
            }
            // drag handle
            var handle = Orientation == Orientation.Vertical
                ? new RectangleF(r.X + r.Width / 2f - 2f, r.Y + r.Height / 2f - 16f, 4f, 32f)
                : new RectangleF(r.X + r.Width / 2f - 16f, r.Y + r.Height / 2f - 2f, 32f, 4f);
            LMaterialDrawing.FillRounded(g, s.Outline, handle, 2f);
        }
    }

    /// <summary>PictureBox clipped to an M3 rounded shape.</summary>
    public class LMaterialPictureBox : PictureBox
    {
        private int _cornerRadius = LMaterialTheme.ShapeLarge;

        public LMaterialPictureBox()
        {
            LMaterialTheme.Register(this, delegate { BackColor = LMaterialTheme.Scheme.SurfaceContainer; });
        }

        [Category("LMaterial"), DefaultValue(LMaterialTheme.ShapeLarge)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            var g = pe.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);
            float radius = LMaterialTheme.ResolveRadius(_cornerRadius, Height);
            using (var path = LMaterialDrawing.RoundedRect(new RectangleF(0, 0, Width, Height), radius))
            {
                LMaterialDrawing.FillRounded(g, BackColor, new RectangleF(0, 0, Width, Height), radius);
                var old = g.Clip;
                g.SetClip(path);
                base.OnPaint(pe);
                g.Clip = old;
            }
        }
    }

    /// <summary>Material 3 divider (1px outline-variant rule).</summary>
    public class LMaterialDivider : Control
    {
        private Orientation _orientation = Orientation.Horizontal;

        public LMaterialDivider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabStop = false;
            LMaterialTheme.Register(this, delegate { });
        }

        protected override Size DefaultSize { get { return new Size(160, 1); } }

        [Category("LMaterial"), DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return _orientation; }
            set { _orientation = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            using (var p = new Pen(LMaterialTheme.Scheme.OutlineVariant, 1f))
            {
                if (_orientation == Orientation.Horizontal)
                    g.DrawLine(p, 0, Height / 2f, Width, Height / 2f);
                else
                    g.DrawLine(p, Width / 2f, 0, Width / 2f, Height);
            }
        }
    }
}
