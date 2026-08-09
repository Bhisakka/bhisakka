using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Material 3 basic dialog (MessageBox replacement): surface-container-high
    /// panel with ShapeExtraLarge corners, headline title, body message and
    /// text buttons aligned bottom-right.
    /// </summary>
    public static class LMaterialDialog
    {
        public static DialogResult Show(IWin32Window owner, string title, string message)
        {
            return Show(owner, title, message, "OK", null);
        }

        public static DialogResult Show(IWin32Window owner, string title, string message, string okText, string cancelText)
        {
            var s = LMaterialTheme.Scheme;
            Font titleFont = LMaterialTypography.Get(LMaterialTypeRole.HeadlineSmall);
            Font bodyFont = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);

            const int width = 360, pad = 24;
            int textWidth = width - pad * 2;
            Size titleSize = TextRenderer.MeasureText(title, titleFont, new Size(textWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
            Size msgSize = TextRenderer.MeasureText(message, bodyFont, new Size(textWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
            int height = pad + titleSize.Height + 16 + msgSize.Height + 24 + 40 + pad;

            using (var f = new Form())
            {
                f.FormBorderStyle = FormBorderStyle.None;
                f.ShowInTaskbar = false;
                f.StartPosition = owner != null ? FormStartPosition.CenterParent : FormStartPosition.CenterScreen;
                f.ClientSize = new Size(width, height);
                f.BackColor = s.SurfaceContainerHigh;

                using (var path = LMaterialDrawing.RoundedRect(new RectangleF(0, 0, width, height), LMaterialTheme.ShapeExtraLarge))
                    f.Region = new Region(path);

                f.Paint += delegate(object sender, PaintEventArgs e)
                {
                    var g = e.Graphics;
                    TextRenderer.DrawText(g, title, titleFont, new Rectangle(pad, pad, textWidth, titleSize.Height),
                        s.OnSurface, TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
                    TextRenderer.DrawText(g, message, bodyFont,
                        new Rectangle(pad, pad + titleSize.Height + 16, textWidth, msgSize.Height),
                        s.OnSurfaceVariant, TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
                };

                var ok = new LMaterialButton
                {
                    Text = okText,
                    Variant = LMaterialButtonVariant.Text,
                    DialogResult = DialogResult.OK,
                    Size = new Size(Math.Max(72, LMaterialDrawing.MeasureText(okText, LMaterialTypography.Get(LMaterialTypeRole.LabelLarge)).Width + 32), 40)
                };
                ok.Location = new Point(width - pad - ok.Width, height - pad - 40);
                f.Controls.Add(ok);
                f.AcceptButton = ok;

                if (!string.IsNullOrEmpty(cancelText))
                {
                    var cancel = new LMaterialButton
                    {
                        Text = cancelText,
                        Variant = LMaterialButtonVariant.Text,
                        DialogResult = DialogResult.Cancel,
                        Size = new Size(Math.Max(72, LMaterialDrawing.MeasureText(cancelText, LMaterialTypography.Get(LMaterialTypeRole.LabelLarge)).Width + 32), 40)
                    };
                    cancel.Location = new Point(ok.Left - 8 - cancel.Width, ok.Top);
                    f.Controls.Add(cancel);
                    f.CancelButton = cancel;
                }

                return owner != null ? f.ShowDialog(owner) : f.ShowDialog();
            }
        }
    }

    /// <summary>
    /// Material 3 snackbar: inverse-surface toast anchored to the bottom
    /// center of the owner form, auto-dismissed after a duration.
    /// </summary>
    public static class LMaterialSnackbar
    {
        public static void Show(Form owner, string message, int durationMs = 3000)
        {
            if (owner == null || !owner.Visible) return;
            var s = LMaterialTheme.Scheme;
            Font font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);

            var textSize = LMaterialDrawing.MeasureText(message, font);
            int width = Math.Min(Math.Max(160, textSize.Width + 32), Math.Max(160, owner.ClientSize.Width - 32));
            const int height = 48;

            var f = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                StartPosition = FormStartPosition.Manual,
                ClientSize = new Size(width, height),
                BackColor = s.InverseSurface
            };
            using (var path = LMaterialDrawing.RoundedRect(new RectangleF(0, 0, width, height), LMaterialTheme.ShapeSmall))
                f.Region = new Region(path);

            var anchor = owner.PointToScreen(new Point((owner.ClientSize.Width - width) / 2, owner.ClientSize.Height - height - 24));
            f.Location = anchor;

            f.Paint += delegate(object sender, PaintEventArgs e)
            {
                LMaterialDrawing.DrawText(e.Graphics, message, font, s.InverseOnSurface,
                    new Rectangle(16, 0, width - 32, height), ContentAlignment.MiddleLeft);
            };
            f.Click += delegate { f.Close(); };

            var timer = new Timer { Interval = Math.Max(500, durationMs) };
            timer.Tick += delegate
            {
                timer.Dispose();
                if (!f.IsDisposed) f.Close();
            };
            f.FormClosed += delegate { timer.Dispose(); f.Dispose(); };
            f.Show(owner);
            timer.Start();
        }
    }
}
