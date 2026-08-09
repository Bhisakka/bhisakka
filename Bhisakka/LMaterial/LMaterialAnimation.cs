using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Lightweight timer-driven float animator (ease-out cubic), used for the
    /// M3 Expressive motion touches: shape morphs, switch thumbs, floating labels.
    /// Invalidates the owning control on every frame.
    /// </summary>
    public sealed class LMaterialAnimator : IDisposable
    {
        private readonly Timer _timer = new Timer { Interval = 15 };
        private readonly Control _owner;
        private float _from, _to, _value;
        private int _startTick, _duration;

        public float Value { get { return _value; } }

        public LMaterialAnimator(Control owner, float initial = 0f)
        {
            _owner = owner;
            _value = _from = _to = initial;
            _timer.Tick += OnTick;
            owner.Disposed += delegate { Dispose(); };
        }

        public void Snap(float value)
        {
            _timer.Stop();
            _value = _from = _to = value;
            SafeInvalidate();
        }

        public void AnimateTo(float target, int durationMs)
        {
            if (Math.Abs(target - _value) < 0.001f) { _value = target; return; }
            if (!_owner.IsHandleCreated) { Snap(target); return; }
            _from = _value;
            _to = target;
            _duration = Math.Max(1, durationMs);
            _startTick = Environment.TickCount;
            _timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            float t = (Environment.TickCount - _startTick) / (float)_duration;
            if (t >= 1f)
            {
                t = 1f;
                _timer.Stop();
            }
            float eased = 1f - (float)Math.Pow(1f - t, 3); // ease-out cubic
            _value = _from + (_to - _from) * eased;
            SafeInvalidate();
        }

        private void SafeInvalidate()
        {
            if (_owner != null && _owner.IsHandleCreated && !_owner.IsDisposed) _owner.Invalidate();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }

    /// <summary>
    /// M3 press ripple. Attach to a control; call <see cref="Paint"/> from
    /// OnPaint with the clip shape and the content color of the surface.
    /// </summary>
    public sealed class LMaterialRipple
    {
        private readonly Control _owner;
        private readonly LMaterialAnimator _spread;
        private readonly LMaterialAnimator _fade;
        private PointF _center;

        public LMaterialRipple(Control owner)
        {
            _owner = owner;
            _spread = new LMaterialAnimator(owner);
            _fade = new LMaterialAnimator(owner);
            owner.MouseDown += OnMouseDown;
            owner.MouseUp += OnRelease;
            owner.MouseLeave += OnReleaseNoArgs;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _center = e.Location;
            _spread.Snap(0f);
            _fade.Snap(1f);
            _spread.AnimateTo(1f, 420);
        }

        private void OnRelease(object sender, MouseEventArgs e) { Release(); }
        private void OnReleaseNoArgs(object sender, EventArgs e) { Release(); }

        /// <summary>Starts the ripple from the control center (keyboard activation).</summary>
        public void StartFromCenter()
        {
            _center = new PointF(_owner.Width / 2f, _owner.Height / 2f);
            _spread.Snap(0f);
            _fade.Snap(1f);
            _spread.AnimateTo(1f, 420);
            _fade.AnimateTo(0f, 500);
        }

        public void Release()
        {
            if (_fade.Value > 0f) _fade.AnimateTo(0f, 320);
        }

        public void Paint(Graphics g, GraphicsPath clip, Color contentColor)
        {
            float fade = _fade.Value;
            float spread = _spread.Value;
            if (fade <= 0.01f || spread <= 0.01f) return;

            float w = _owner.Width, h = _owner.Height;
            float dx = Math.Max(_center.X, w - _center.X);
            float dy = Math.Max(_center.Y, h - _center.Y);
            float maxRadius = (float)Math.Sqrt(dx * dx + dy * dy);
            float radius = Math.Max(8f, maxRadius * spread);

            var old = g.Clip;
            g.SetClip(clip, CombineMode.Intersect);
            using (var b = new SolidBrush(LMaterialTheme.Alpha(contentColor, LMaterialTheme.PressOpacity * fade)))
                g.FillEllipse(b, _center.X - radius, _center.Y - radius, radius * 2, radius * 2);
            g.Clip = old;
        }
    }
}
