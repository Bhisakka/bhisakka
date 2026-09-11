namespace Bhisakka.UI.Pharmacy
{
    partial class InventoryForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.split = new MaterialComponents.LMaterialSplitContainer();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvMedicines = new MaterialComponents.LMaterialDataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStockHeader = new MaterialComponents.LMaterialLabel();
            this.pnlAlerts = new System.Windows.Forms.Panel();
            this.lstAlerts = new MaterialComponents.LMaterialListBox();
            this.lblAlertsHeader = new MaterialComponents.LMaterialLabel();
            this.pnlFields = new System.Windows.Forms.Panel();
            this.txtDescription = new MaterialComponents.LMaterialTextBox();
            this.dtExpiry = new MaterialComponents.LMaterialDateTimePicker();
            this.numReorder = new MaterialComponents.LMaterialNumericUpDown();
            this.numQty = new MaterialComponents.LMaterialNumericUpDown();
            this.numPrice = new MaterialComponents.LMaterialNumericUpDown();
            this.cmbUnit = new MaterialComponents.LMaterialComboBox();
            this.lblUnit = new MaterialComponents.LMaterialLabel();
            this.numAlcohol = new MaterialComponents.LMaterialNumericUpDown();
            this.cmbType = new MaterialComponents.LMaterialComboBox();
            this.lblType = new MaterialComponents.LMaterialLabel();
            this.txtName = new MaterialComponents.LMaterialTextBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new MaterialComponents.LMaterialButton();
            this.btnUpdate = new MaterialComponents.LMaterialButton();
            this.btnDelete = new MaterialComponents.LMaterialButton();
            this.btnClear = new MaterialComponents.LMaterialButton();
            this.lblTitle = new MaterialComponents.LMaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.pnlAlerts.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.pnlGrid);
            this.split.Panel1.Controls.Add(this.pnlAlerts);
            this.split.Panel1.Padding = new System.Windows.Forms.Padding(16, 16, 8, 16);
            this.split.Panel1MinSize = 300;
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.pnlFields);
            this.split.Panel2.Controls.Add(this.pnlButtons);
            this.split.Panel2.Controls.Add(this.lblTitle);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(8, 16, 16, 16);
            this.split.Panel2MinSize = 460;
            this.split.Size = new System.Drawing.Size(1040, 640);
            this.split.SplitterDistance = 531;
            this.split.SplitterWidth = 9;
            this.split.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvMedicines);
            this.pnlGrid.Controls.Add(this.lblStockHeader);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(16, 16);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(507, 448);
            this.pnlGrid.TabIndex = 0;
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMedicines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvMedicines.ColumnHeadersHeight = 48;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colType,
            this.colUnit,
            this.colPrice,
            this.colQty,
            this.colReorder,
            this.colExpiry});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(65)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedicines.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgvMedicines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedicines.EnableHeadersVisualStyles = false;
            this.dgvMedicines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(194)))), ((int)(((byte)(184)))));
            this.dgvMedicines.Location = new System.Drawing.Point(0, 32);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicines.Size = new System.Drawing.Size(507, 416);
            this.dgvMedicines.TabIndex = 0;
            this.dgvMedicines.SelectionChanged += new System.EventHandler(this.dgvMedicines_SelectionChanged);
            // 
            // colId
            // 
            this.colId.FillWeight = 40F;
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FillWeight = 160F;
            this.colName.HeaderText = "Medicine Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.FillWeight = 80F;
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            // 
            // colUnit
            // 
            this.colUnit.FillWeight = 110F;
            this.colUnit.HeaderText = "Unit";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            // 
            // colPrice
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle12;
            this.colPrice.FillWeight = 70F;
            this.colPrice.HeaderText = "Price (Rs.)";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colQty
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colQty.DefaultCellStyle = dataGridViewCellStyle13;
            this.colQty.FillWeight = 50F;
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colReorder
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colReorder.DefaultCellStyle = dataGridViewCellStyle14;
            this.colReorder.FillWeight = 60F;
            this.colReorder.HeaderText = "Reorder";
            this.colReorder.Name = "colReorder";
            this.colReorder.ReadOnly = true;
            // 
            // colExpiry
            // 
            this.colExpiry.FillWeight = 90F;
            this.colExpiry.HeaderText = "Expiry Date";
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.ReadOnly = true;
            // 
            // lblStockHeader
            // 
            this.lblStockHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblStockHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStockHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            this.lblStockHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblStockHeader.Location = new System.Drawing.Point(0, 0);
            this.lblStockHeader.Name = "lblStockHeader";
            this.lblStockHeader.Padding = new System.Windows.Forms.Padding(2, 4, 0, 4);
            this.lblStockHeader.Size = new System.Drawing.Size(507, 32);
            this.lblStockHeader.TabIndex = 1;
            this.lblStockHeader.Text = "Medicine Stock";
            this.lblStockHeader.TypeRole = MaterialComponents.LMaterialTypeRole.TitleMedium;
            // 
            // pnlAlerts
            // 
            this.pnlAlerts.Controls.Add(this.lstAlerts);
            this.pnlAlerts.Controls.Add(this.lblAlertsHeader);
            this.pnlAlerts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlerts.Location = new System.Drawing.Point(16, 464);
            this.pnlAlerts.Name = "pnlAlerts";
            this.pnlAlerts.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlAlerts.Size = new System.Drawing.Size(507, 160);
            this.pnlAlerts.TabIndex = 1;
            // 
            // lstAlerts
            // 
            this.lstAlerts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lstAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAlerts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstAlerts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstAlerts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lstAlerts.IntegralHeight = false;
            this.lstAlerts.ItemHeight = 40;
            this.lstAlerts.Location = new System.Drawing.Point(0, 40);
            this.lstAlerts.Name = "lstAlerts";
            this.lstAlerts.Size = new System.Drawing.Size(507, 120);
            this.lstAlerts.TabIndex = 0;
            // 
            // lblAlertsHeader
            // 
            this.lblAlertsHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblAlertsHeader.ColorRole = MaterialComponents.LMaterialColorRole.Error;
            this.lblAlertsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAlertsHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.lblAlertsHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lblAlertsHeader.Location = new System.Drawing.Point(0, 12);
            this.lblAlertsHeader.Name = "lblAlertsHeader";
            this.lblAlertsHeader.Padding = new System.Windows.Forms.Padding(2, 2, 0, 4);
            this.lblAlertsHeader.Size = new System.Drawing.Size(507, 28);
            this.lblAlertsHeader.TabIndex = 1;
            this.lblAlertsHeader.Text = "Low Stock / Near Expiry Alerts";
            this.lblAlertsHeader.TypeRole = MaterialComponents.LMaterialTypeRole.TitleSmall;
            // 
            // pnlFields
            // 
            this.pnlFields.AutoScroll = true;
            this.pnlFields.Controls.Add(this.txtDescription);
            this.pnlFields.Controls.Add(this.dtExpiry);
            this.pnlFields.Controls.Add(this.numReorder);
            this.pnlFields.Controls.Add(this.numQty);
            this.pnlFields.Controls.Add(this.numPrice);
            this.pnlFields.Controls.Add(this.cmbUnit);
            this.pnlFields.Controls.Add(this.lblUnit);
            this.pnlFields.Controls.Add(this.numAlcohol);
            this.pnlFields.Controls.Add(this.cmbType);
            this.pnlFields.Controls.Add(this.lblType);
            this.pnlFields.Controls.Add(this.txtName);
            this.pnlFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Location = new System.Drawing.Point(8, 60);
            this.pnlFields.Name = "pnlFields";
            this.pnlFields.Size = new System.Drawing.Size(476, 500);
            this.pnlFields.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.LabelText = "Description";
            this.txtDescription.Location = new System.Drawing.Point(4, 612);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(452, 120);
            this.txtDescription.TabIndex = 10;
            // 
            // dtExpiry
            // 
            this.dtExpiry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtExpiry.CustomFormat = null;
            this.dtExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiry.LabelText = "Expiry Date";
            this.dtExpiry.Location = new System.Drawing.Point(4, 520);
            this.dtExpiry.Name = "dtExpiry";
            this.dtExpiry.Size = new System.Drawing.Size(452, 84);
            this.dtExpiry.TabIndex = 9;
            this.dtExpiry.Value = new System.DateTime(2026, 9, 11, 7, 38, 51, 926);
            // 
            // numReorder
            // 
            this.numReorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numReorder.LabelText = "Reorder Level";
            this.numReorder.Location = new System.Drawing.Point(511, 426);
            this.numReorder.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numReorder.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numReorder.Name = "numReorder";
            this.numReorder.Size = new System.Drawing.Size(224, 84);
            this.numReorder.TabIndex = 8;
            this.numReorder.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numQty
            // 
            this.numQty.LabelText = "Quantity In Stock";
            this.numQty.Location = new System.Drawing.Point(6, 426);
            this.numQty.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numQty.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(450, 84);
            this.numQty.TabIndex = 7;
            this.numQty.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // numPrice
            // 
            this.numPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.LabelText = "Unit Price (Rs.)";
            this.numPrice.Location = new System.Drawing.Point(4, 332);
            this.numPrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrice.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(452, 84);
            this.numPrice.TabIndex = 6;
            this.numPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cmbUnit
            // 
            this.cmbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cmbUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cmbUnit.IntegralHeight = false;
            this.cmbUnit.ItemHeight = 36;
            this.cmbUnit.Location = new System.Drawing.Point(20, 284);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(436, 42);
            this.cmbUnit.TabIndex = 5;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblUnit.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblUnit.Location = new System.Drawing.Point(20, 262);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(29, 15);
            this.lblUnit.TabIndex = 4;
            this.lblUnit.Text = "Unit";
            this.lblUnit.TypeRole = MaterialComponents.LMaterialTypeRole.BodySmall;
            // 
            // numAlcohol
            // 
            this.numAlcohol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numAlcohol.DecimalPlaces = 2;
            this.numAlcohol.LabelText = "Alcohol Content (%)";
            this.numAlcohol.Location = new System.Drawing.Point(4, 170);
            this.numAlcohol.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAlcohol.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numAlcohol.Name = "numAlcohol";
            this.numAlcohol.Size = new System.Drawing.Size(452, 84);
            this.numAlcohol.TabIndex = 3;
            this.numAlcohol.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cmbType.IntegralHeight = false;
            this.cmbType.ItemHeight = 36;
            this.cmbType.Location = new System.Drawing.Point(20, 122);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(436, 42);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblType.Location = new System.Drawing.Point(20, 100);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 15);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Medicine Type";
            this.lblType.TypeRole = MaterialComponents.LMaterialTypeRole.BodySmall;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.LabelText = "Medicine Name";
            this.txtName.Location = new System.Drawing.Point(6, 13);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(450, 84);
            this.txtName.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnUpdate);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(8, 560);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlButtons.Size = new System.Drawing.Size(476, 64);
            this.pnlButtons.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnAdd.Location = new System.Drawing.Point(4, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnUpdate.Location = new System.Drawing.Point(116, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 40);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnDelete.Location = new System.Drawing.Point(228, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Variant = MaterialComponents.LMaterialButtonVariant.Outlined;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnClear.Location = new System.Drawing.Point(340, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 40);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.Variant = MaterialComponents.LMaterialButtonVariant.Text;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblTitle.Location = new System.Drawing.Point(8, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(2, 0, 0, 8);
            this.lblTitle.Size = new System.Drawing.Size(476, 44);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ayurvedic Medicine Inventory";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 640);
            this.Controls.Add(this.split);
            this.MinimumSize = new System.Drawing.Size(840, 620);
            this.Name = "InventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management - Ayurvedic Pharmacy";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.pnlAlerts.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private MaterialComponents.LMaterialSplitContainer split;
        private System.Windows.Forms.Panel pnlFields;
        private MaterialComponents.LMaterialLabel lblTitle;
        private MaterialComponents.LMaterialTextBox txtName;
        private MaterialComponents.LMaterialLabel lblType;
        private MaterialComponents.LMaterialComboBox cmbType;
        private MaterialComponents.LMaterialNumericUpDown numAlcohol;
        private MaterialComponents.LMaterialLabel lblUnit;
        private MaterialComponents.LMaterialComboBox cmbUnit;
        private MaterialComponents.LMaterialNumericUpDown numPrice;
        private MaterialComponents.LMaterialNumericUpDown numQty;
        private MaterialComponents.LMaterialNumericUpDown numReorder;
        private MaterialComponents.LMaterialDateTimePicker dtExpiry;
        private MaterialComponents.LMaterialTextBox txtDescription;
        private System.Windows.Forms.Panel pnlButtons;
        private MaterialComponents.LMaterialButton btnAdd;
        private MaterialComponents.LMaterialButton btnUpdate;
        private MaterialComponents.LMaterialButton btnDelete;
        private MaterialComponents.LMaterialButton btnClear;
        private System.Windows.Forms.Panel pnlGrid;
        private MaterialComponents.LMaterialDataGridView dgvMedicines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiry;
        private MaterialComponents.LMaterialLabel lblStockHeader;
        private System.Windows.Forms.Panel pnlAlerts;
        private MaterialComponents.LMaterialListBox lstAlerts;
        private MaterialComponents.LMaterialLabel lblAlertsHeader;
    }
}
