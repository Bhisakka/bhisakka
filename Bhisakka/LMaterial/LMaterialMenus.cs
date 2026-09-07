using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>
    /// Material 3 renderer for MenuStrip / ContextMenuStrip / ToolStrip /
    /// StatusStrip: surface-container menus, rounded state layers, hairline
    /// separators and themed glyphs.
    /// </summary>
    public class LMaterialToolStripRenderer : ToolStripRenderer
    {
        private static Color StripBack(ToolStrip strip)
        {
            var s = LMaterialTheme.Scheme;
            if (strip is ToolStripDropDown) return s.SurfaceContainer;
            if (strip is StatusStrip) return s.SurfaceContainer;
            return s.Surface;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (var b = new SolidBrush(StripBack(e.ToolStrip)))
                e.Graphics.FillRectangle(b, e.AffectedBounds);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            using (var b = new SolidBrush(StripBack(e.ToolStrip)))
                e.Graphics.FillRectangle(b, e.AffectedBounds);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (e.ToolStrip is ToolStripDropDown)
            {
                var r = new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
                using (var p = new Pen(LMaterialTheme.Scheme.OutlineVariant, 1f))
                    e.Graphics.DrawRectangle(p, r);
            }
        }

        private static void PaintItemState(Graphics g, ToolStripItem item, bool topLevel)
        {
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);
            var rect = new RectangleF(1, 1, item.Width - 2, item.Height - 2);
            var menuItem = item as ToolStripMenuItem;
            bool open = topLevel && menuItem != null && menuItem.DropDown.Visible;

            if (open)
                LMaterialDrawing.FillRounded(g, s.SecondaryContainer, rect, LMaterialTheme.ShapeSmall);
            else if (item.Selected || item.Pressed)
            {
                Color back = StripBack(item.Owner);
                LMaterialDrawing.FillRounded(g,
                    LMaterialTheme.Layer(back, s.OnSurface, item.Pressed ? LMaterialTheme.PressOpacity : LMaterialTheme.HoverOpacity),
                    rect, LMaterialTheme.ShapeSmall);
            }

            var button = item as ToolStripButton;
            if (button != null && button.Checked)
                LMaterialDrawing.FillRounded(g, s.SecondaryContainer, rect, LMaterialTheme.ShapeSmall);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            PaintItemState(e.Graphics, e.Item, e.Item.OwnerItem == null && e.ToolStrip is MenuStrip);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            PaintItemState(e.Graphics, e.Item, false);
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            PaintItemState(e.Graphics, e.Item, false);
        }

        protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
        {
            PaintItemState(e.Graphics, e.Item, false);
        }

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            PaintItemState(e.Graphics, e.Item, false);
            var box = new Rectangle(e.Item.Width / 2 - 8, e.Item.Height / 2 - 8, 16, 16);
            LMaterialDrawing.DrawChevron(e.Graphics, box, LMaterialTheme.Scheme.OnSurfaceVariant, 0);
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            var menuItem = e.Item as ToolStripMenuItem;
            bool openTop = menuItem != null && e.Item.OwnerItem == null && e.ToolStrip is MenuStrip && menuItem.DropDown.Visible;
            e.TextColor = !e.Item.Enabled
                ? LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity)
                : openTop ? s.OnSecondaryContainer : s.OnSurface;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            var g = e.Graphics;
            using (var p = new Pen(s.OutlineVariant, 1f))
            {
                if (e.Vertical)
                    g.DrawLine(p, e.Item.Width / 2f, 4, e.Item.Width / 2f, e.Item.Height - 4);
                else
                    g.DrawLine(p, 8, e.Item.Height / 2f, e.Item.Width - 8, e.Item.Height / 2f);
            }
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Enabled
                ? LMaterialTheme.Scheme.OnSurfaceVariant
                : LMaterialTheme.Alpha(LMaterialTheme.Scheme.OnSurface, LMaterialTheme.DisabledContentOpacity);
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(e.Graphics);
            var r = e.ImageRectangle;
            r.Inflate(-1, -1);
            LMaterialDrawing.DrawCheckMark(e.Graphics, r, s.Primary, 2f);
        }

        protected override void OnRenderGrip(ToolStripGripRenderEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            var g = e.Graphics;
            LMaterialDrawing.ApplyQuality(g);
            using (var b = new SolidBrush(s.OutlineVariant))
            {
                if (e.GripStyle != ToolStripGripStyle.Visible) return;
                for (int y = 8; y < e.GripBounds.Height - 8; y += 5)
                    g.FillEllipse(b, e.GripBounds.X + 2, e.GripBounds.Y + y, 3, 3);
            }
        }

        protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
        {
            // hidden: M3 surfaces keep the corner clean
        }
    }

    /// <summary>Material 3 menu bar.</summary>
    public class LMaterialMenuStrip : MenuStrip
    {
        public LMaterialMenuStrip()
        {
            Renderer = new LMaterialToolStripRenderer();
            Padding = new Padding(8, 4, 8, 4);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.Surface;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.LabelLarge);
        }
    }

    /// <summary>Material 3 context menu.</summary>
    public class LMaterialContextMenuStrip : ContextMenuStrip
    {
        public LMaterialContextMenuStrip()
        {
            Renderer = new LMaterialToolStripRenderer();
            LMaterialTheme.Register(this, ApplyTheme);
        }

        public LMaterialContextMenuStrip(IContainer container) : base(container)
        {
            Renderer = new LMaterialToolStripRenderer();
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainer;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
        }
    }

    /// <summary>Material 3 tool bar.</summary>
    public class LMaterialToolStrip : ToolStrip
    {
        public LMaterialToolStrip()
        {
            Renderer = new LMaterialToolStripRenderer();
            GripStyle = ToolStripGripStyle.Hidden;
            Padding = new Padding(8, 4, 8, 4);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.Surface;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.LabelLarge);
        }
    }

    /// <summary>Material 3 status bar.</summary>
    public class LMaterialStatusStrip : StatusStrip
    {
        public LMaterialStatusStrip()
        {
            Renderer = new LMaterialToolStripRenderer();
            SizingGrip = false;
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainer;
            ForeColor = s.OnSurfaceVariant;
            Font = LMaterialTypography.Get(LMaterialTypeRole.LabelMedium);
        }
    }

    /// <summary>Material 3 plain tooltip: inverse surface container, inverse-on-surface text.</summary>
    public class LMaterialToolTip : ToolTip
    {
        public LMaterialToolTip() { Init(); }
        public LMaterialToolTip(IContainer container) : base(container) { Init(); }

        private void Init()
        {
            OwnerDraw = true;
            Popup += OnPopup;
            Draw += OnDrawTip;
        }

        private void OnPopup(object sender, PopupEventArgs e)
        {
            string text = GetToolTip(e.AssociatedControl);
            var size = LMaterialDrawing.MeasureText(text, LMaterialTypography.Get(LMaterialTypeRole.BodySmall));
            e.ToolTipSize = new Size(size.Width + 16, Math.Max(24, size.Height + 10));
        }

        private void OnDrawTip(object sender, DrawToolTipEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            using (var b = new SolidBrush(s.InverseSurface))
                e.Graphics.FillRectangle(b, e.Bounds);
            LMaterialDrawing.DrawText(e.Graphics, e.ToolTipText,
                LMaterialTypography.Get(LMaterialTypeRole.BodySmall),
                s.InverseOnSurface, e.Bounds, ContentAlignment.MiddleCenter);
        }
    }
}
