using System.Drawing;
using System.Windows.Forms;

namespace Bhisakka.UI.Scheduling
{
    partial class ScheduleConfigForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleConfigForm));
            this.lblTitle = new MaterialComponents.LMaterialLabel();
            this.grpTemplate = new MaterialComponents.LMaterialGroupBox();
            this.lblDayOfWeek = new MaterialComponents.LMaterialLabel();
            this.cboDayOfWeek = new MaterialComponents.LMaterialComboBox();
            this.lblBlockType = new MaterialComponents.LMaterialLabel();
            this.cboBlockType = new MaterialComponents.LMaterialComboBox();
            this.txtLabel = new MaterialComponents.LMaterialTextBox();
            this.dtpStart = new MaterialComponents.LMaterialDateTimePicker();
            this.dtpEnd = new MaterialComponents.LMaterialDateTimePicker();
            this.lblSlotDuration = new MaterialComponents.LMaterialLabel();
            this.cboSlotDuration = new MaterialComponents.LMaterialComboBox();
            this.chkIsActive = new MaterialComponents.LMaterialCheckBox();
            this.btnAddTemplate = new MaterialComponents.LMaterialButton();
            this.btnUpdateTemplate = new MaterialComponents.LMaterialButton();
            this.btnDeleteTemplate = new MaterialComponents.LMaterialButton();
            this.gridTemplates = new MaterialComponents.LMaterialDataGridView();
            this.grpSuddenBlock = new MaterialComponents.LMaterialGroupBox();
            this.dtpBlockDate = new MaterialComponents.LMaterialDateTimePicker();
            this.dtpBlockStart = new MaterialComponents.LMaterialDateTimePicker();
            this.dtpBlockEnd = new MaterialComponents.LMaterialDateTimePicker();
            this.txtReason = new MaterialComponents.LMaterialTextBox();
            this.btnAddBlock = new MaterialComponents.LMaterialButton();
            this.grpPreview = new MaterialComponents.LMaterialGroupBox();
            this.calAvailability = new MaterialComponents.LMaterialMonthCalendar();
            this.lblPreviewInfo = new MaterialComponents.LMaterialLabel();
            this.lstAvailableSlots = new MaterialComponents.LMaterialListBox();
            this.grpTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTemplates)).BeginInit();
            this.grpSuddenBlock.SuspendLayout();
            this.grpPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Doctor Schedule && Booking-Window Configuration";
            this.lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            // 
            // grpTemplate
            // 
            this.grpTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpTemplate.Controls.Add(this.lblDayOfWeek);
            this.grpTemplate.Controls.Add(this.cboDayOfWeek);
            this.grpTemplate.Controls.Add(this.lblBlockType);
            this.grpTemplate.Controls.Add(this.cboBlockType);
            this.grpTemplate.Controls.Add(this.txtLabel);
            this.grpTemplate.Controls.Add(this.dtpStart);
            this.grpTemplate.Controls.Add(this.dtpEnd);
            this.grpTemplate.Controls.Add(this.lblSlotDuration);
            this.grpTemplate.Controls.Add(this.cboSlotDuration);
            this.grpTemplate.Controls.Add(this.chkIsActive);
            this.grpTemplate.Controls.Add(this.btnAddTemplate);
            this.grpTemplate.Controls.Add(this.btnUpdateTemplate);
            this.grpTemplate.Controls.Add(this.btnDeleteTemplate);
            this.grpTemplate.Controls.Add(this.gridTemplates);
            this.grpTemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpTemplate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpTemplate.Location = new System.Drawing.Point(24, 66);
            this.grpTemplate.Name = "grpTemplate";
            this.grpTemplate.Padding = new System.Windows.Forms.Padding(16);
            this.grpTemplate.Size = new System.Drawing.Size(700, 726);
            this.grpTemplate.TabIndex = 1;
            this.grpTemplate.TabStop = false;
            this.grpTemplate.Text = "Weekly Recurring Template";
            // 
            // lblDayOfWeek
            // 
            this.lblDayOfWeek.BackColor = System.Drawing.Color.Transparent;
            this.lblDayOfWeek.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblDayOfWeek.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblDayOfWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblDayOfWeek.Location = new System.Drawing.Point(16, 30);
            this.lblDayOfWeek.Name = "lblDayOfWeek";
            this.lblDayOfWeek.Size = new System.Drawing.Size(200, 20);
            this.lblDayOfWeek.TabIndex = 0;
            this.lblDayOfWeek.Text = "Day of Week";
            // 
            // cboDayOfWeek
            // 
            this.cboDayOfWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboDayOfWeek.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDayOfWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDayOfWeek.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboDayOfWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboDayOfWeek.IntegralHeight = false;
            this.cboDayOfWeek.ItemHeight = 36;
            this.cboDayOfWeek.Location = new System.Drawing.Point(16, 52);
            this.cboDayOfWeek.Name = "cboDayOfWeek";
            this.cboDayOfWeek.Size = new System.Drawing.Size(300, 42);
            this.cboDayOfWeek.TabIndex = 1;
            // 
            // lblBlockType
            // 
            this.lblBlockType.BackColor = System.Drawing.Color.Transparent;
            this.lblBlockType.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblBlockType.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblBlockType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblBlockType.Location = new System.Drawing.Point(340, 30);
            this.lblBlockType.Name = "lblBlockType";
            this.lblBlockType.Size = new System.Drawing.Size(200, 20);
            this.lblBlockType.TabIndex = 2;
            this.lblBlockType.Text = "Block Type";
            // 
            // cboBlockType
            // 
            this.cboBlockType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboBlockType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBlockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBlockType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBlockType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboBlockType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboBlockType.IntegralHeight = false;
            this.cboBlockType.ItemHeight = 36;
            this.cboBlockType.Location = new System.Drawing.Point(340, 52);
            this.cboBlockType.Name = "cboBlockType";
            this.cboBlockType.Size = new System.Drawing.Size(300, 42);
            this.cboBlockType.TabIndex = 3;
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLabel.Location = new System.Drawing.Point(16, 104);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(660, 84);
            this.txtLabel.TabIndex = 4;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = null;
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStart.LabelText = "Start Time";
            this.dtpStart.Location = new System.Drawing.Point(16, 194);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(322, 84);
            this.dtpStart.TabIndex = 5;
            this.dtpStart.Value = new System.DateTime(2026, 9, 11, 13, 31, 35, 511);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = null;
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.LabelText = "End Time";
            this.dtpEnd.Location = new System.Drawing.Point(354, 194);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(322, 84);
            this.dtpEnd.TabIndex = 6;
            this.dtpEnd.Value = new System.DateTime(2026, 9, 11, 13, 31, 35, 512);
            // 
            // lblSlotDuration
            // 
            this.lblSlotDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblSlotDuration.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblSlotDuration.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSlotDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblSlotDuration.Location = new System.Drawing.Point(16, 288);
            this.lblSlotDuration.Name = "lblSlotDuration";
            this.lblSlotDuration.Size = new System.Drawing.Size(200, 20);
            this.lblSlotDuration.TabIndex = 7;
            this.lblSlotDuration.Text = "Slot Duration (min)";
            // 
            // cboSlotDuration
            // 
            this.cboSlotDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(234)))), ((int)(((byte)(226)))));
            this.cboSlotDuration.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSlotDuration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSlotDuration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSlotDuration.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboSlotDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.cboSlotDuration.IntegralHeight = false;
            this.cboSlotDuration.ItemHeight = 36;
            this.cboSlotDuration.Location = new System.Drawing.Point(16, 310);
            this.cboSlotDuration.Name = "cboSlotDuration";
            this.cboSlotDuration.Size = new System.Drawing.Size(160, 42);
            this.cboSlotDuration.TabIndex = 8;
            // 
            // chkIsActive
            // 
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.chkIsActive.Location = new System.Drawing.Point(200, 314);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(140, 32);
            this.chkIsActive.TabIndex = 9;
            this.chkIsActive.Text = "Active";
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // btnAddTemplate
            // 
            this.btnAddTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnAddTemplate.Location = new System.Drawing.Point(16, 366);
            this.btnAddTemplate.Name = "btnAddTemplate";
            this.btnAddTemplate.Size = new System.Drawing.Size(150, 40);
            this.btnAddTemplate.TabIndex = 10;
            this.btnAddTemplate.Text = "Add";
            // 
            // btnUpdateTemplate
            // 
            this.btnUpdateTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnUpdateTemplate.Location = new System.Drawing.Point(176, 366);
            this.btnUpdateTemplate.Name = "btnUpdateTemplate";
            this.btnUpdateTemplate.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateTemplate.TabIndex = 11;
            this.btnUpdateTemplate.Text = "Update";
            this.btnUpdateTemplate.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTemplate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnDeleteTemplate.Location = new System.Drawing.Point(336, 366);
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteTemplate.TabIndex = 12;
            this.btnDeleteTemplate.Text = "Delete";
            this.btnDeleteTemplate.Variant = MaterialComponents.LMaterialButtonVariant.Outlined;
            // 
            // gridTemplates
            // 
            this.gridTemplates.AllowUserToAddRows = false;
            this.gridTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTemplates.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.gridTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridTemplates.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gridTemplates.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridTemplates.ColumnHeadersHeight = 48;
            this.gridTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(219)))), ((int)(((byte)(200)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(65)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTemplates.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridTemplates.EnableHeadersVisualStyles = false;
            this.gridTemplates.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(194)))), ((int)(((byte)(184)))));
            this.gridTemplates.Location = new System.Drawing.Point(16, 420);
            this.gridTemplates.Name = "gridTemplates";
            this.gridTemplates.RowHeadersVisible = false;
            this.gridTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTemplates.Size = new System.Drawing.Size(668, 288);
            this.gridTemplates.TabIndex = 13;
            // 
            // grpSuddenBlock
            // 
            this.grpSuddenBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSuddenBlock.Controls.Add(this.dtpBlockDate);
            this.grpSuddenBlock.Controls.Add(this.dtpBlockStart);
            this.grpSuddenBlock.Controls.Add(this.dtpBlockEnd);
            this.grpSuddenBlock.Controls.Add(this.txtReason);
            this.grpSuddenBlock.Controls.Add(this.btnAddBlock);
            this.grpSuddenBlock.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpSuddenBlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpSuddenBlock.Location = new System.Drawing.Point(740, 66);
            this.grpSuddenBlock.Name = "grpSuddenBlock";
            this.grpSuddenBlock.Padding = new System.Windows.Forms.Padding(16);
            this.grpSuddenBlock.Size = new System.Drawing.Size(708, 356);
            this.grpSuddenBlock.TabIndex = 2;
            this.grpSuddenBlock.TabStop = false;
            this.grpSuddenBlock.Text = "Sudden Block (One-Off Override)";
            // 
            // dtpBlockDate
            // 
            this.dtpBlockDate.CustomFormat = null;
            this.dtpBlockDate.LabelText = "Block Date";
            this.dtpBlockDate.Location = new System.Drawing.Point(16, 30);
            this.dtpBlockDate.Name = "dtpBlockDate";
            this.dtpBlockDate.Size = new System.Drawing.Size(330, 84);
            this.dtpBlockDate.TabIndex = 0;
            this.dtpBlockDate.Value = new System.DateTime(2026, 9, 11, 13, 31, 35, 515);
            // 
            // dtpBlockStart
            // 
            this.dtpBlockStart.CustomFormat = null;
            this.dtpBlockStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBlockStart.LabelText = "Start Time";
            this.dtpBlockStart.Location = new System.Drawing.Point(16, 120);
            this.dtpBlockStart.Name = "dtpBlockStart";
            this.dtpBlockStart.Size = new System.Drawing.Size(330, 84);
            this.dtpBlockStart.TabIndex = 1;
            this.dtpBlockStart.Value = new System.DateTime(2026, 9, 11, 13, 31, 35, 517);
            // 
            // dtpBlockEnd
            // 
            this.dtpBlockEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpBlockEnd.CustomFormat = null;
            this.dtpBlockEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBlockEnd.LabelText = "End Time";
            this.dtpBlockEnd.Location = new System.Drawing.Point(362, 120);
            this.dtpBlockEnd.Name = "dtpBlockEnd";
            this.dtpBlockEnd.Size = new System.Drawing.Size(330, 84);
            this.dtpBlockEnd.TabIndex = 2;
            this.dtpBlockEnd.Value = new System.DateTime(2026, 9, 11, 13, 31, 35, 519);
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.LabelText = "Reason";
            this.txtReason.Location = new System.Drawing.Point(16, 210);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(676, 84);
            this.txtReason.TabIndex = 3;
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBlock.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.btnAddBlock.Location = new System.Drawing.Point(16, 302);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(220, 40);
            this.btnAddBlock.TabIndex = 4;
            this.btnAddBlock.Text = "Add Sudden Block";
            // 
            // grpPreview
            // 
            this.grpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreview.Controls.Add(this.calAvailability);
            this.grpPreview.Controls.Add(this.lblPreviewInfo);
            this.grpPreview.Controls.Add(this.lstAvailableSlots);
            this.grpPreview.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F);
            this.grpPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.grpPreview.Location = new System.Drawing.Point(740, 434);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Padding = new System.Windows.Forms.Padding(16);
            this.grpPreview.Size = new System.Drawing.Size(708, 358);
            this.grpPreview.TabIndex = 3;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Booking Window Preview";
            // 
            // calAvailability
            // 
            this.calAvailability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(229)))), ((int)(((byte)(221)))));
            this.calAvailability.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.calAvailability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.calAvailability.Location = new System.Drawing.Point(16, 34);
            this.calAvailability.MaxSelectionCount = 1;
            this.calAvailability.Name = "calAvailability";
            this.calAvailability.TabIndex = 0;
            this.calAvailability.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(79)))), ((int)(((byte)(39)))));
            this.calAvailability.TitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.calAvailability.TrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            // 
            // lblPreviewInfo
            // 
            this.lblPreviewInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreviewInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPreviewInfo.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            this.lblPreviewInfo.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblPreviewInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(68)))), ((int)(((byte)(60)))));
            this.lblPreviewInfo.Location = new System.Drawing.Point(312, 34);
            this.lblPreviewInfo.Name = "lblPreviewInfo";
            this.lblPreviewInfo.Size = new System.Drawing.Size(380, 220);
            this.lblPreviewInfo.TabIndex = 1;
            this.lblPreviewInfo.Text = "Select a date to preview available slots.";
            // 
            // lstAvailableSlots
            // 
            this.lstAvailableSlots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableSlots.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(241)))), ((int)(((byte)(234)))));
            this.lstAvailableSlots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAvailableSlots.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstAvailableSlots.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstAvailableSlots.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(26)))), ((int)(((byte)(21)))));
            this.lstAvailableSlots.IntegralHeight = false;
            this.lstAvailableSlots.ItemHeight = 40;
            this.lstAvailableSlots.Location = new System.Drawing.Point(16, 266);
            this.lstAvailableSlots.Name = "lstAvailableSlots";
            this.lstAvailableSlots.Size = new System.Drawing.Size(676, 74);
            this.lstAvailableSlots.TabIndex = 2;
            // 
            // ScheduleConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 816);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpTemplate);
            this.Controls.Add(this.grpSuddenBlock);
            this.Controls.Add(this.grpPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1220, 740);
            this.Name = "ScheduleConfigForm";
            this.Text = "Schedule Configuration";
            this.grpTemplate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTemplates)).EndInit();
            this.grpSuddenBlock.ResumeLayout(false);
            this.grpPreview.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialComponents.LMaterialLabel lblTitle;

        private MaterialComponents.LMaterialGroupBox grpTemplate;
        private MaterialComponents.LMaterialLabel lblDayOfWeek;
        private MaterialComponents.LMaterialComboBox cboDayOfWeek;
        private MaterialComponents.LMaterialLabel lblBlockType;
        private MaterialComponents.LMaterialComboBox cboBlockType;
        private MaterialComponents.LMaterialTextBox txtLabel;
        private MaterialComponents.LMaterialDateTimePicker dtpStart;
        private MaterialComponents.LMaterialDateTimePicker dtpEnd;
        private MaterialComponents.LMaterialLabel lblSlotDuration;
        private MaterialComponents.LMaterialComboBox cboSlotDuration;
        private MaterialComponents.LMaterialCheckBox chkIsActive;
        private MaterialComponents.LMaterialButton btnAddTemplate;
        private MaterialComponents.LMaterialButton btnUpdateTemplate;
        private MaterialComponents.LMaterialButton btnDeleteTemplate;
        private MaterialComponents.LMaterialDataGridView gridTemplates;

        private MaterialComponents.LMaterialGroupBox grpSuddenBlock;
        private MaterialComponents.LMaterialDateTimePicker dtpBlockDate;
        private MaterialComponents.LMaterialDateTimePicker dtpBlockStart;
        private MaterialComponents.LMaterialDateTimePicker dtpBlockEnd;
        private MaterialComponents.LMaterialTextBox txtReason;
        private MaterialComponents.LMaterialButton btnAddBlock;

        private MaterialComponents.LMaterialGroupBox grpPreview;
        private MaterialComponents.LMaterialMonthCalendar calAvailability;
        private MaterialComponents.LMaterialLabel lblPreviewInfo;
        private MaterialComponents.LMaterialListBox lstAvailableSlots;
    }
}
