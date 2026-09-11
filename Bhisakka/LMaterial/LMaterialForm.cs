using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Form bound to the LMaterial theme: surface background, M3 typography,
    /// and (on Windows 10 20H1+/11) a title bar recolored to match the scheme.
    /// </summary>
    public class LMaterialForm : Form
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_OLD = 19;
        private const int DWMWA_CAPTION_COLOR = 35;
        private const int DWMWA_TEXT_COLOR = 36;

        public LMaterialForm()
        {
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.Surface;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
            ApplyTitleBar();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyTitleBar();
        }

        private static int ToColorRef(Color c)
        {
            return c.R | (c.G << 8) | (c.B << 16);
        }

        private void ApplyTitleBar()
        {
            if (!IsHandleCreated) return;
            try
            {
                var s = LMaterialTheme.Scheme;
                int dark = LMaterialTheme.IsDark ? 1 : 0;
                if (DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref dark, sizeof(int)) != 0)
                    DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_OLD, ref dark, sizeof(int));

                int caption = ToColorRef(s.SurfaceContainer);
                int text = ToColorRef(s.OnSurface);
                DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref caption, sizeof(int));
                DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref text, sizeof(int));
            }
            catch
            {
                // pre-20H1 Windows: keep the default title bar
            }
        }
    }
}
