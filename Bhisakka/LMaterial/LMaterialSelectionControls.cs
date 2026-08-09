using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>Material 3 checkbox: 18px rounded box, primary fill when checked, hover halo.</summary>
    public class LMaterialCheckBox : CheckBox
    {
        private bool _hovered;
        private readonly LMaterialAnimator _check;

        public LMaterialCheckBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            _check = new LMaterialAnimator(this, Checked ? 1f : 0f);
            LMaterialTheme.Register(this, delegate { Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge); });
        }

        protected override Size DefaultSize { get { return new Size(140, 36); } }

        protected override void OnCheckedChanged(EventArgs e)
        {
            _check.AnimateTo(Checked ? 1f : 0f, 180);
            base.OnCheckedChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var text = LMaterialDrawing.MeasureText(Text, Font);
            return new Size(36 + 4 + text.Width + 4, Math.Max(36, text.Height + 8));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            int cy = Height / 2;
            var halo = new Rectangle(0, cy - 18, 36, 36);
            var box = new Rectangle(9, cy - 9, 18, 18);
            float t = _check.Value;

            if (Enabled && (_hovered || Focused))
                using (var b = new SolidBrush(LMaterialTheme.Alpha(Checked ? s.Primary : s.OnSurface,
                       Focused && !_hovered ? LMaterialTheme.FocusOpacity : LMaterialTheme.HoverOpacity)))
                    g.FillEllipse(b, halo);

            Color fill, border, mark;
            if (!Enabled)
            {
                border = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                fill = Checked ? border : Color.Transparent;
                mark = s.Surface;
            }
            else
            {
                border = s.OnSurfaceVariant;
                fill = s.Primary;
                mark = s.OnPrimary;
            }

            if (t > 0.01f)
            {
                float grow = 9f * t;
                var fr = new RectangleF(box.X + 9 - grow, box.Y + 9 - grow, grow * 2, grow * 2);
                LMaterialDrawing.FillRounded(g, fill, fr, 2f * t);
                if (t > 0.5f)
                    LMaterialDrawing.DrawCheckMark(g, box, LMaterialTheme.Alpha(mark, (t - 0.5f) * 2f), 2f);
            }
            if (t < 0.99f && !(Checked && !Enabled))
                LMaterialDrawing.StrokeRounded(g, LMaterialTheme.Alpha(border, 1f - t), 2f, box, 2f);

            var tr = new Rectangle(40, 0, Math.Max(0, Width - 44), Height);
            Color textColor = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            LMaterialDrawing.DrawText(g, Text, Font, textColor, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>Material 3 radio button: 20px ring, primary ring + dot when selected.</summary>
    public class LMaterialRadioButton : RadioButton
    {
        private bool _hovered;
        private readonly LMaterialAnimator _check;

        public LMaterialRadioButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            _check = new LMaterialAnimator(this, Checked ? 1f : 0f);
            LMaterialTheme.Register(this, delegate { Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge); });
        }

        protected override Size DefaultSize { get { return new Size(140, 36); } }

        protected override void OnCheckedChanged(EventArgs e)
        {
            _check.AnimateTo(Checked ? 1f : 0f, 180);
            base.OnCheckedChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var text = LMaterialDrawing.MeasureText(Text, Font);
            return new Size(36 + 4 + text.Width + 4, Math.Max(36, text.Height + 8));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            int cy = Height / 2;
            var halo = new Rectangle(0, cy - 18, 36, 36);
            var ring = new RectangleF(9f, cy - 9f, 18f, 18f);
            float t = _check.Value;

            if (Enabled && (_hovered || Focused))
                using (var b = new SolidBrush(LMaterialTheme.Alpha(Checked ? s.Primary : s.OnSurface,
                       Focused && !_hovered ? LMaterialTheme.FocusOpacity : LMaterialTheme.HoverOpacity)))
                    g.FillEllipse(b, halo);

            Color ringColor = !Enabled
                ? LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity)
                : LMaterialTheme.Blend(s.OnSurfaceVariant, s.Primary, t);

            using (var p = new Pen(ringColor, 2f))
                g.DrawEllipse(p, ring);

            if (t > 0.01f)
            {
                float r = 5f * t;
                using (var b = new SolidBrush(ringColor))
                    g.FillEllipse(b, 18f - r, cy - r, r * 2, r * 2);
            }

            var tr = new Rectangle(40, 0, Math.Max(0, Width - 44), Height);
            Color textColor = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            LMaterialDrawing.DrawText(g, Text, Font, textColor, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>
    /// Material 3 switch (52x32 track). Derives from CheckBox so it keeps the
    /// standard Checked/CheckedChanged API and keyboard behavior.
    /// </summary>
    public class LMaterialSwitch : CheckBox
    {
        private bool _hovered, _pressed;
        private readonly LMaterialAnimator _pos;

        public LMaterialSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            _pos = new LMaterialAnimator(this, Checked ? 1f : 0f);
            Cursor = Cursors.Hand;
            LMaterialTheme.Register(this, delegate { Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge); });
        }

        protected override Size DefaultSize { get { return new Size(140, 32); } }

        protected override void OnCheckedChanged(EventArgs e)
        {
            _pos.AnimateTo(Checked ? 1f : 0f, 200);
            base.OnCheckedChanged(e);
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; _pressed = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs mevent) { _pressed = true; Invalidate(); base.OnMouseDown(mevent); }
        protected override void OnMouseUp(MouseEventArgs mevent) { _pressed = false; Invalidate(); base.OnMouseUp(mevent); }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var text = LMaterialDrawing.MeasureText(Text, Font);
            int w = 52 + (string.IsNullOrEmpty(Text) ? 0 : 12 + text.Width);
            return new Size(w + 4, 32);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            float t = _pos.Value;
            int cy = Height / 2;
            var track = new RectangleF(0.5f, cy - 16f, 52f, 32f);

            Color offTrack = s.SurfaceContainerHighest;
            Color onTrack = s.Primary;
            Color trackColor, thumbColor, outline;
            if (!Enabled)
            {
                trackColor = Checked
                    ? LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity)
                    : LMaterialTheme.Layer(s.SurfaceContainerHighest, s.OnSurface, 0.04f);
                thumbColor = Checked ? s.Surface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                outline = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity);
            }
            else
            {
                trackColor = LMaterialTheme.Blend(offTrack, onTrack, t);
                thumbColor = LMaterialTheme.Blend(s.Outline, s.OnPrimary, t);
                outline = s.Outline;
            }

            LMaterialDrawing.FillRounded(g, trackColor, track, 16f);
            if (t < 0.99f)
                LMaterialDrawing.StrokeRounded(g, LMaterialTheme.Alpha(outline, 1f - t), 2f, track, 16f);

            // thumb: 16px off -> 24px on, 28px pressed
            float thumbR = LMaterialTheme.Lerp(8f, 12f, t);
            if (_pressed && Enabled) thumbR = 14f;
            float cx = LMaterialTheme.Lerp(16f, 36f, t);

            if (Enabled && (_hovered || Focused))
                using (var b = new SolidBrush(LMaterialTheme.Alpha(Checked ? s.Primary : s.OnSurface, LMaterialTheme.HoverOpacity)))
                    g.FillEllipse(b, cx - 18f, cy - 18f, 36f, 36f);

            using (var b = new SolidBrush(thumbColor))
                g.FillEllipse(b, cx - thumbR, cy - thumbR, thumbR * 2, thumbR * 2);

            if (Checked && thumbR >= 10f)
            {
                var box = new Rectangle((int)(cx - 6), cy - 6, 12, 12);
                Color mark = Enabled ? s.OnPrimaryContainer : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                LMaterialDrawing.DrawCheckMark(g, box, mark, 1.6f);
            }

            if (!string.IsNullOrEmpty(Text))
            {
                var tr = new Rectangle(64, 0, Math.Max(0, Width - 66), Height);
                Color textColor = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                LMaterialDrawing.DrawText(g, Text, Font, textColor, tr, ContentAlignment.MiddleLeft);
            }
        }
    }
}
