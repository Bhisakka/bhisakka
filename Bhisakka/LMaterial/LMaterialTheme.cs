using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaterialComponents
{
    public enum LMaterialThemeVariant
    {
        Light,
        LightMediumContrast,
        LightHighContrast,
        Dark,
        DarkMediumContrast,
        DarkHighContrast
    }

    /// <summary>
    /// Global Material 3 Expressive theme manager. Holds the active color
    /// scheme plus the M3 design tokens (shape, state layers, disabled
    /// opacities) shared by every LMaterial control.
    /// </summary>
    public static class LMaterialTheme
    {
        private static LMaterialThemeVariant _variant = LMaterialThemeVariant.Light;
        private static LMaterialColorScheme _scheme = LMaterialColorScheme.Light;

        public static event EventHandler ThemeChanged;

        public static LMaterialColorScheme Scheme { get { return _scheme; } }
        public static bool IsDark { get { return _scheme.IsDark; } }

        public static LMaterialThemeVariant Variant
        {
            get { return _variant; }
            set
            {
                if (_variant == value) return;
                _variant = value;
                switch (value)
                {
                    case LMaterialThemeVariant.LightMediumContrast: _scheme = LMaterialColorScheme.LightMediumContrast; break;
                    case LMaterialThemeVariant.LightHighContrast: _scheme = LMaterialColorScheme.LightHighContrast; break;
                    case LMaterialThemeVariant.Dark: _scheme = LMaterialColorScheme.Dark; break;
                    case LMaterialThemeVariant.DarkMediumContrast: _scheme = LMaterialColorScheme.DarkMediumContrast; break;
                    case LMaterialThemeVariant.DarkHighContrast: _scheme = LMaterialColorScheme.DarkHighContrast; break;
                    default: _scheme = LMaterialColorScheme.Light; break;
                }
                var h = ThemeChanged;
                if (h != null) h(null, EventArgs.Empty);
            }
        }

        // ---- md.sys.shape corner tokens (px @96dpi) -------------------------
        public const int ShapeNone = 0;
        public const int ShapeExtraSmall = 4;
        public const int ShapeSmall = 8;
        public const int ShapeMedium = 12;
        public const int ShapeLarge = 16;
        public const int ShapeLargeIncreased = 20;
        public const int ShapeExtraLarge = 28;
        public const int ShapeExtraLargeIncreased = 32;
        /// <summary>Sentinel meaning "pill / fully rounded".</summary>
        public const int ShapeFull = -1;

        // ---- md.sys.state state-layer opacities -----------------------------
        public const float HoverOpacity = 0.08f;
        public const float FocusOpacity = 0.10f;
        public const float PressOpacity = 0.10f;
        public const float DragOpacity = 0.16f;
        public const float DisabledContainerOpacity = 0.12f;
        public const float DisabledContentOpacity = 0.38f;

        /// <summary>Resolve a corner-radius token against a shape height (handles ShapeFull).</summary>
        public static float ResolveRadius(int token, float height)
        {
            return token == ShapeFull ? height / 2f : token;
        }

        /// <summary>Apply an opacity (0..1) to a color's alpha channel.</summary>
        public static Color Alpha(Color c, float opacity)
        {
            int a = (int)Math.Round(255 * Clamp01(opacity));
            return Color.FromArgb(Math.Max(0, Math.Min(255, a)), c);
        }

        /// <summary>Opaque linear blend between two colors: t=0 -> a, t=1 -> b.</summary>
        public static Color Blend(Color a, Color b, float t)
        {
            t = Clamp01(t);
            return Color.FromArgb(
                255,
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }

        /// <summary>Composite an overlay color at the given opacity over an opaque base (state layers).</summary>
        public static Color Layer(Color baseColor, Color overlay, float opacity)
        {
            return Blend(baseColor, Color.FromArgb(255, overlay), opacity);
        }

        public static float Clamp01(float v)
        {
            return v < 0f ? 0f : (v > 1f ? 1f : v);
        }

        public static float Lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        /// <summary>
        /// Binds a control to the theme: runs <paramref name="apply"/> now and on every
        /// theme change, unsubscribing automatically when the control is disposed.
        /// </summary>
        public static void Register(Control control, Action apply)
        {
            EventHandler handler = delegate
            {
                if (control.IsDisposed) return;
                if (control.InvokeRequired) { try { control.BeginInvoke(apply); } catch { } return; }
                apply();
                control.Invalidate(true);
            };
            ThemeChanged += handler;
            control.Disposed += delegate { ThemeChanged -= handler; };
            apply();
        }

        /// <summary>Walks up the parent chain for the nearest non-transparent back color.</summary>
        public static Color ResolveBackColor(Control control)
        {
            Control p = control != null ? control.Parent : null;
            while (p != null)
            {
                if (p.BackColor.A == 255 && p.BackColor != Color.Transparent) return p.BackColor;
                p = p.Parent;
            }
            return Scheme.Surface;
        }
    }

    /// <summary>
    /// Themes the native Win32 scrollbars that live inside scrollable
    /// controls (list boxes, trees, grids, scroll panels, text boxes...):
    /// they ignore GDI colors, but honor the "DarkMode_Explorer" window theme
    /// on Windows 10 1809+ / 11. Falls back silently on older systems.
    /// </summary>
    public static class LMaterialScrollBars
    {
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hWnd, string appName, string idList);

        [StructLayout(LayoutKind.Sequential)]
        private struct COMBOBOXINFO
        {
            public int cbSize;
            public Rectangle rcItem;
            public Rectangle rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
        }

        [DllImport("user32.dll")]
        private static extern bool GetComboBoxInfo(IntPtr hWnd, ref COMBOBOXINFO info);

        private static void ApplyToHandle(IntPtr handle)
        {
            if (handle == IntPtr.Zero) return;
            try { SetWindowTheme(handle, LMaterialTheme.IsDark ? "DarkMode_Explorer" : "Explorer", null); }
            catch { }
        }

        /// <summary>Applies the scheme-matching scrollbar theme to a control (and its WinForms ScrollBar children).</summary>
        public static void Apply(Control control)
        {
            if (control == null || !control.IsHandleCreated || control.IsDisposed) return;
            ApplyToHandle(control.Handle);
            foreach (Control child in control.Controls)
                if (child is ScrollBar && child.IsHandleCreated)
                    ApplyToHandle(child.Handle);
        }

        /// <summary>Themes the scrollbar of a ComboBox's drop-down list window.</summary>
        public static void ApplyToDropDown(ComboBox combo)
        {
            if (combo == null || !combo.IsHandleCreated) return;
            var info = new COMBOBOXINFO { cbSize = Marshal.SizeOf(typeof(COMBOBOXINFO)) };
            try
            {
                if (GetComboBoxInfo(combo.Handle, ref info))
                    ApplyToHandle(info.hwndList);
            }
            catch { }
        }

        /// <summary>Keeps a control's native scrollbars in sync with the theme for its whole lifetime.</summary>
        public static void Attach(Control control)
        {
            control.HandleCreated += delegate { Apply(control); };
            LMaterialTheme.Register(control, delegate { Apply(control); });
        }
    }
}
