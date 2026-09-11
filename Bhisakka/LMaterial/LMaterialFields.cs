using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaterialComponents
{
    public enum LMaterialFieldVariant { Outlined, Filled }

    /// <summary>
    /// Base class for all Material 3 text fields: draws the outlined/filled
    /// container, animated floating label, supporting text and error state,
    /// and hosts a native editing control inside.
    /// </summary>
    public abstract class LMaterialFieldBase : Control
    {
        private LMaterialFieldVariant _variant = LMaterialFieldVariant.Outlined;
        private string _labelText = "Label";
        private string _supportingText = "";
        private string _errorText = "";
        private bool _isError;
        private bool _hovered;
        private bool _innerFocused;
        private readonly LMaterialAnimator _float;

        protected Control Inner { get; private set; }

        public LMaterialFieldBase()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.Selectable, true);
            _float = new LMaterialAnimator(this);

            Inner = CreateInnerControl();
            Inner.TabStop = true;
            Inner.GotFocus += delegate { _innerFocused = true; UpdateFloatState(); Invalidate(); };
            Inner.LostFocus += delegate { _innerFocused = false; UpdateFloatState(); Invalidate(); };
            Inner.TextChanged += delegate { UpdateFloatState(); OnTextChanged(EventArgs.Empty); };
            Inner.MouseEnter += delegate { _hovered = true; Invalidate(); };
            Inner.MouseLeave += delegate { _hovered = false; Invalidate(); };
            Controls.Add(Inner);
            LMaterialScrollBars.Attach(Inner);

            LMaterialTheme.Register(this, ApplyTheme);
            UpdateFloatState(true);
        }

        protected abstract Control CreateInnerControl();
        protected virtual bool AlwaysFloat { get { return false; } }
        protected virtual bool HasValue { get { return Inner != null && Inner.Text.Length > 0; } }
        protected virtual bool IsMultilineInner { get { return false; } }

        /// <summary>The hosted native control, for advanced scenarios.</summary>
        [Browsable(false)]
        public Control InnerControl { get { return Inner; } }

        [Category("LMaterial"), DefaultValue(LMaterialFieldVariant.Outlined)]
        public LMaterialFieldVariant Variant
        {
            get { return _variant; }
            set { _variant = value; ApplyTheme(); PerformInnerLayout(); Invalidate(); }
        }

        [Category("LMaterial"), DefaultValue("Label")]
        public string LabelText { get { return _labelText; } set { _labelText = value ?? ""; Invalidate(); } }

        [Category("LMaterial"), DefaultValue("")]
        public string SupportingText { get { return _supportingText; } set { _supportingText = value ?? ""; Invalidate(); } }

        [Category("LMaterial"), DefaultValue("")]
        public string ErrorText { get { return _errorText; } set { _errorText = value ?? ""; Invalidate(); } }

        [Category("LMaterial"), DefaultValue(false)]
        public bool IsError { get { return _isError; } set { _isError = value; Invalidate(); } }

        protected override Size DefaultSize { get { return new Size(240, 84); } }

        protected Rectangle FieldRect
        {
            get { return new Rectangle(0, 8, Math.Max(40, Width) - 1, Math.Max(64, Height) - 8 - 22); }
        }

        protected Color FieldBackColor
        {
            get
            {
                return _variant == LMaterialFieldVariant.Filled
                    ? LMaterialTheme.Scheme.SurfaceContainerHighest
                    : LMaterialTheme.ResolveBackColor(this);
            }
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            Inner.Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge);
            Inner.ForeColor = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            Inner.BackColor = FieldBackColor;
            PerformInnerLayout();
        }

        private void UpdateFloatState(bool snap = false)
        {
            bool floated = AlwaysFloat || _innerFocused || HasValue;
            Inner.Visible = floated;
            if (snap) _float.Snap(floated ? 1f : 0f);
            else _float.AnimateTo(floated ? 1f : 0f, 160);
        }

        protected virtual void PerformInnerLayout()
        {
            var field = FieldRect;
            if (IsMultilineInner)
            {
                int top = field.Top + 24;
                Inner.SetBounds(16, top, Math.Max(20, field.Width - 32), Math.Max(20, field.Bottom - 10 - top));
            }
            else
            {
                int h = Inner.PreferredSize.Height;
                int y = _variant == LMaterialFieldVariant.Filled
                    ? field.Top + (field.Height + 14 - h) / 2
                    : field.Top + (field.Height - h) / 2;
                Inner.SetBounds(16, y, Math.Max(20, field.Width - 32), h);
            }
        }

        protected override void OnResize(EventArgs e) { base.OnResize(e); PerformInnerLayout(); }
        protected override void OnParentChanged(EventArgs e) { base.OnParentChanged(e); ApplyTheme(); }
        protected override void OnEnabledChanged(EventArgs e) { base.OnEnabledChanged(e); ApplyTheme(); Invalidate(); }
        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            FocusInner();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            FocusInner();
        }

        public void FocusInner()
        {
            if (!Enabled) return;
            Inner.Visible = true;
            Inner.Focus();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            using (var b = new SolidBrush(LMaterialTheme.ResolveBackColor(this)))
                g.FillRectangle(b, ClientRectangle);
            LMaterialDrawing.ApplyQuality(g);

            var s = LMaterialTheme.Scheme;
            var field = FieldRect;
            bool err = _isError;
            bool focused = _innerFocused;
            float t = _float.Value;
            bool enabled = Enabled;

            Color accent = err ? s.Error : s.Primary;
            Color outline = err ? s.Error : (focused ? s.Primary : (_hovered ? s.OnSurface : s.Outline));
            if (!enabled) outline = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity);

            if (_variant == LMaterialFieldVariant.Filled)
            {
                Color container = enabled ? s.SurfaceContainerHighest
                    : LMaterialTheme.Layer(s.Surface, s.OnSurface, 0.04f);
                using (var path = LMaterialDrawing.RoundedRect(field, LMaterialTheme.ShapeExtraSmall,
                    LMaterialTheme.ShapeExtraSmall, 0, 0))
                using (var b = new SolidBrush(container))
                    g.FillPath(b, path);

                float lw = focused ? 2f : 1f;
                Color line = err ? s.Error : (focused ? s.Primary : (enabled ? s.OnSurfaceVariant : outline));
                using (var p = new Pen(line, lw))
                    g.DrawLine(p, field.X, field.Bottom - lw / 2f, field.Right, field.Bottom - lw / 2f);
            }
            else
            {
                LMaterialDrawing.FillRounded(g, FieldBackColor, field, LMaterialTheme.ShapeExtraSmall);
                LMaterialDrawing.StrokeRounded(g, outline, focused || err ? 2f : 1f, field, LMaterialTheme.ShapeExtraSmall);
            }

            // ---- floating label -------------------------------------------
            if (_labelText.Length > 0)
            {
                float size = LMaterialTheme.Lerp(12f, 9f, t);
                Font labelFont = LMaterialTypography.GetFont(LMaterialTypography.BodyFontName, size, false);
                Size ls = LMaterialDrawing.MeasureText(_labelText, labelFont);

                float restY = IsMultilineInner ? field.Top + 14 : field.Top + (field.Height - ls.Height) / 2f;
                float floatY = _variant == LMaterialFieldVariant.Filled
                    ? field.Top + 7f
                    : field.Top - ls.Height / 2f;
                float y = LMaterialTheme.Lerp(restY, floatY, t);

                Color labelColor;
                if (!enabled) labelColor = LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
                else if (err) labelColor = s.Error;
                else if (focused) labelColor = accent;
                else labelColor = s.OnSurfaceVariant;

                if (_variant == LMaterialFieldVariant.Outlined && t > 0.4f)
                {
                    // notch: erase the border behind the floated label
                    using (var b = new SolidBrush(FieldBackColor))
                        g.FillRectangle(b, 12, y - 1, ls.Width + 8, ls.Height + 2);
                }
                TextRenderer.DrawText(g, _labelText, labelFont,
                    new Rectangle(16, (int)Math.Round(y), ls.Width + 4, ls.Height + 2),
                    labelColor, TextFormatFlags.NoPadding | TextFormatFlags.Left | TextFormatFlags.Top);
            }

            // ---- supporting / error text ----------------------------------
            string support = err && _errorText.Length > 0 ? _errorText : _supportingText;
            if (!string.IsNullOrEmpty(support))
            {
                Font f = LMaterialTypography.Get(LMaterialTypeRole.BodySmall);
                Color c = !enabled ? LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity)
                        : err ? s.Error : s.OnSurfaceVariant;
                LMaterialDrawing.DrawText(g, support, f, c,
                    new Rectangle(16, field.Bottom + 4, Math.Max(10, Width - 32), 18), ContentAlignment.TopLeft);
            }
        }
    }

    /// <summary>Material 3 text field hosting a native TextBox.</summary>
    public class LMaterialTextBox : LMaterialFieldBase
    {
        private TextBox _box;

        protected override Control CreateInnerControl()
        {
            _box = new TextBox { BorderStyle = BorderStyle.None };
            return _box;
        }

        [Browsable(false)]
        public TextBox InnerTextBox { get { return _box; } }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]
        public override string Text { get { return _box.Text; } set { _box.Text = value; } }

        [Category("LMaterial"), DefaultValue(false)]
        public bool Multiline
        {
            get { return _box.Multiline; }
            set { _box.Multiline = value; PerformInnerLayout(); Invalidate(); }
        }

        protected override bool IsMultilineInner { get { return _box != null && _box.Multiline; } }

        [Category("LMaterial"), DefaultValue(false)]
        public bool UseSystemPasswordChar { get { return _box.UseSystemPasswordChar; } set { _box.UseSystemPasswordChar = value; } }

        [Category("LMaterial"), DefaultValue(false)]
        public bool ReadOnly { get { return _box.ReadOnly; } set { _box.ReadOnly = value; } }

        [Category("LMaterial"), DefaultValue(32767)]
        public int MaxLength { get { return _box.MaxLength; } set { _box.MaxLength = value; } }
    }

    /// <summary>Material 3 multiline rich-text field hosting a native RichTextBox.</summary>
    public class LMaterialRichTextBox : LMaterialFieldBase
    {
        private RichTextBox _box;

        protected override Control CreateInnerControl()
        {
            _box = new RichTextBox { BorderStyle = BorderStyle.None };
            return _box;
        }

        protected override Size DefaultSize { get { return new Size(280, 140); } }
        protected override bool IsMultilineInner { get { return true; } }

        [Browsable(false)]
        public RichTextBox InnerRichTextBox { get { return _box; } }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text { get { return _box.Text; } set { _box.Text = value; } }
    }

    /// <summary>Material 3 masked text field hosting a native MaskedTextBox.</summary>
    public class LMaterialMaskedTextBox : LMaterialFieldBase
    {
        private MaskedTextBox _box;

        protected override Control CreateInnerControl()
        {
            _box = new MaskedTextBox { BorderStyle = BorderStyle.None };
            return _box;
        }

        [Browsable(false)]
        public MaskedTextBox InnerMaskedTextBox { get { return _box; } }

        [Category("LMaterial"), DefaultValue("")]
        public string Mask { get { return _box.Mask; } set { _box.Mask = value; } }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text { get { return _box.Text; } set { _box.Text = value; } }

        protected override bool HasValue
        {
            get
            {
                if (_box == null) return false;
                if (_box.MaskedTextProvider != null) return _box.MaskedTextProvider.AssignedEditPositionCount > 0;
                return _box.Text.Length > 0;
            }
        }
    }

    /// <summary>
    /// Base for spinner fields: hides the native up/down buttons (WinForms
    /// paints them with the light visual-style renderer, which cannot be
    /// recolored) and draws Material chevron steppers inside the field.
    /// </summary>
    public abstract class LMaterialSpinnerFieldBase : LMaterialFieldBase
    {
        private Rectangle _upRect, _downRect;
        private int _hotZone;

        protected abstract void StepUp();
        protected abstract void StepDown();

        protected static void HideNativeSpinButtons(UpDownBase box)
        {
            foreach (Control child in box.Controls)
            {
                if (child.GetType().Name != "UpDownButtons") continue;
                Control buttons = child;
                buttons.Visible = false;
                buttons.VisibleChanged += delegate { if (buttons.Visible) buttons.Visible = false; };
            }
        }

        protected override void PerformInnerLayout()
        {
            base.PerformInnerLayout();
            if (Inner != null)
            {
                var b = Inner.Bounds;
                Inner.SetBounds(b.X, b.Y, Math.Max(20, b.Width - 28), b.Height);
            }
            var field = FieldRect;
            int cy = field.Top + field.Height / 2;
            _upRect = new Rectangle(field.Right - 34, cy - 22, 26, 22);
            _downRect = new Rectangle(field.Right - 34, cy, 26, 22);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Enabled && e.Button == MouseButtons.Left)
            {
                if (_upRect.Contains(e.Location)) { StepUp(); FocusInner(); return; }
                if (_downRect.Contains(e.Location)) { StepDown(); FocusInner(); return; }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int zone = _upRect.Contains(e.Location) ? 1 : (_downRect.Contains(e.Location) ? 2 : 0);
            if (zone != _hotZone) { _hotZone = zone; Invalidate(); }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hotZone != 0) { _hotZone = 0; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            var s = LMaterialTheme.Scheme;
            Color glyph = Enabled ? s.OnSurfaceVariant : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            if (Enabled && _hotZone == 1)
                LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.HoverOpacity), _upRect, LMaterialTheme.ShapeExtraSmall);
            if (Enabled && _hotZone == 2)
                LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.HoverOpacity), _downRect, LMaterialTheme.ShapeExtraSmall);
            LMaterialDrawing.DrawChevron(g, _upRect, glyph, 1);
            LMaterialDrawing.DrawChevron(g, _downRect, glyph, 0);
        }
    }

    /// <summary>Material 3 numeric field hosting a native NumericUpDown with themed steppers.</summary>
    public class LMaterialNumericUpDown : LMaterialSpinnerFieldBase
    {
        private NumericUpDown _box;

        public event EventHandler ValueChanged;

        protected override Control CreateInnerControl()
        {
            _box = new NumericUpDown { BorderStyle = BorderStyle.None };
            _box.ValueChanged += delegate { var h = ValueChanged; if (h != null) h(this, EventArgs.Empty); };
            HideNativeSpinButtons(_box);
            return _box;
        }

        protected override bool AlwaysFloat { get { return true; } }
        protected override void StepUp() { _box.UpButton(); }
        protected override void StepDown() { _box.DownButton(); }

        [Browsable(false)]
        public NumericUpDown InnerNumericUpDown { get { return _box; } }

        [Category("LMaterial")]
        public decimal Value { get { return _box.Value; } set { _box.Value = value; } }

        [Category("LMaterial")]
        public decimal Minimum { get { return _box.Minimum; } set { _box.Minimum = value; } }

        [Category("LMaterial")]
        public decimal Maximum { get { return _box.Maximum; } set { _box.Maximum = value; } }

        [Category("LMaterial"), DefaultValue(0)]
        public int DecimalPlaces { get { return _box.DecimalPlaces; } set { _box.DecimalPlaces = value; } }
    }

    /// <summary>Material 3 item-spinner field hosting a native DomainUpDown with themed steppers.</summary>
    public class LMaterialDomainUpDown : LMaterialSpinnerFieldBase
    {
        private DomainUpDown _box;

        protected override Control CreateInnerControl()
        {
            _box = new DomainUpDown { BorderStyle = BorderStyle.None };
            HideNativeSpinButtons(_box);
            return _box;
        }

        protected override bool AlwaysFloat { get { return true; } }
        protected override void StepUp() { _box.UpButton(); }
        protected override void StepDown() { _box.DownButton(); }

        [Browsable(false)]
        public DomainUpDown InnerDomainUpDown { get { return _box; } }

        [Category("LMaterial")]
        public DomainUpDown.DomainUpDownItemCollection Items { get { return _box.Items; } }

        [Category("LMaterial"), DefaultValue(-1)]
        public int SelectedIndex { get { return _box.SelectedIndex; } set { _box.SelectedIndex = value; } }
    }

    /// <summary>Material 3 date field hosting a DateTimePicker with an LMaterial-painted face.</summary>
    public class LMaterialDateTimePicker : LMaterialFieldBase
    {
        private LMaterialThemedDateTimePicker _box;

        public event EventHandler ValueChanged;

        protected override Control CreateInnerControl()
        {
            _box = new LMaterialThemedDateTimePicker();
            _box.ValueChanged += delegate { var h = ValueChanged; if (h != null) h(this, EventArgs.Empty); };
            LMaterialTheme.Register(_box, delegate
            {
                var s = LMaterialTheme.Scheme;
                _box.CalendarMonthBackground = s.SurfaceContainerHigh;
                _box.CalendarForeColor = s.OnSurface;
                _box.CalendarTitleBackColor = s.SurfaceContainerHigh;
                _box.CalendarTitleForeColor = s.Primary;
                _box.CalendarTrailingForeColor = s.Outline;
            });
            return _box;
        }

        protected override bool AlwaysFloat { get { return true; } }

        [Browsable(false)]
        public DateTimePicker InnerDateTimePicker { get { return _box; } }

        [Category("LMaterial")]
        public DateTime Value { get { return _box.Value; } set { _box.Value = value; } }

        [Category("LMaterial"), DefaultValue(DateTimePickerFormat.Long)]
        public DateTimePickerFormat Format { get { return _box.Format; } set { _box.Format = value; } }

        [Category("LMaterial"), DefaultValue("")]
        public string CustomFormat { get { return _box.CustomFormat; } set { _box.CustomFormat = value; } }
    }

    /// <summary>
    /// DateTimePicker whose closed face is repainted in LMaterial colors and
    /// whose drop-down calendar is un-themed on open so the Calendar* colors
    /// apply (native month calendars ignore colors while visual styles are on).
    /// </summary>
    public class LMaterialThemedDateTimePicker : DateTimePicker
    {
        private const int WM_PAINT = 0x000F;
        private const int DTM_GETMONTHCAL = 0x1000 + 8;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idList);

        protected override void OnDropDown(EventArgs eventargs)
        {
            base.OnDropDown(eventargs);
            try
            {
                IntPtr cal = SendMessage(Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
                if (cal != IntPtr.Zero) SetWindowTheme(cal, "", "");
            }
            catch { }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && IsHandleCreated)
            {
                using (var g = Graphics.FromHwnd(Handle))
                    PaintFace(g);
            }
        }

        private void PaintFace(Graphics g)
        {
            var s = LMaterialTheme.Scheme;
            using (var b = new SolidBrush(BackColor.A == 255 ? BackColor : s.Surface))
                g.FillRectangle(b, new Rectangle(0, 0, Width, Height));
            Color content = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            LMaterialDrawing.DrawText(g, Text, Font, content,
                new Rectangle(0, 0, Math.Max(10, Width - 24), Height), ContentAlignment.MiddleLeft);
            LMaterialDrawing.DrawChevron(g, new Rectangle(Width - 22, Height / 2 - 10, 20, 20),
                Enabled ? s.OnSurfaceVariant : content, 0);
        }
    }

    /// <summary>MonthCalendar with LMaterial colors (native rendering limits styling on some OS themes).</summary>
    public class LMaterialMonthCalendar : MonthCalendar
    {
        public LMaterialMonthCalendar()
        {
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainerHigh;
            ForeColor = s.OnSurface;
            TitleBackColor = s.Primary;
            TitleForeColor = s.OnPrimary;
            TrailingForeColor = LMaterialTheme.Alpha(s.OnSurfaceVariant, LMaterialTheme.DisabledContentOpacity);
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
        }
    }
}
