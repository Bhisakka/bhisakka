using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Material 3 Expressive linear progress indicator: rounded primary bar
    /// over a secondary-container track, with the signature track gap and
    /// stop indicator. Supports determinate and indeterminate modes.
    /// </summary>
    public class LMaterialProgressBar : Control
    {
        private int _minimum, _maximum = 100, _value;
        private bool _indeterminate;
        private float _phase;
        private readonly Timer _timer = new Timer { Interval = 16 };

        public LMaterialProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabStop = false;
            _timer.Tick += delegate { _phase = (_phase + 0.012f) % 1f; Invalidate(); };
            Disposed += delegate { _timer.Dispose(); };
            LMaterialTheme.Register(this, delegate { });
        }

        protected override Size DefaultSize { get { return new Size(240, 8); } }

        [Category("LMaterial"), DefaultValue(0)]
        public int Minimum { get { return _minimum; } set { _minimum = Math.Min(value, _maximum); Invalidate(); } }

        [Category("LMaterial"), DefaultValue(100)]
        public int Maximum { get { return _maximum; } set { _maximum = Math.Max(value, _minimum); Invalidate(); } }

        [Category("LMaterial"), DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set { _value = Math.Max(_minimum, Math.Min(_maximum, value)); Invalidate(); }
        }

        [Category("LMaterial"), DefaultValue(false)]
        public bool Indeterminate
        {
            get { return _indeterminate; }
            set { _indeterminate = value; UpdateTimer(); Invalidate(); }
        }

        /// <summary>M3 Expressive wavy style: the active indicator undulates continuously.</summary>
        [Category("LMaterial"), DefaultValue(false)]
        public bool Wavy
        {
            get { return _wavy; }
            set { _wavy = value; UpdateTimer(); Invalidate(); }
        }

        private bool _wavy;

        private void UpdateTimer()
        {
            _timer.Enabled = (_indeterminate || _wavy) && Visible && !DesignMode;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            UpdateTimer();
        }

        private const float Wavelength = 40f;

        private void DrawWave(Graphics g, Color color, float x0, float x1, float cy, float amp, float stroke)
        {
            if (x1 - x0 < 2f) return;
            var pts = new List<PointF>();
            float shift = _phase * Wavelength * 2f;
            for (float x = x0; x < x1; x += 2f)
                pts.Add(new PointF(x, cy + amp * (float)Math.Sin((x - shift) / Wavelength * 2 * Math.PI)));
            pts.Add(new PointF(x1, cy + amp * (float)Math.Sin((x1 - shift) / Wavelength * 2 * Math.PI)));
            using (var p = new Pen(color, stroke) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                g.DrawLines(p, pts.ToArray());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            float w = Width;
            const float gap = 4f;
            float frac = _maximum > _minimum ? (_value - _minimum) / (float)(_maximum - _minimum) : 0f;

            if (_wavy)
            {
                float stroke = Math.Max(3f, Math.Min(4f, Height / 4f));
                float amp = Math.Max(0f, Math.Min(6f, (Height - stroke) / 2f - 1f));
                float cy = Height / 2f;
                float half = stroke / 2f;

                if (_indeterminate)
                {
                    float p0 = (_phase * 1.6f - 0.3f) * w;
                    float p1 = p0 + w * 0.35f;
                    if (p0 - gap > 1f)
                        LMaterialDrawing.FillRounded(g, s.SecondaryContainer,
                            new RectangleF(0, cy - half, Math.Min(p0 - gap, w), stroke), half);
                    DrawWave(g, s.Primary, Math.Max(half, p0), Math.Min(w - half, p1), cy, amp, stroke);
                    if (p1 + gap < w)
                        LMaterialDrawing.FillRounded(g, s.SecondaryContainer,
                            RectangleF.FromLTRB(Math.Max(0, p1 + gap), cy - half, w, cy + half), half);
                    return;
                }

                float fxw = frac * w;
                if (fxw > stroke)
                    DrawWave(g, s.Primary, half, Math.Max(half, fxw - (frac < 1f ? gap : 0f) - half), cy, amp, stroke);
                if (frac < 1f)
                {
                    float tx = Math.Max(fxw + gap, 0);
                    if (w - tx > 1f)
                        LMaterialDrawing.FillRounded(g, s.SecondaryContainer, new RectangleF(tx, cy - half, w - tx, stroke), half);
                    using (var b = new SolidBrush(s.Primary))
                        g.FillEllipse(b, w - half - 2f, cy - 2f, 4f, 4f);
                }
                return;
            }

            float h = Math.Min(Height, 12);
            float y = (Height - h) / 2f;

            if (_indeterminate)
            {
                float p0 = (_phase * 1.6f - 0.3f) * w;
                float p1 = p0 + w * 0.35f;
                if (p0 > gap)
                    LMaterialDrawing.FillRounded(g, s.SecondaryContainer, new RectangleF(0, y, Math.Min(p0 - gap, w), h), h / 2f);
                var seg = RectangleF.FromLTRB(Math.Max(0, p0), y, Math.Min(w, p1), y + h);
                if (seg.Width > 1)
                    LMaterialDrawing.FillRounded(g, s.Primary, seg, h / 2f);
                if (p1 + gap < w)
                    LMaterialDrawing.FillRounded(g, s.SecondaryContainer, RectangleF.FromLTRB(p1 + gap, y, w, y + h), h / 2f);
                return;
            }

            float fx = frac * w;

            if (fx > 1f)
                LMaterialDrawing.FillRounded(g, s.Primary, new RectangleF(0, y, Math.Max(h, fx - (frac < 1f ? gap : 0)), h), h / 2f);
            if (frac < 1f)
            {
                float tx = Math.Max(fx + gap, 0);
                if (w - tx > 1f)
                    LMaterialDrawing.FillRounded(g, s.SecondaryContainer, new RectangleF(tx, y, w - tx, h), h / 2f);
                // stop indicator
                float r = Math.Min(2f, h / 2f);
                using (var b = new SolidBrush(s.Primary))
                    g.FillEllipse(b, w - h / 2f - r, y + h / 2f - r, r * 2, r * 2);
            }
        }
    }

    /// <summary>Material 3 circular progress indicator (determinate or spinning).</summary>
    public class LMaterialCircularProgress : Control
    {
        private int _value;
        private bool _indeterminate = true;
        private float _angle;
        private readonly Timer _timer = new Timer { Interval = 16 };

        public LMaterialCircularProgress()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabStop = false;
            _timer.Tick += delegate { _angle = (_angle + 5f) % 360f; Invalidate(); };
            Disposed += delegate { _timer.Dispose(); };
            LMaterialTheme.Register(this, delegate { });
        }

        protected override Size DefaultSize { get { return new Size(48, 48); } }

        [Category("LMaterial"), DefaultValue(true)]
        public bool Indeterminate
        {
            get { return _indeterminate; }
            set { _indeterminate = value; UpdateTimer(); Invalidate(); }
        }

        [Category("LMaterial"), DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set { _value = Math.Max(0, Math.Min(100, value)); Invalidate(); }
        }

        /// <summary>M3 Expressive wavy style: the active arc undulates continuously.</summary>
        [Category("LMaterial"), DefaultValue(false)]
        public bool Wavy
        {
            get { return _wavy; }
            set { _wavy = value; UpdateTimer(); Invalidate(); }
        }

        private bool _wavy;

        protected override void OnVisibleChanged(EventArgs e) { base.OnVisibleChanged(e); UpdateTimer(); }

        private void UpdateTimer()
        {
            _timer.Enabled = (_indeterminate || _wavy) && Visible && !DesignMode;
        }

        private const int WaveCount = 8;

        private PointF[] WavyArcPoints(RectangleF rect, float startDeg, float sweepDeg, float amp)
        {
            var c = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
            float baseR = rect.Width / 2f;
            double phase = -_angle * Math.PI / 180.0 * 3.0;
            int n = Math.Max(12, (int)(Math.Abs(sweepDeg) / 1.5f));
            var pts = new PointF[n + 1];
            for (int i = 0; i <= n; i++)
            {
                double a = (startDeg + sweepDeg * i / n) * Math.PI / 180.0;
                double r = baseR + amp * Math.Sin(WaveCount * a + phase);
                pts[i] = new PointF(c.X + (float)(r * Math.Cos(a)), c.Y + (float)(r * Math.Sin(a)));
            }
            return pts;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            const float stroke = 4f;
            float amp = _wavy ? Math.Max(1.2f, Math.Min(2.5f, Math.Min(Width, Height) / 26f)) : 0f;
            float d = Math.Min(Width, Height) - stroke - 2 - amp * 2f;
            if (d < 8f) return;
            var rect = new RectangleF((Width - d) / 2f, (Height - d) / 2f, d, d);

            if (_indeterminate)
            {
                float sweep = Math.Max(20f, 90f + 80f * (float)Math.Sin(_angle * Math.PI / 180.0 * 2));
                float start = _angle * 2f % 360f;
                using (var p = new Pen(s.Primary, stroke) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                {
                    if (_wavy) g.DrawLines(p, WavyArcPoints(rect, start, sweep, amp));
                    else g.DrawArc(p, rect, start, sweep);
                }
            }
            else
            {
                using (var p = new Pen(s.SecondaryContainer, stroke) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                    g.DrawArc(p, rect, 0, 360);
                if (_value > 0)
                    using (var p = new Pen(s.Primary, stroke) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                    {
                        float sweep = 360f * _value / 100f;
                        if (_wavy) g.DrawLines(p, WavyArcPoints(rect, -90, sweep, amp));
                        else g.DrawArc(p, rect, -90, sweep);
                    }
            }
        }
    }

    /// <summary>
    /// Material 3 Expressive slider: tall rounded track, narrow handle bar
    /// with track gaps, and end stop indicator. Mouse + keyboard driven.
    /// </summary>
    public class LMaterialSlider : Control
    {
        private int _minimum, _maximum = 100, _value = 50;
        private int _smallChange = 1;
        private bool _dragging, _hovered;

        public event EventHandler ValueChanged;

        public LMaterialSlider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable, true);
            TabStop = true;
            LMaterialTheme.Register(this, delegate { });
        }

        protected override Size DefaultSize { get { return new Size(240, 44); } }

        [Category("LMaterial"), DefaultValue(0)]
        public int Minimum { get { return _minimum; } set { _minimum = Math.Min(value, _maximum); Value = _value; } }

        [Category("LMaterial"), DefaultValue(100)]
        public int Maximum { get { return _maximum; } set { _maximum = Math.Max(value, _minimum); Value = _value; } }

        [Category("LMaterial"), DefaultValue(1)]
        public int SmallChange { get { return _smallChange; } set { _smallChange = Math.Max(1, value); } }

        [Category("LMaterial"), DefaultValue(50)]
        public int Value
        {
            get { return _value; }
            set
            {
                int v = Math.Max(_minimum, Math.Min(_maximum, value));
                if (v == _value) { Invalidate(); return; }
                _value = v;
                var h = ValueChanged;
                if (h != null) h(this, EventArgs.Empty);
                Invalidate();
            }
        }

        private float Fraction
        {
            get { return _maximum > _minimum ? (_value - _minimum) / (float)(_maximum - _minimum) : 0f; }
        }

        private void SetValueFromX(int x)
        {
            const float pad = 10f;
            float frac = LMaterialTheme.Clamp01((x - pad) / Math.Max(1f, Width - pad * 2));
            Value = _minimum + (int)Math.Round(frac * (_maximum - _minimum));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left) return;
            Focus();
            _dragging = true;
            SetValueFromX(e.X);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_dragging) SetValueFromX(e.X);
        }

        protected override void OnMouseUp(MouseEventArgs e) { base.OnMouseUp(e); _dragging = false; Invalidate(); }
        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
        protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left: case Keys.Right: case Keys.Up: case Keys.Down:
                case Keys.Home: case Keys.End: case Keys.PageUp: case Keys.PageDown:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left: case Keys.Down: Value -= _smallChange; break;
                case Keys.Right: case Keys.Up: Value += _smallChange; break;
                case Keys.PageDown: Value -= Math.Max(1, (_maximum - _minimum) / 10); break;
                case Keys.PageUp: Value += Math.Max(1, (_maximum - _minimum) / 10); break;
                case Keys.Home: Value = _minimum; break;
                case Keys.End: Value = _maximum; break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            bool enabled = Enabled;
            const float pad = 10f;
            float trackH = 16f, cy = Height / 2f;
            float fx = pad + Fraction * (Width - pad * 2);
            float gap = 6f;
            float handleW = _dragging ? 3f : 4f, handleH = Math.Min(Height - 2f, 40f);

            Color active = enabled ? s.Primary : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            Color inactive = enabled ? s.SecondaryContainer : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity);

            // active side (left): full-round outer corner, small inner corner
            float aRight = fx - gap - handleW / 2f;
            if (aRight > 2f)
                using (var path = LMaterialDrawing.RoundedRect(new RectangleF(0, cy - trackH / 2f, aRight, trackH), trackH / 2f, 2f, 2f, trackH / 2f))
                using (var b = new SolidBrush(active))
                    g.FillPath(b, path);

            // inactive side (right)
            float iLeft = fx + gap + handleW / 2f;
            if (Width - iLeft > 2f)
                using (var path = LMaterialDrawing.RoundedRect(new RectangleF(iLeft, cy - trackH / 2f, Width - iLeft, trackH), 2f, trackH / 2f, trackH / 2f, 2f))
                using (var b = new SolidBrush(inactive))
                    g.FillPath(b, path);

            // end stop indicator
            using (var b = new SolidBrush(active))
                g.FillEllipse(b, Width - 8f, cy - 2f, 4f, 4f);

            // hover/focus halo behind handle
            if (enabled && (_hovered || Focused || _dragging))
                using (var b = new SolidBrush(LMaterialTheme.Alpha(s.Primary,
                    _dragging ? LMaterialTheme.PressOpacity : LMaterialTheme.HoverOpacity)))
                    g.FillEllipse(b, fx - 20f, cy - 20f, 40f, 40f);

            // handle bar
            LMaterialDrawing.FillRounded(g, active, new RectangleF(fx - handleW / 2f, cy - handleH / 2f, handleW, handleH), handleW / 2f);
        }
    }

    /// <summary>TrackBar-compatible name for the M3 Expressive slider.</summary>
    public class LMaterialTrackBar : LMaterialSlider { }

    /// <summary>Minimal Material 3 scrollbar (rounded thumb, transparent track).</summary>
    public class LMaterialScrollBar : Control
    {
        private Orientation _orientation = Orientation.Vertical;
        private int _minimum, _maximum = 100, _value, _largeChange = 10;
        private bool _dragging, _hovered;
        private float _dragOffset;

        public event EventHandler ValueChanged;

        public LMaterialScrollBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            TabStop = false;
            LMaterialTheme.Register(this, delegate { });
        }

        protected override Size DefaultSize { get { return new Size(12, 160); } }

        [Category("LMaterial"), DefaultValue(Orientation.Vertical)]
        public Orientation Orientation { get { return _orientation; } set { _orientation = value; Invalidate(); } }

        [Category("LMaterial"), DefaultValue(0)]
        public int Minimum { get { return _minimum; } set { _minimum = Math.Min(value, _maximum); Invalidate(); } }

        [Category("LMaterial"), DefaultValue(100)]
        public int Maximum { get { return _maximum; } set { _maximum = Math.Max(value, _minimum); Invalidate(); } }

        [Category("LMaterial"), DefaultValue(10)]
        public int LargeChange { get { return _largeChange; } set { _largeChange = Math.Max(1, value); Invalidate(); } }

        [Category("LMaterial"), DefaultValue(0)]
        public int Value
        {
            get { return _value; }
            set
            {
                int v = Math.Max(_minimum, Math.Min(_maximum, value));
                if (v == _value) return;
                _value = v;
                var h = ValueChanged;
                if (h != null) h(this, EventArgs.Empty);
                Invalidate();
            }
        }

        private int TrackLength { get { return _orientation == Orientation.Vertical ? Height : Width; } }

        private float ThumbLength
        {
            get
            {
                float range = _maximum - _minimum + _largeChange;
                return Math.Max(24f, TrackLength * _largeChange / Math.Max(1f, range));
            }
        }

        private float ThumbStart
        {
            get
            {
                float range = Math.Max(1, _maximum - _minimum);
                return (_value - _minimum) / range * (TrackLength - ThumbLength);
            }
        }

        private RectangleF ThumbRect
        {
            get
            {
                return _orientation == Orientation.Vertical
                    ? new RectangleF(Width / 2f - 4f, ThumbStart, 8f, ThumbLength)
                    : new RectangleF(ThumbStart, Height / 2f - 4f, ThumbLength, 8f);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            float pos = _orientation == Orientation.Vertical ? e.Y : e.X;
            if (ThumbRect.Contains(e.Location))
            {
                _dragging = true;
                _dragOffset = pos - ThumbStart;
            }
            else
            {
                Value += pos < ThumbStart ? -_largeChange : _largeChange;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!_dragging) return;
            float pos = _orientation == Orientation.Vertical ? e.Y : e.X;
            float track = Math.Max(1f, TrackLength - ThumbLength);
            float frac = LMaterialTheme.Clamp01((pos - _dragOffset) / track);
            Value = _minimum + (int)Math.Round(frac * (_maximum - _minimum));
        }

        protected override void OnMouseUp(MouseEventArgs e) { base.OnMouseUp(e); _dragging = false; Invalidate(); }
        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            var thumb = ThumbRect;
            float opacity = _dragging ? 0.7f : (_hovered ? 0.55f : 0.4f);
            LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurfaceVariant, opacity), thumb, 4f);
        }
    }

    /// <summary>Vertical LMaterial scrollbar.</summary>
    public class LMaterialVScrollBar : LMaterialScrollBar
    {
        public LMaterialVScrollBar() { Orientation = Orientation.Vertical; }
    }

    /// <summary>Horizontal LMaterial scrollbar.</summary>
    public class LMaterialHScrollBar : LMaterialScrollBar
    {
        public LMaterialHScrollBar() { Orientation = Orientation.Horizontal; }
        protected override Size DefaultSize { get { return new Size(160, 12); } }
    }
}
