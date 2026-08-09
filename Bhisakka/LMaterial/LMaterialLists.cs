using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaterialComponents
{
    /// <summary>Material 3 list: rounded selection pill, state layers, no chrome.</summary>
    public class LMaterialListBox : ListBox
    {
        private int _hoverIndex = -1;

        public LMaterialListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            BorderStyle = BorderStyle.None;
            ItemHeight = 40;
            IntegralHeight = false;
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainerLow;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int idx = IndexFromPoint(e.Location);
            if (idx != _hoverIndex) { _hoverIndex = idx; Invalidate(); }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_hoverIndex != -1) { _hoverIndex = -1; Invalidate(); }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index < 0 || e.Index >= Items.Count) return;
            var g = e.Graphics;
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);

            using (var b = new SolidBrush(BackColor)) g.FillRectangle(b, e.Bounds);

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var pill = new RectangleF(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width - 8, e.Bounds.Height - 4);
            Color content = selected ? s.OnSecondaryContainer : s.OnSurface;

            if (selected)
                LMaterialDrawing.FillRounded(g, s.SecondaryContainer, pill, pill.Height / 2f);
            else if (e.Index == _hoverIndex)
                LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.HoverOpacity), pill, pill.Height / 2f);

            string text = GetItemText(Items[e.Index]);
            var tr = new Rectangle(e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 28, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, text, Font, content, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>Material 3 checked list: M3 checkboxes and rounded selection.</summary>
    public class LMaterialCheckedListBox : CheckedListBox
    {
        public LMaterialCheckedListBox()
        {
            BorderStyle = BorderStyle.None;
            IntegralHeight = false;
            CheckOnClick = true;
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainerLow;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count) return;
            var g = e.Graphics;
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);

            using (var b = new SolidBrush(BackColor)) g.FillRectangle(b, e.Bounds);

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            bool isChecked = GetItemChecked(e.Index);
            if (selected)
            {
                var pill = new RectangleF(e.Bounds.X + 2, e.Bounds.Y + 1, e.Bounds.Width - 4, e.Bounds.Height - 2);
                LMaterialDrawing.FillRounded(g, LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.HoverOpacity), pill, pill.Height / 2f);
            }

            var box = new Rectangle(e.Bounds.X + 8, e.Bounds.Y + (e.Bounds.Height - 16) / 2, 16, 16);
            if (isChecked)
            {
                LMaterialDrawing.FillRounded(g, s.Primary, box, 2f);
                LMaterialDrawing.DrawCheckMark(g, box, s.OnPrimary, 1.8f);
            }
            else
            {
                LMaterialDrawing.StrokeRounded(g, s.OnSurfaceVariant, 2f, box, 2f);
            }

            string text = GetItemText(Items[e.Index]);
            var tr = new Rectangle(box.Right + 10, e.Bounds.Y, e.Bounds.Right - box.Right - 14, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, text, Font, s.OnSurface, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>
    /// Material 3 dropdown field (exposed dropdown menu). Owner-drawn items;
    /// the closed face is repainted with an M3 outlined field + trailing chevron.
    /// </summary>
    public class LMaterialComboBox : ComboBox
    {
        private const int WM_PAINT = 0x000F;
        private bool _hovered;

        public LMaterialComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
            DrawMode = DrawMode.OwnerDrawFixed;
            FlatStyle = FlatStyle.Flat;
            ItemHeight = 36;
            IntegralHeight = false;
            DoubleBuffered = true;
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainer;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge);
        }

        protected override void OnMouseEnter(EventArgs e) { _hovered = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hovered = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnDropDown(EventArgs e) { base.OnDropDown(e); LMaterialScrollBars.ApplyToDropDown(this); }
        protected override void OnDropDownClosed(EventArgs e) { base.OnDropDownClosed(e); Invalidate(); }
        protected override void OnSelectedIndexChanged(EventArgs e) { base.OnSelectedIndexChanged(e); Invalidate(); }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index < 0) return;
            if ((e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit) return; // face painted in WndProc

            var g = e.Graphics;
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);
            using (var b = new SolidBrush(s.SurfaceContainer)) g.FillRectangle(b, e.Bounds);

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var pill = new RectangleF(e.Bounds.X + 4, e.Bounds.Y + 2, e.Bounds.Width - 8, e.Bounds.Height - 4);
            if (selected)
                LMaterialDrawing.FillRounded(g, LMaterialTheme.Layer(s.SurfaceContainer, s.OnSurface, LMaterialTheme.HoverOpacity), pill, LMaterialTheme.ShapeSmall);

            string text = GetItemText(Items[e.Index]);
            var tr = new Rectangle(e.Bounds.X + 16, e.Bounds.Y, e.Bounds.Width - 24, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, text, Font, s.OnSurface, tr, ContentAlignment.MiddleLeft);
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT && DropDownStyle == ComboBoxStyle.DropDownList)
            {
                using (var g = Graphics.FromHwnd(Handle))
                    PaintFace(g);
            }
        }

        private void PaintFace(Graphics g)
        {
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);

            var rect = new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f);
            Color back = LMaterialTheme.ResolveBackColor(this);
            using (var b = new SolidBrush(back)) g.FillRectangle(b, new Rectangle(0, 0, Width, Height));

            Color fill = _hovered && Enabled ? LMaterialTheme.Layer(back, s.OnSurface, 0.04f) : back;
            LMaterialDrawing.FillRounded(g, fill, rect, LMaterialTheme.ShapeExtraSmall);

            Color border = !Enabled ? LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContainerOpacity)
                : (Focused || DroppedDown) ? s.Primary : (_hovered ? s.OnSurface : s.Outline);
            LMaterialDrawing.StrokeRounded(g, border, Focused || DroppedDown ? 2f : 1f, rect, LMaterialTheme.ShapeExtraSmall);

            Color content = Enabled ? s.OnSurface : LMaterialTheme.Alpha(s.OnSurface, LMaterialTheme.DisabledContentOpacity);
            string text = SelectedIndex >= 0 ? GetItemText(SelectedItem) : "";
            var tr = new Rectangle(16, 0, Width - 48, Height);
            LMaterialDrawing.DrawText(g, text, Font, content, tr, ContentAlignment.MiddleLeft);

            var chevron = new Rectangle(Width - 32, Height / 2 - 10, 20, 20);
            LMaterialDrawing.DrawChevron(g, chevron, Enabled ? s.OnSurfaceVariant : content, DroppedDown ? 1 : 0);
        }
    }

    /// <summary>Material 3 list view (Details view fully owner-drawn).</summary>
    public class LMaterialListView : ListView
    {
        private const int WM_PAINT = 0x000F;

        public LMaterialListView()
        {
            OwnerDraw = true;
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            View = View.Details;
            FullRowSelect = true;
            HeaderStyle = ColumnHeaderStyle.Nonclickable;
            DrawColumnHeader += OnDrawHeader;
            DrawSubItem += OnDrawSub;
            DrawItem += OnDrawRow;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.Surface;
            ForeColor = s.OnSurface;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
        }

        private void OnDrawHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            var g = e.Graphics;
            using (var b = new SolidBrush(s.Surface)) g.FillRectangle(b, e.Bounds);
            using (var p = new Pen(s.OutlineVariant, 1f))
                g.DrawLine(p, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            var tr = new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width - 16, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, e.Header.Text, LMaterialTypography.Get(LMaterialTypeRole.TitleSmall),
                s.OnSurfaceVariant, tr, ContentAlignment.MiddleLeft);
        }

        private void OnDrawRow(object sender, DrawListViewItemEventArgs e)
        {
            if (View != View.Details) e.DrawDefault = true;
        }

        private bool _stretching;

        /// <summary>Stretches the last column so no native (unthemed) header area is exposed.</summary>
        private void StretchLastColumn()
        {
            if (_stretching || View != View.Details || Columns.Count == 0 || !IsHandleCreated) return;
            _stretching = true;
            try
            {
                int others = 0;
                for (int i = 0; i < Columns.Count - 1; i++) others += Columns[i].Width;
                int target = ClientSize.Width - others;
                if (target > 40) Columns[Columns.Count - 1].Width = target;
            }
            finally { _stretching = false; }
        }

        protected override void OnResize(EventArgs e) { base.OnResize(e); StretchLastColumn(); }

        protected override void OnColumnWidthChanged(ColumnWidthChangedEventArgs e)
        {
            base.OnColumnWidthChanged(e);
            StretchLastColumn();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            StretchLastColumn();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // Cover native (unthemed) artifacts: the header strip right of the
            // last column, and the column-separator lines the theme paints in
            // the empty area below the last item.
            if (m.Msg == WM_PAINT && View == View.Details && Columns.Count > 0 && IsHandleCreated)
            {
                var s = LMaterialTheme.Scheme;
                int columnsRight = 0;
                foreach (ColumnHeader c in Columns) columnsRight += c.Width;
                int headerBottom = Items.Count > 0 ? GetItemRect(0).Top : Font.Height + 14;

                using (var g = Graphics.FromHwnd(Handle))
                {
                    if (columnsRight < ClientSize.Width && headerBottom > 0)
                    {
                        using (var b = new SolidBrush(s.Surface))
                            g.FillRectangle(b, columnsRight, 0, ClientSize.Width - columnsRight, headerBottom - 1);
                        using (var p = new Pen(s.OutlineVariant, 1f))
                            g.DrawLine(p, columnsRight, headerBottom - 1, ClientSize.Width, headerBottom - 1);
                    }

                    int contentBottom = headerBottom;
                    if (Items.Count > 0)
                    {
                        var last = Items[Items.Count - 1].Bounds;
                        contentBottom = Math.Max(contentBottom, last.Bottom);
                    }
                    if (contentBottom < ClientSize.Height)
                        using (var b = new SolidBrush(s.Surface))
                            g.FillRectangle(b, 0, contentBottom, ClientSize.Width, ClientSize.Height - contentBottom);
                }
            }
        }

        private void OnDrawSub(object sender, DrawListViewSubItemEventArgs e)
        {
            var s = LMaterialTheme.Scheme;
            var g = e.Graphics;
            bool selected = e.Item.Selected;
            Color bg = selected ? s.SecondaryContainer : s.Surface;
            Color fg = selected ? s.OnSecondaryContainer : s.OnSurface;
            using (var b = new SolidBrush(bg)) g.FillRectangle(b, e.Bounds);
            using (var p = new Pen(LMaterialTheme.Alpha(s.OutlineVariant, 0.6f), 1f))
                g.DrawLine(p, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
            var tr = new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width - 16, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, e.SubItem.Text, Font, fg, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>Material 3 tree: rounded full-row selection, themed chevrons via owner-drawn text.</summary>
    public class LMaterialTreeView : TreeView
    {
        public LMaterialTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawText;
            BorderStyle = BorderStyle.None;
            ShowLines = false;
            HideSelection = false;
            ItemHeight = 36;
            Indent = 24;
            DoubleBuffered = true;
            LMaterialScrollBars.Attach(this);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackColor = s.SurfaceContainerLow;
            ForeColor = s.OnSurface;
            LineColor = s.OutlineVariant;
            Font = LMaterialTypography.Get(LMaterialTypeRole.BodyLarge);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            var g = e.Graphics;
            var s = LMaterialTheme.Scheme;
            LMaterialDrawing.ApplyQuality(g);

            bool selected = (e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected;
            var row = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, Math.Max(10, ClientSize.Width - e.Bounds.X - 8), e.Bounds.Height - 4);

            using (var b = new SolidBrush(BackColor)) g.FillRectangle(b, row.X, e.Bounds.Y, row.Width, e.Bounds.Height);
            Color fg = s.OnSurface;
            if (selected)
            {
                LMaterialDrawing.FillRounded(g, s.SecondaryContainer, row, row.Height / 2f);
                fg = s.OnSecondaryContainer;
            }
            var tr = new Rectangle(e.Bounds.X + 8, e.Bounds.Y, (int)row.Width - 12, e.Bounds.Height);
            LMaterialDrawing.DrawText(g, e.Node.Text, Font, fg, tr, ContentAlignment.MiddleLeft);
        }
    }

    /// <summary>Material 3 data table styling for DataGridView.</summary>
    public class LMaterialDataGridView : DataGridView
    {
        public LMaterialDataGridView()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            EnableHeadersVisualStyles = false;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 48;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LMaterialScrollBars.Attach(this);
            foreach (Control child in Controls)
                if (child is ScrollBar) LMaterialScrollBars.Attach(child);
            LMaterialTheme.Register(this, ApplyTheme);
        }

        private void ApplyTheme()
        {
            var s = LMaterialTheme.Scheme;
            BackgroundColor = s.Surface;
            GridColor = s.OutlineVariant;

            ColumnHeadersDefaultCellStyle.BackColor = s.Surface;
            ColumnHeadersDefaultCellStyle.ForeColor = s.OnSurfaceVariant;
            ColumnHeadersDefaultCellStyle.SelectionBackColor = s.Surface;
            ColumnHeadersDefaultCellStyle.SelectionForeColor = s.OnSurfaceVariant;
            ColumnHeadersDefaultCellStyle.Font = LMaterialTypography.Get(LMaterialTypeRole.TitleSmall);
            ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            DefaultCellStyle.BackColor = s.Surface;
            DefaultCellStyle.ForeColor = s.OnSurface;
            DefaultCellStyle.SelectionBackColor = s.SecondaryContainer;
            DefaultCellStyle.SelectionForeColor = s.OnSecondaryContainer;
            DefaultCellStyle.Font = LMaterialTypography.Get(LMaterialTypeRole.BodyMedium);
            DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            RowTemplate.Height = 44;
            foreach (DataGridViewRow row in Rows) row.Height = 44;
        }
    }
}
