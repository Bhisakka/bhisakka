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
            lblTitle = new MaterialComponents.LMaterialLabel();

            grpTemplate = new MaterialComponents.LMaterialGroupBox();
            lblDayOfWeek = new MaterialComponents.LMaterialLabel();
            cboDayOfWeek = new MaterialComponents.LMaterialComboBox();
            lblBlockType = new MaterialComponents.LMaterialLabel();
            cboBlockType = new MaterialComponents.LMaterialComboBox();
            txtLabel = new MaterialComponents.LMaterialTextBox();
            dtpStart = new MaterialComponents.LMaterialDateTimePicker();
            dtpEnd = new MaterialComponents.LMaterialDateTimePicker();
            lblSlotDuration = new MaterialComponents.LMaterialLabel();
            cboSlotDuration = new MaterialComponents.LMaterialComboBox();
            chkIsActive = new MaterialComponents.LMaterialCheckBox();
            btnAddTemplate = new MaterialComponents.LMaterialButton();
            btnUpdateTemplate = new MaterialComponents.LMaterialButton();
            btnDeleteTemplate = new MaterialComponents.LMaterialButton();
            gridTemplates = new MaterialComponents.LMaterialDataGridView();

            grpSuddenBlock = new MaterialComponents.LMaterialGroupBox();
            dtpBlockDate = new MaterialComponents.LMaterialDateTimePicker();
            dtpBlockStart = new MaterialComponents.LMaterialDateTimePicker();
            dtpBlockEnd = new MaterialComponents.LMaterialDateTimePicker();
            txtReason = new MaterialComponents.LMaterialTextBox();
            btnAddBlock = new MaterialComponents.LMaterialButton();

            grpPreview = new MaterialComponents.LMaterialGroupBox();
            calAvailability = new MaterialComponents.LMaterialMonthCalendar();
            lblPreviewInfo = new MaterialComponents.LMaterialLabel();
            lstAvailableSlots = new MaterialComponents.LMaterialListBox();

            SuspendLayout();

            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.TypeRole = MaterialComponents.LMaterialTypeRole.HeadlineSmall;
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(900, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Doctor Schedule && Booking-Window Configuration";

            //
            // grpTemplate
            //
            grpTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpTemplate.Location = new Point(24, 66);
            grpTemplate.Padding = new Padding(16);
            grpTemplate.Name = "grpTemplate";
            grpTemplate.Size = new Size(700, 726);
            grpTemplate.TabIndex = 1;
            grpTemplate.Text = "Weekly Recurring Template";

            //
            // lblDayOfWeek
            //
            lblDayOfWeek.AutoSize = false;
            lblDayOfWeek.BackColor = Color.Transparent;
            lblDayOfWeek.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            lblDayOfWeek.Location = new Point(16, 30);
            lblDayOfWeek.Name = "lblDayOfWeek";
            lblDayOfWeek.Size = new Size(200, 20);
            lblDayOfWeek.TabIndex = 0;
            lblDayOfWeek.Text = "Day of Week";

            //
            // cboDayOfWeek
            //
            cboDayOfWeek.Location = new Point(16, 52);
            cboDayOfWeek.Name = "cboDayOfWeek";
            cboDayOfWeek.Size = new Size(300, 40);
            cboDayOfWeek.TabIndex = 1;

            //
            // lblBlockType
            //
            lblBlockType.AutoSize = false;
            lblBlockType.BackColor = Color.Transparent;
            lblBlockType.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            lblBlockType.Location = new Point(340, 30);
            lblBlockType.Name = "lblBlockType";
            lblBlockType.Size = new Size(200, 20);
            lblBlockType.TabIndex = 2;
            lblBlockType.Text = "Block Type";

            //
            // cboBlockType
            //
            cboBlockType.Location = new Point(340, 52);
            cboBlockType.Name = "cboBlockType";
            cboBlockType.Size = new Size(300, 40);
            cboBlockType.TabIndex = 3;
            cboBlockType.SelectedIndexChanged += cboBlockType_SelectedIndexChanged;

            //
            // txtLabel
            //
            txtLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLabel.Location = new Point(16, 104);
            txtLabel.LabelText = "Label";
            txtLabel.Name = "txtLabel";
            txtLabel.Size = new Size(660, 84);
            txtLabel.TabIndex = 4;

            //
            // dtpStart
            //
            dtpStart.Location = new Point(16, 194);
            dtpStart.LabelText = "Start Time";
            dtpStart.Format = DateTimePickerFormat.Time;
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(322, 84);
            dtpStart.TabIndex = 5;

            //
            // dtpEnd
            //
            dtpEnd.Location = new Point(354, 194);
            dtpEnd.LabelText = "End Time";
            dtpEnd.Format = DateTimePickerFormat.Time;
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(322, 84);
            dtpEnd.TabIndex = 6;

            //
            // lblSlotDuration
            //
            lblSlotDuration.AutoSize = false;
            lblSlotDuration.BackColor = Color.Transparent;
            lblSlotDuration.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            lblSlotDuration.Location = new Point(16, 288);
            lblSlotDuration.Name = "lblSlotDuration";
            lblSlotDuration.Size = new Size(200, 20);
            lblSlotDuration.TabIndex = 7;
            lblSlotDuration.Text = "Slot Duration (min)";

            //
            // cboSlotDuration
            //
            cboSlotDuration.Location = new Point(16, 310);
            cboSlotDuration.Name = "cboSlotDuration";
            cboSlotDuration.Size = new Size(160, 40);
            cboSlotDuration.TabIndex = 8;

            //
            // chkIsActive
            //
            chkIsActive.BackColor = Color.Transparent;
            chkIsActive.Checked = true;
            chkIsActive.Location = new Point(200, 314);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(140, 32);
            chkIsActive.TabIndex = 9;
            chkIsActive.Text = "Active";

            //
            // btnAddTemplate
            //
            btnAddTemplate.Location = new Point(16, 366);
            btnAddTemplate.Name = "btnAddTemplate";
            btnAddTemplate.Size = new Size(150, 40);
            btnAddTemplate.TabIndex = 10;
            btnAddTemplate.Text = "Add";
            btnAddTemplate.Click += btnAddTemplate_Click;

            //
            // btnUpdateTemplate
            //
            btnUpdateTemplate.Variant = MaterialComponents.LMaterialButtonVariant.Tonal;
            btnUpdateTemplate.Location = new Point(176, 366);
            btnUpdateTemplate.Name = "btnUpdateTemplate";
            btnUpdateTemplate.Size = new Size(150, 40);
            btnUpdateTemplate.TabIndex = 11;
            btnUpdateTemplate.Text = "Update";
            btnUpdateTemplate.Click += btnUpdateTemplate_Click;

            //
            // btnDeleteTemplate
            //
            btnDeleteTemplate.Variant = MaterialComponents.LMaterialButtonVariant.Outlined;
            btnDeleteTemplate.Location = new Point(336, 366);
            btnDeleteTemplate.Name = "btnDeleteTemplate";
            btnDeleteTemplate.Size = new Size(150, 40);
            btnDeleteTemplate.TabIndex = 12;
            btnDeleteTemplate.Text = "Delete";
            btnDeleteTemplate.Click += btnDeleteTemplate_Click;

            //
            // gridTemplates
            //
            gridTemplates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridTemplates.Location = new Point(16, 420);
            gridTemplates.Name = "gridTemplates";
            gridTemplates.Size = new Size(668, 288);
            gridTemplates.TabIndex = 13;
            gridTemplates.SelectionChanged += gridTemplates_SelectionChanged;

            grpTemplate.Controls.Add(lblDayOfWeek);
            grpTemplate.Controls.Add(cboDayOfWeek);
            grpTemplate.Controls.Add(lblBlockType);
            grpTemplate.Controls.Add(cboBlockType);
            grpTemplate.Controls.Add(txtLabel);
            grpTemplate.Controls.Add(dtpStart);
            grpTemplate.Controls.Add(dtpEnd);
            grpTemplate.Controls.Add(lblSlotDuration);
            grpTemplate.Controls.Add(cboSlotDuration);
            grpTemplate.Controls.Add(chkIsActive);
            grpTemplate.Controls.Add(btnAddTemplate);
            grpTemplate.Controls.Add(btnUpdateTemplate);
            grpTemplate.Controls.Add(btnDeleteTemplate);
            grpTemplate.Controls.Add(gridTemplates);

            //
            // grpSuddenBlock
            //
            grpSuddenBlock.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSuddenBlock.Location = new Point(740, 66);
            grpSuddenBlock.Padding = new Padding(16);
            grpSuddenBlock.Name = "grpSuddenBlock";
            grpSuddenBlock.Size = new Size(708, 356);
            grpSuddenBlock.TabIndex = 2;
            grpSuddenBlock.Text = "Sudden Block (One-Off Override)";

            //
            // dtpBlockDate
            //
            dtpBlockDate.Location = new Point(16, 30);
            dtpBlockDate.LabelText = "Block Date";
            dtpBlockDate.Name = "dtpBlockDate";
            dtpBlockDate.Size = new Size(330, 84);
            dtpBlockDate.TabIndex = 0;

            //
            // dtpBlockStart
            //
            dtpBlockStart.Location = new Point(16, 120);
            dtpBlockStart.LabelText = "Start Time";
            dtpBlockStart.Format = DateTimePickerFormat.Time;
            dtpBlockStart.Name = "dtpBlockStart";
            dtpBlockStart.Size = new Size(330, 84);
            dtpBlockStart.TabIndex = 1;

            //
            // dtpBlockEnd
            //
            dtpBlockEnd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpBlockEnd.Location = new Point(362, 120);
            dtpBlockEnd.LabelText = "End Time";
            dtpBlockEnd.Format = DateTimePickerFormat.Time;
            dtpBlockEnd.Name = "dtpBlockEnd";
            dtpBlockEnd.Size = new Size(330, 84);
            dtpBlockEnd.TabIndex = 2;

            //
            // txtReason
            //
            txtReason.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtReason.Location = new Point(16, 210);
            txtReason.LabelText = "Reason";
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(676, 84);
            txtReason.TabIndex = 3;

            //
            // btnAddBlock
            //
            btnAddBlock.Location = new Point(16, 302);
            btnAddBlock.Name = "btnAddBlock";
            btnAddBlock.Size = new Size(220, 40);
            btnAddBlock.TabIndex = 4;
            btnAddBlock.Text = "Add Sudden Block";
            btnAddBlock.Click += btnAddBlock_Click;

            grpSuddenBlock.Controls.Add(dtpBlockDate);
            grpSuddenBlock.Controls.Add(dtpBlockStart);
            grpSuddenBlock.Controls.Add(dtpBlockEnd);
            grpSuddenBlock.Controls.Add(txtReason);
            grpSuddenBlock.Controls.Add(btnAddBlock);

            //
            // grpPreview
            //
            grpPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpPreview.Location = new Point(740, 434);
            grpPreview.Padding = new Padding(16);
            grpPreview.Name = "grpPreview";
            grpPreview.Size = new Size(708, 358);
            grpPreview.TabIndex = 3;
            grpPreview.Text = "Booking Window Preview";

            //
            // calAvailability
            //
            calAvailability.Location = new Point(16, 34);
            calAvailability.Name = "calAvailability";
            calAvailability.Size = new Size(280, 220);
            calAvailability.TabIndex = 0;
            calAvailability.MaxSelectionCount = 1;
            calAvailability.DateSelected += calAvailability_DateSelected;

            //
            // lblPreviewInfo
            //
            lblPreviewInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPreviewInfo.AutoSize = false;
            lblPreviewInfo.BackColor = Color.Transparent;
            lblPreviewInfo.ColorRole = MaterialComponents.LMaterialColorRole.OnSurfaceVariant;
            lblPreviewInfo.Location = new Point(312, 34);
            lblPreviewInfo.Name = "lblPreviewInfo";
            lblPreviewInfo.Size = new Size(380, 220);
            lblPreviewInfo.TabIndex = 1;
            lblPreviewInfo.Text = "Select a date to preview available slots.";

            //
            // lstAvailableSlots
            //
            lstAvailableSlots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstAvailableSlots.Location = new Point(16, 266);
            lstAvailableSlots.Name = "lstAvailableSlots";
            lstAvailableSlots.Size = new Size(676, 74);
            lstAvailableSlots.TabIndex = 2;

            grpPreview.Controls.Add(calAvailability);
            grpPreview.Controls.Add(lblPreviewInfo);
            grpPreview.Controls.Add(lstAvailableSlots);

            //
            // ScheduleConfigForm
            //
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1472, 816);
            Controls.Add(lblTitle);
            Controls.Add(grpTemplate);
            Controls.Add(grpSuddenBlock);
            Controls.Add(grpPreview);
            MinimumSize = new Size(1220, 740);
            Name = "ScheduleConfigForm";
            Text = "Schedule Configuration";

            ResumeLayout(false);
            PerformLayout();
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
