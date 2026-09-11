using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;

namespace Bhisakka.UI.Pharmacy
{
    public partial class InventoryForm : LMaterialForm
    {
        private MedicineRepository medicineRepository = new MedicineRepository();
        private List<Medicine> allMedicines = new List<Medicine>();
        private Medicine selectedMedicine = null;
        private bool suppressGridEvents = false;

        public InventoryForm()
        {
            InitializeComponent();

            cmbType.Items.AddRange(MedicineFactory.AllTypes);
            cmbUnit.Items.Add("bottle (450ml)");
            cmbUnit.Items.Add("bottle (100ml)");
            cmbUnit.Items.Add("packet (100g)");
            cmbUnit.Items.Add("jar (250g)");
            cmbUnit.Items.Add("bottle (60 pills)");
            cmbUnit.Items.Add("Other");
        }

        private void InventoryForm_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadMedicines();
            LoadAlerts();
        }

        private void LoadMedicines()
        {
            try
            {
                allMedicines = medicineRepository.GetAllActive();
                PopulateGrid(allMedicines);
            }
            catch (Exception ex)
            {
                allMedicines = new List<Medicine>();
                PopulateGrid(allMedicines);
                LMaterialDialog.Show(this, "Could Not Load Inventory", "Failed to load medicines from the database.\n\n" + ex.Message);
            }
        }

        private void PopulateGrid(List<Medicine> medicines)
        {
            dgvMedicines.Rows.Clear();

            for (int i = 0; i < medicines.Count; i++)
            {
                Medicine m = medicines[i];

                string expiryText = "-";
                if (m.GetExpiryDate().HasValue)
                {
                    expiryText = m.GetExpiryDate().Value.ToString("yyyy-MM-dd");
                }

                int rowIndex = dgvMedicines.Rows.Add(m.GetMedicineId(), m.GetName(), m.GetMedicineType(), m.GetUnit(),
                    m.GetUnitPrice().ToString("N2"), m.GetQuantityInStock(), m.GetReorderLevel(), expiryText);

                dgvMedicines.Rows[rowIndex].Tag = m;
            }
        }

        private void LoadAlerts()
        {
            lstAlerts.Items.Clear();

            DataTable table;
            try
            {
                table = medicineRepository.GetLowStockAlerts();
            }
            catch (Exception ex)
            {
                lstAlerts.Items.Add("Could not load alerts: " + ex.Message);
                return;
            }

            if (table.Rows.Count == 0)
            {
                lstAlerts.Items.Add("No alerts. All stock levels and expiry dates look fine.");
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                string name = row["name"].ToString();
                string alertType = row["alert_type"].ToString();

                if (alertType == "LowStock")
                {
                    lstAlerts.Items.Add(name + " - Quantity: " + row["quantity_in_stock"] + " - Reorder Level: " + row["reorder_level"]);
                }
                else
                {
                    DateTime expiry = Convert.ToDateTime(row["expiry_date"]);
                    lstAlerts.Items.Add(name + " - Expires: " + expiry.ToString("yyyy-MM-dd"));
                }
            }
        }

        private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
            if (suppressGridEvents)
            {
                return;
            }
            if (dgvMedicines.CurrentRow == null)
            {
                return;
            }
            if (dgvMedicines.CurrentRow.Tag == null)
            {
                return;
            }

            Medicine m = (Medicine)dgvMedicines.CurrentRow.Tag;
            LoadIntoForm(m);
        }

        private void LoadIntoForm(Medicine m)
        {
            selectedMedicine = m;

            txtName.Text = m.GetName();
            cmbType.SelectedItem = m.GetMedicineType();
            SelectOrAddUnit(m.GetUnit());
            numPrice.Value = m.GetUnitPrice();
            numQty.Value = m.GetQuantityInStock();
            numReorder.Value = m.GetReorderLevel();

            if (m.GetExpiryDate().HasValue)
            {
                dtExpiry.Value = m.GetExpiryDate().Value;
            }
            else
            {
                dtExpiry.Value = DateTime.Today.AddYears(1);
            }

            decimal alcoholValue = 0;
            Arishta arishta = m as Arishta;
            if (arishta != null && arishta.GetAlcoholContent().HasValue)
            {
                alcoholValue = arishta.GetAlcoholContent().Value;
            }
            numAlcohol.Value = alcoholValue;

            if (m.GetDescription() != null)
            {
                txtDescription.Text = m.GetDescription();
            }
            else
            {
                txtDescription.Text = "";
            }

            txtName.IsError = false;
            numAlcohol.IsError = false;

            SetIdentityFieldsEnabled(false);
            UpdateAlcoholVisibility();

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void SelectOrAddUnit(string unit)
        {
            if (!cmbUnit.Items.Contains(unit))
            {
                cmbUnit.Items.Add(unit);
            }
            cmbUnit.SelectedItem = unit;
        }

        private void ResetForm()
        {
            selectedMedicine = null;

            suppressGridEvents = true;
            dgvMedicines.ClearSelection();
            suppressGridEvents = false;

            txtName.Text = "";
            txtName.IsError = false;
            cmbType.SelectedIndex = 0;
            numAlcohol.Value = 0;
            numAlcohol.IsError = false;

            if (cmbUnit.Items.Count > 0)
            {
                cmbUnit.SelectedIndex = 0;
            }

            numPrice.Value = 0;
            numQty.Value = 0;
            numReorder.Value = 10;
            dtExpiry.Value = DateTime.Today.AddYears(1);
            txtDescription.Text = "";

            SetIdentityFieldsEnabled(true);
            UpdateAlcoholVisibility();

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void SetIdentityFieldsEnabled(bool enabled)
        {
            txtName.Enabled = enabled;
            cmbType.Enabled = enabled;
            cmbUnit.Enabled = enabled;
            numAlcohol.Enabled = enabled;
            txtDescription.Enabled = enabled;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAlcoholVisibility();
        }

        private void UpdateAlcoholVisibility()
        {
            bool isArishta = false;
            if (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() == "Arishta")
            {
                isArishta = true;
            }
            numAlcohol.Visible = isArishta;
        }

        private bool ValidateForm()
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.IsError = true;
                txtName.ErrorText = "Medicine name is required.";
                valid = false;
            }
            else
            {
                txtName.IsError = false;
            }

            bool isArishta = false;
            if (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() == "Arishta")
            {
                isArishta = true;
            }

            if (isArishta && numAlcohol.Value <= 0)
            {
                numAlcohol.IsError = true;
                numAlcohol.ErrorText = "Enter the alcohol content for an Arishta.";
                valid = false;
            }
            else
            {
                numAlcohol.IsError = false;
            }

            return valid;
        }

        private Medicine BuildNewMedicineFromForm()
        {
            Medicine medicine = MedicineFactory.Create(cmbType.SelectedItem.ToString());
            medicine.SetName(txtName.Text.Trim());

            if (cmbUnit.SelectedItem != null)
            {
                medicine.SetUnit(cmbUnit.SelectedItem.ToString());
            }
            else
            {
                medicine.SetUnit(cmbUnit.Text);
            }

            medicine.SetUnitPrice(numPrice.Value);
            medicine.SetQuantityInStock((int)numQty.Value);
            medicine.SetReorderLevel((int)numReorder.Value);
            medicine.SetExpiryDate(dtExpiry.Value.Date);

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                medicine.SetDescription(null);
            }
            else
            {
                medicine.SetDescription(txtDescription.Text.Trim());
            }

            Arishta arishta = medicine as Arishta;
            if (arishta != null)
            {
                arishta.SetAlcoholContent(numAlcohol.Value);
            }

            return medicine;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
            {
                return;
            }

            try
            {
                Medicine medicine = BuildNewMedicineFromForm();
                medicineRepository.Insert(medicine);
                LMaterialSnackbar.Show(this, "'" + medicine.GetName() + "' added to inventory.");
                LoadMedicines();
                LoadAlerts();
                ResetForm();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate key"))
                {
                    txtName.IsError = true;
                    txtName.ErrorText = "A medicine with this name already exists.";
                }
                else
                {
                    LMaterialDialog.Show(this, "Save Failed", ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMedicine == null)
            {
                return;
            }

            try
            {
                selectedMedicine.SetUnitPrice(numPrice.Value);
                selectedMedicine.SetQuantityInStock((int)numQty.Value);
                selectedMedicine.SetReorderLevel((int)numReorder.Value);
                selectedMedicine.SetExpiryDate(dtExpiry.Value.Date);

                medicineRepository.Update(selectedMedicine);
                LMaterialSnackbar.Show(this, "'" + selectedMedicine.GetName() + "' updated.");
                LoadMedicines();
                LoadAlerts();
                ResetForm();
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Update Failed", ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMedicine == null)
            {
                return;
            }

            DialogResult result = LMaterialDialog.Show(this, "Deactivate Medicine",
                "Deactivate '" + selectedMedicine.GetName() + "'? It will be hidden from active inventory, " +
                "but past invoices and prescriptions will still reference it.",
                "Deactivate", "Cancel");

            if (result != DialogResult.OK)
            {
                return;
            }

            try
            {
                medicineRepository.SoftDelete(selectedMedicine.GetMedicineId());
                LMaterialSnackbar.Show(this, "Medicine deactivated.");
                LoadMedicines();
                LoadAlerts();
                ResetForm();
            }
            catch (Exception ex)
            {
                LMaterialDialog.Show(this, "Delete Failed", ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
