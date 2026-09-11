using Bhisakka.DataAccess;
using Bhisakka.Models;
using Bhisakka.Services;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bhisakka.UI.Scheduling
{
    public partial class ScheduleConfigForm : LMaterialForm
    {
        private static readonly string[] DayNames = new string[]
        {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        };

        private ScheduleRepository scheduleRepository;
        private ScheduleManager scheduleManager;
        private int? selectedTemplateId;

        public ScheduleConfigForm()
        {
            InitializeComponent();

            scheduleRepository = new ScheduleRepository();
            scheduleManager = new ScheduleManager();
            selectedTemplateId = null;

            SetupTimePickers();
            SetupDayOfWeekCombo();
            SetupBlockTypeCombo();
            SetupSlotDurationCombo();
            SetupTemplateGridColumns();
            SetupCalendarWindow();

            LoadTemplatesGrid();
            RefreshAvailablePreview(DateTime.Today);
        }

        private void SetupTimePickers()
        {
            dtpStart.InnerDateTimePicker.ShowUpDown = true;
            dtpEnd.InnerDateTimePicker.ShowUpDown = true;
            dtpBlockStart.InnerDateTimePicker.ShowUpDown = true;
            dtpBlockEnd.InnerDateTimePicker.ShowUpDown = true;
        }

        private void SetupDayOfWeekCombo()
        {
            cboDayOfWeek.Items.Clear();
            cboDayOfWeek.Items.AddRange(DayNames);
            cboDayOfWeek.SelectedIndex = 0;
        }

        private void SetupBlockTypeCombo()
        {
            cboBlockType.Items.Clear();
            cboBlockType.Items.AddRange(new object[] { "Consultation", "Break" });
            cboBlockType.SelectedIndex = 0;
        }

        private void SetupSlotDurationCombo()
        {
            cboSlotDuration.Items.Clear();
            cboSlotDuration.Items.AddRange(new object[] { "15", "30" });
            cboSlotDuration.SelectedIndex = 0;
        }

        private void SetupTemplateGridColumns()
        {
            gridTemplates.AutoGenerateColumns = false;
            gridTemplates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridTemplates.MultiSelect = false;
            gridTemplates.ReadOnly = true;
            gridTemplates.AllowUserToAddRows = false;
            gridTemplates.RowHeadersVisible = false;
            gridTemplates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridTemplates.Columns.Clear();

            gridTemplates.Columns.Add(MakeColumn("colTemplateId", "ID"));
            gridTemplates.Columns.Add(MakeColumn("colDayOfWeek", "Day"));
            gridTemplates.Columns.Add(MakeColumn("colBlockType", "Type"));
            gridTemplates.Columns.Add(MakeColumn("colLabel", "Label"));
            gridTemplates.Columns.Add(MakeColumn("colStartTime", "Start"));
            gridTemplates.Columns.Add(MakeColumn("colEndTime", "End"));
            gridTemplates.Columns.Add(MakeColumn("colSlotDuration", "Slot (min)"));
            gridTemplates.Columns.Add(MakeColumn("colIsActive", "Active"));
        }

        private DataGridViewTextBoxColumn MakeColumn(string name, string header)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.Name = name;
            column.HeaderText = header;
            column.ReadOnly = true;
            return column;
        }

        private void SetupCalendarWindow()
        {
            int windowDays = scheduleManager.GetBookingWindowDays();

            calAvailability.MinDate = DateTime.Today;
            calAvailability.MaxDate = DateTime.Today.AddDays(windowDays);
            calAvailability.SetDate(DateTime.Today);

            lblPreviewInfo.Text = "Booking window: today .. today + " + windowDays.ToString() +
                " day(s). Select a date on the calendar to preview available slots.";
        }

        private void LoadTemplatesGrid()
        {
            gridTemplates.Rows.Clear();

            List<ScheduleTemplate> templates = scheduleRepository.GetAllTemplates();

            for (int i = 0; i < templates.Count; i++)
            {
                ScheduleTemplate template = templates[i];

                string dayName;
                if (template.GetDayOfWeek() >= 0 && template.GetDayOfWeek() <= 6)
                {
                    dayName = DayNames[template.GetDayOfWeek()];
                }
                else
                {
                    dayName = template.GetDayOfWeek().ToString();
                }

                string slotText;
                if (template.GetSlotDurationMinutes().HasValue)
                {
                    slotText = template.GetSlotDurationMinutes().Value.ToString();
                }
                else
                {
                    slotText = "-";
                }

                int rowIndex = gridTemplates.Rows.Add();
                DataGridViewRow row = gridTemplates.Rows[rowIndex];
                row.Cells["colTemplateId"].Value = template.GetTemplateId();
                row.Cells["colDayOfWeek"].Value = dayName;
                row.Cells["colBlockType"].Value = template.GetBlockType();
                row.Cells["colLabel"].Value = template.GetLabel();
                row.Cells["colStartTime"].Value = template.GetStartTime().ToString(@"hh\:mm");
                row.Cells["colEndTime"].Value = template.GetEndTime().ToString(@"hh\:mm");
                row.Cells["colSlotDuration"].Value = slotText;
                row.Cells["colIsActive"].Value = template.GetIsActive() ? "Yes" : "No";
            }
        }

        private void cboBlockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isBreak = cboBlockType.SelectedItem != null &&
                string.Equals(cboBlockType.SelectedItem.ToString(), "Break", StringComparison.Ordinal);

            cboSlotDuration.Enabled = !isBreak;
        }

        private void gridTemplates_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTemplates.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = gridTemplates.SelectedRows[0];
            object idValue = row.Cells["colTemplateId"].Value;

            if (idValue == null)
            {
                return;
            }

            selectedTemplateId = Convert.ToInt32(idValue);

            string dayName = Convert.ToString(row.Cells["colDayOfWeek"].Value);
            int dayIndex = Array.IndexOf(DayNames, dayName);
            if (dayIndex >= 0)
            {
                cboDayOfWeek.SelectedIndex = dayIndex;
            }

            string blockType = Convert.ToString(row.Cells["colBlockType"].Value);
            int typeIndex = cboBlockType.Items.IndexOf(blockType);
            if (typeIndex >= 0)
            {
                cboBlockType.SelectedIndex = typeIndex;
            }

            txtLabel.Text = Convert.ToString(row.Cells["colLabel"].Value);

            TimeSpan startParsed;
            if (TimeSpan.TryParse(Convert.ToString(row.Cells["colStartTime"].Value), out startParsed))
            {
                dtpStart.Value = DateTime.Today.Add(startParsed);
            }

            TimeSpan endParsed;
            if (TimeSpan.TryParse(Convert.ToString(row.Cells["colEndTime"].Value), out endParsed))
            {
                dtpEnd.Value = DateTime.Today.Add(endParsed);
            }

            string slotText = Convert.ToString(row.Cells["colSlotDuration"].Value);
            int slotIndex = cboSlotDuration.Items.IndexOf(slotText);
            if (slotIndex >= 0)
            {
                cboSlotDuration.SelectedIndex = slotIndex;
            }

            chkIsActive.Checked = string.Equals(Convert.ToString(row.Cells["colIsActive"].Value), "Yes", StringComparison.Ordinal);
        }

        private bool TryBuildTemplateFromForm(int templateIdForBuild, out ScheduleTemplate template, out string error)
        {
            template = null;
            error = "";

            if (cboDayOfWeek.SelectedIndex < 0)
            {
                error = "Please select a day of week.";
                return false;
            }

            if (cboBlockType.SelectedItem == null)
            {
                error = "Please select a block type.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLabel.Text))
            {
                error = "Please enter a label.";
                return false;
            }

            TimeSpan startTime = dtpStart.Value.TimeOfDay;
            TimeSpan endTime = dtpEnd.Value.TimeOfDay;

            if (endTime <= startTime)
            {
                error = "End time must be after start time.";
                return false;
            }

            string blockType = cboBlockType.SelectedItem.ToString();
            int? slotDuration = null;

            if (string.Equals(blockType, "Consultation", StringComparison.Ordinal))
            {
                if (cboSlotDuration.SelectedItem == null)
                {
                    error = "Please select a slot duration for a Consultation block.";
                    return false;
                }

                int parsedDuration;
                if (!int.TryParse(cboSlotDuration.SelectedItem.ToString(), out parsedDuration))
                {
                    error = "Invalid slot duration.";
                    return false;
                }

                slotDuration = parsedDuration;
            }

            template = new ScheduleTemplate(
                templateIdForBuild,
                cboDayOfWeek.SelectedIndex,
                blockType,
                txtLabel.Text.Trim(),
                startTime,
                endTime,
                slotDuration,
                chkIsActive.Checked);

            return true;
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            ScheduleTemplate template;
            string error;

            if (!TryBuildTemplateFromForm(0, out template, out error))
            {
                LMaterialDialog.Show(this, "Invalid Template", error);
                return;
            }

            scheduleRepository.InsertTemplate(template);
            LoadTemplatesGrid();
            LMaterialDialog.Show(this, "Template Added", "The schedule template has been added.");
        }

        private void btnUpdateTemplate_Click(object sender, EventArgs e)
        {
            if (!selectedTemplateId.HasValue)
            {
                LMaterialDialog.Show(this, "No Template Selected", "Please select a template row in the grid first.");
                return;
            }

            ScheduleTemplate template;
            string error;

            if (!TryBuildTemplateFromForm(selectedTemplateId.Value, out template, out error))
            {
                LMaterialDialog.Show(this, "Invalid Template", error);
                return;
            }

            scheduleRepository.UpdateTemplate(template);
            LoadTemplatesGrid();
            LMaterialDialog.Show(this, "Template Updated", "The schedule template has been updated.");
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            if (!selectedTemplateId.HasValue)
            {
                LMaterialDialog.Show(this, "No Template Selected", "Please select a template row in the grid first.");
                return;
            }

            scheduleRepository.DeleteTemplate(selectedTemplateId.Value);
            selectedTemplateId = null;
            LoadTemplatesGrid();
            LMaterialDialog.Show(this, "Template Deleted", "The schedule template has been deleted.");
        }

        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtReason.Text))
            {
                LMaterialDialog.Show(this, "Missing Reason", "Please enter a reason for the sudden block.");
                return;
            }

            TimeSpan startTime = dtpBlockStart.Value.TimeOfDay;
            TimeSpan endTime = dtpBlockEnd.Value.TimeOfDay;

            if (endTime <= startTime)
            {
                LMaterialDialog.Show(this, "Invalid Time Range", "End time must be after start time.");
                return;
            }

            User currentUser = GlobalSession.GetCurrentUser();
            if (currentUser == null)
            {
                LMaterialDialog.Show(this, "Not Signed In", "You must be signed in to add a sudden block.");
                return;
            }

            BlockedSlot blockedSlot = new BlockedSlot(
                0,
                dtpBlockDate.Value.Date,
                startTime,
                endTime,
                txtReason.Text.Trim(),
                currentUser.GetUserID());

            scheduleRepository.InsertBlockedSlot(blockedSlot);

            LMaterialDialog.Show(this, "Block Added", "The sudden block has been added for " + dtpBlockDate.Value.ToShortDateString() + ".");

            if (calAvailability.SelectionStart.Date == dtpBlockDate.Value.Date)
            {
                RefreshAvailablePreview(dtpBlockDate.Value.Date);
            }
        }

        private void calAvailability_DateSelected(object sender, DateRangeEventArgs e)
        {
            RefreshAvailablePreview(e.Start.Date);
        }

        private void RefreshAvailablePreview(DateTime date)
        {
            lstAvailableSlots.Items.Clear();

            List<TimeSlot> slots = scheduleManager.GetAvailableSlots(date);

            if (slots.Count == 0)
            {
                lstAvailableSlots.Items.Add("No available slots for " + date.ToShortDateString() + ".");
                return;
            }

            for (int i = 0; i < slots.Count; i++)
            {
                lstAvailableSlots.Items.Add(slots[i].ToString());
            }
        }
    }
}
