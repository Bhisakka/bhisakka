using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    public enum LMaterialButtonVariant { Filled, Tonal, Elevated, Outlined, Text }

    /// <summary>
    /// Material 3 Expressive common button. Pill-shaped by default with the
    /// expressive press shape-morph (round -> rounded square), ripple and
    /// state layers. Variants: Filled, Tonal, Elevated, Outlined, Text.
    /// </summary>
    public class LMaterialButton : Button
    {
        private LMaterialButtonVariant _variant = LMaterialButtonVariant.Filled;
        private int _cornerRadius = LMaterialTheme.ShapeFull;
        private bool _hovered;
        private readonly LMaterialAnimator _press;
        private readonly LMaterialRipple _ripple;

        public LMaterialButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            _press = new LMaterialAnimator(this);
            _ripple = new LMaterialRipple(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        [Category("LMaterial"), DefaultValue(LMaterialButtonVariant.Filled)]
        public LMaterialButtonVariant Variant
        {
            get { return _variant; }
            set { _variant = value; Invalidate(); }
        }

        /// <summary>Corner radius in px; LMaterialTheme.ShapeFull (-1) = pill.</summary>
        [Category("LMaterial"), DefaultValue(LMaterialTheme.ShapeFull)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override Size DefaultSize { get { return new Size(140, 40); } }

        private void ApplyTheme()
        {
            Font = LMaterialTypography.Get(LMaterialTypeRole.LabelLarge);
        }

        protected virtual Color ContainerColor(LMaterialColorScheme s)
        {
            switch (_variant)
            {
                case LMaterialButtonVariant.Tonal: return s.SecondaryContainer;
                case LMaterialButtonVariant.Elevated: return s.SurfaceContainerLow;
                case LMaterialButtonVariant.Outlined:
                case LMaterialButtonVariant.Text: return Color.Transparent;
                default: return s.Primary;
            }
        }

        protected virtual Color ContentColor(LMaterialColorScheme s)
        {
            switch (_variant)
            {
                case LMaterialButtonVariant.Tonal: return s.OnSecondaryContainer;
                case LMaterialButtonVariant.Filled: return s.OnPrimary;
                default: return s.Primary;
            }
        }

        protected virtual int Elevation { get { return _variant == LMaterialButtonVariant.Elevated ? 2 : 0; } }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs mevent) { _press.AnimateTo(1f, 150); base.OnMouseDown(mevent); }
        protected override void OnMouseUp(MouseEventArgs mevent) { _press.AnimateTo(0f, 350); base.OnMouseUp(mevent); }
        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            if (kevent.KeyCode == Keys.Space || kevent.KeyCode == Keys.Enter)
            {
                _press.AnimateTo(1f, 150);
                _ripple.StartFromCenter();
            }
            base.OnKeyDown(kevent);
        }
        protected override void OnKeyUp(KeyEventArgs kevent) { _press.AnimateTo(0f, 350); base.OnKeyUp(kevent); }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                pevent.Graphics.FillRectangle(b, ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            OnPaintBackground(e);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            bool enabled = Enabled;
            var rect = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);
            int elevation = Elevation;
            if (elevation > 0 && enabled)
                rect = new RectangleF(2.5f, 1.5f, Width - 5f, Height - 6f);

            // Expressive press morph: pill relaxes toward ShapeMedium while pressed.
            float restRadius = LMaterialTheme.ResolveRadius(_cornerRadius, rect.Height);
            float radius = LMaterialTheme.Lerp(restRadius, Math.Min(restRadius, LMaterialTheme.ShapeMedium), _press.Value);

            Color container = ContainerColor(s);
            Color content = ContentColor(s);
            if (!enabled)
            {
                content = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                container = container.A == 0 ? container : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity);
            }

            if (elevation > 0 && enabled)
                LMaterialDrawing.PaintShadow(g, rect, radius, elevation);

            using (var shape = LMaterialDrawing.RoundedRect(rect, radius))
            {
                if (container.A > 0)
                    using (var b = new SolidBrush(container)) g.FillPath(b, shape);

                if (enabled && _hovered)
                    LMaterialDrawing.PaintStateLayer(g, shape, content, LMaterialTheme.HoverOpacity);
                if (enabled)
                    _ripple.Paint(g, shape, content);

                if (_variant == LMaterialButtonVariant.Outlined)
                {
                    Color border = enabled ? s.Outline : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity);
                    LMaterialDrawing.StrokeRounded(g, border, 1f, rect, radius);
                }

                if (enabled && Focused && ShowFocusCues)
                    LMaterialDrawing.StrokeRounded(g, s.Primary, 2f,
                        new RectangleF(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4), Math.Max(0, radius - 2));
            }

            // content: optional image + text
            var bounds = Rectangle.Round(rect);
            if (Image != null)
            {
                int ih = Math.Min(18, Image.Height);
                int iw = Image.Width * ih / Math.Max(1, Image.Height);
                var textSize = LMaterialDrawing.MeasureText(Text, Font);
                int total = iw + (string.IsNullOrEmpty(Text) ? 0 : 8 + textSize.Width);
                int ix = bounds.X + (bounds.Width - total) / 2;
                int iy = bounds.Y + (bounds.Height - ih) / 2;
                g.DrawImage(Image, new Rectangle(ix, iy, iw, ih));
                if (!string.IsNullOrEmpty(Text))
                {
                    var tr = new Rectangle(ix + iw + 8, bounds.Y, textSize.Width + 2, bounds.Height);
                    LMaterialDrawing.DrawText(g, Text, Font, content, tr, ContentAlignment.MiddleLeft);
                }
            }
            else
            {
                LMaterialDrawing.DrawText(g, Text, Font, content, bounds, ContentAlignment.MiddleCenter);
            }
        }
    }

    /// <summary>Material 3 floating action button (56x56, ShapeLarge, primary container, level-3 shadow).</summary>
    public class LMaterialFloatingActionButton : LMaterialButton
    {
        public LMaterialFloatingActionButton()
        {
            CornerRadius = LMaterialTheme.ShapeLarge;
            Text = "+";
            // FAB glyphs are 24dp; use a larger face than the button label.
            LMaterialTheme.Register(this, delegate { Font = LMaterialTypography.Get(LMaterialTypeRole.HeadlineSmall); });
        }

        protected override Size DefaultSize { get { return new Size(56, 56); } }
        protected override int Elevation { get { return 3; } }
        protected override Color ContainerColor(LMaterialColorScheme s) { return s.PrimaryContainer; }
        protected override Color ContentColor(LMaterialColorScheme s) { return s.OnPrimaryContainer; }
    }

    /// <summary>
    /// Material 3 chip. With <see cref="Checkable"/> it behaves as a filter
    /// chip (toggles, fills with secondary container and shows a check mark),
    /// otherwise as an assist chip.
    /// </summary>
    public class LMaterialChip : Control
    {
        private bool _checkable = true;
        private bool _checked;
        private bool _hovered;
        private readonly LMaterialRipple _ripple;

        public event EventHandler CheckedChanged;

        public LMaterialChip()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            _ripple = new LMaterialRipple(this);
            Cursor = Cursors.Hand;
            AutoSize = true;
            LMaterialTheme.Register(this, delegate
            {
                Font = LMaterialTypography.Get(LMaterialTypeRole.LabelLarge);
                AutoFit();
            });
        }

        protected override Size DefaultSize { get { return new Size(100, 32); } }

        public override Size GetPreferredSize(Size proposedSize)
        {
            int w = 12 + (Checkable && Checked ? 24 : 0) + LMaterialDrawing.MeasureText(Text, Font).Width + 12;
            return new Size(Math.Max(48, w), 32);
        }

        private void AutoFit()
        {
            if (AutoSize) Size = GetPreferredSize(Size.Empty);
        }

        [Category("LMaterial"), DefaultValue(true)]
        public bool Checkable { get { return _checkable; } set { _checkable = value; Invalidate(); } }

        [Category("LMaterial"), DefaultValue(false)]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (_checked == value) return;
                _checked = value;
                var h = CheckedChanged;
                if (h != null) h(this, EventArgs.Empty);
                AutoFit();
                Invalidate();
            }
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnClick(EventArgs e)
        {
            if (_checkable) Checked = !Checked;
            base.OnClick(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AutoFit();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            var rect = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);
            float radius = LMaterialTheme.ShapeSmall;
            bool sel = _checkable && _checked;

            Color content = Enabled
                ? (sel ? s.OnSecondaryContainer : s.OnSurfaceVariant)
                : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);

            using (var shape = LMaterialDrawing.RoundedRect(rect, radius))
            {
                if (sel)
                    using (var b = new SolidBrush(Enabled ? s.SecondaryContainer : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity)))
                        g.FillPath(b, shape);
                else
                    LMaterialDrawing.StrokeRounded(g, Enabled ? s.OutlineVariant : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity), 1f, rect, radius);

                if (Enabled && _hovered) LMaterialDrawing.PaintStateLayer(g, shape, content, LMaterialTheme.HoverOpacity);
                if (Enabled) _ripple.Paint(g, shape, content);
            }

            int x = 12;
            if (sel)
            {
                var box = new Rectangle(x, Height / 2 - 9, 18, 18);
                LMaterialDrawing.DrawCheckMark(g, box, content, 2f);
                x += 24;
            }
            var tr = new Rectangle(x, 0, Width - x - 12, Height);
            LMaterialDrawing.DrawText(g, Text, Font, content, tr, ContentAlignment.MiddleLeft);
        }

    }
}
