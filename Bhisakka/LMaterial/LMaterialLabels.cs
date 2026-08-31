using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>Named M3 content color roles for text.</summary>
    public enum LMaterialColorRole
    {
        OnSurface, OnSurfaceVariant, Primary, Secondary, Tertiary, Error, Outline,
        OnPrimaryContainer, OnSecondaryContainer, OnTertiaryContainer
    }

    internal static class LMaterialColorRoles
    {
        public static Color Resolve(LMaterialColorRole role)
        {
            var s = LMaterialTheme.Scheme;
            switch (role)
            {
                case LMaterialColorRole.OnSurfaceVariant: return s.OnSurfaceVariant;
                case LMaterialColorRole.Primary: return s.Primary;
                case LMaterialColorRole.Secondary: return s.Secondary;
                case LMaterialColorRole.Tertiary: return s.Tertiary;
                case LMaterialColorRole.Error: return s.Error;
                case LMaterialColorRole.Outline: return s.Outline;
                case LMaterialColorRole.OnPrimaryContainer: return s.OnPrimaryContainer;
                case LMaterialColorRole.OnSecondaryContainer: return s.OnSecondaryContainer;
                case LMaterialColorRole.OnTertiaryContainer: return s.OnTertiaryContainer;
                default: return s.OnSurface;
            }
        }
    }

    /// <summary>Label bound to an M3 type-scale role and content color role.</summary>
    public class LMaterialLabel : Label
    {
        private LMaterialTypeRole _typeRole = LMaterialTypeRole.BodyMedium;
        private LMaterialColorRole _colorRole = LMaterialColorRole.OnSurface;

        public LMaterialLabel()
        {
            BackColor = Color.Transparent;
            LMaterialTheme.Register(this, ApplyTheme);
        }

        [Category("LMaterial"), DefaultValue(LMaterialTypeRole.BodyMedium)]
        public LMaterialTypeRole TypeRole
        {
            get { return _typeRole; }
            set { _typeRole = value; ApplyTheme(); }
        }

        [Category("LMaterial"), DefaultValue(LMaterialColorRole.OnSurface)]
        public LMaterialColorRole ColorRole
        {
            get { return _colorRole; }
            set { _colorRole = value; ApplyTheme(); }
        }

        private void ApplyTheme()
        {
            Font = LMaterialTypography.Get(_typeRole);
            ForeColor = LMaterialColorRoles.Resolve(_colorRole);
        }
    }

    /// <summary>LinkLabel themed with M3 primary/tertiary link colors.</summary>
    public class LMaterialLinkLabel : LinkLabel
    {
        public LMaterialLinkLabel()
        {
            BackColor = Color.Transparent;
            LinkBehavior = LinkBehavior.HoverUnderline;
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
            ForeColor = s.OnSurface;
            LinkColor = s.Primary;
            ActiveLinkColor = LMaterialTheme.Blend(s.Primary, s.OnSurface, 0.3f);
            VisitedLinkColor = s.Tertiary;
            DisabledLinkColor = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
        }
    }

    /// <summary>Material 3 badge: small error-colored pill with a count/label.</summary>
    public class LMaterialBadge : Control
    {
        public LMaterialBadge()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabStop = false;
            LMaterialTheme.Register(this, delegate { Font = LMaterialTypography.Get(LMaterialTypeRole.LabelSmall); });
        }

        protected override Size DefaultSize { get { return new Size(24, 16); } }

        public override Size GetPreferredSize(Size proposedSize)
        {
            if (string.IsNullOrEmpty(Text)) return new Size(8, 8);
            var ts = LMaterialDrawing.MeasureText(Text, Font);
            return new Size(Math.Max(16, ts.Width + 10), 16);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Size = GetPreferredSize(Size.Empty);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            var rect = new RectangleF(0, 0, Width, Height);
            LMaterialDrawing.FillRounded(g, s.Error, rect, Height / 2f);
            if (!string.IsNullOrEmpty(Text))
                LMaterialDrawing.DrawText(g, Text, Font, s.OnError, ClientRectangle, ContentAlignment.MiddleCenter);
        }
    }
}
