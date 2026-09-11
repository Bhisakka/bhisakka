using Bhisakka.DataAccess;
using Bhisakka.Models;
using MaterialComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Bhisakka.UI.Billing
{
    public partial class InvoiceGenerationForm : Form
    {
        private readonly InvoiceRepository invoiceRepository;
        private readonly AppointmentRepository appointmentRepository;
        private readonly MedicineRepository medicineRepository;

        private int patientIdSelected;
        private int consultationIdSelected;   // 0 == walk-in / pharmacy sale
        private decimal consultationFeeSelected;

        private List<Medicine> activeMedicines;
        private List<int> currentPrescriptionIds;
        private DataTable cartTable;

        private const string WalkInText = "-- No consultation (walk-in / pharmacy sale) --";
        private const string NoMedicineText = "-- No medicine selected --";

        private sealed class MedicineChoice
        {
            private readonly Medicine medicine;

            public MedicineChoice(Medicine medicine)
            {
                this.medicine = medicine;
            }

            public Medicine GetMedicine()
            {
                return medicine;
            }

            public override string ToString()
            {
                return medicine.GetName() + " -- " + medicine.GetMedicineType() + " -- " + medicine.GetUnit();
            }
        }

        public InvoiceGenerationForm()
        {
            InitializeComponent();

            invoiceRepository = new InvoiceRepository();
            appointmentRepository = new AppointmentRepository();
            medicineRepository = new MedicineRepository();

            activeMedicines = new List<Medicine>();
            currentPrescriptionIds = new List<int>();
        }

        private void invoiceGeneration_Load(object sender, EventArgs e)
        {
            InitializeCartTable();
            LoadPatientsIntoComboBox();
            LoadMedicineIntoComboBox();
            LoadRevenueSummary();

            cashRadioButton.Checked = true;
            discountNumericUpDown.Value = 0;

            RecalculateTotals();
        }

        private void InitializeCartTable()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("MedicineId", typeof(int));
            cartTable.Columns.Add("Medicine", typeof(string));
            cartTable.Columns.Add("UnitPrice", typeof(decimal));
            cartTable.Columns.Add("Qty", typeof(int));
            cartTable.Columns.Add("InStock", typeof(int));
            cartTable.Columns.Add("LineTotal", typeof(decimal));

            medicineDataGridView.DataSource = cartTable;

            medicineDataGridView.Columns["MedicineId"].Visible = false;

            medicineDataGridView.Columns["Medicine"].HeaderText = "Medicine";
            medicineDataGridView.Columns["UnitPrice"].HeaderText = "Unit Price (Rs.)";
            medicineDataGridView.Columns["Qty"].HeaderText = "Qty";
            medicineDataGridView.Columns["InStock"].HeaderText = "In Stock";
            medicineDataGridView.Columns["LineTotal"].HeaderText = "Line Total (Rs.)";

            medicineDataGridView.Columns["UnitPrice"].DefaultCellStyle.Format = "N2";
            medicineDataGridView.Columns["LineTotal"].DefaultCellStyle.Format = "N2";

            medicineDataGridView.Columns["Medicine"].FillWeight = 35;
            medicineDataGridView.Columns["UnitPrice"].FillWeight = 18;
            medicineDataGridView.Columns["Qty"].FillWeight = 12;
            medicineDataGridView.Columns["InStock"].FillWeight = 15;
            medicineDataGridView.Columns["LineTotal"].FillWeight = 20;
        }

        private void LoadPatientsIntoComboBox()
        {
            patientComboBox.SelectedIndexChanged -= patientComboBox_SelectedIndexChanged;

            patientComboBox.Items.Clear();

            try
            {
                List<PatientOption> patients = appointmentRepository.GetAllPatients();
                for (int i = 0; i < patients.Count; i++)
                {
                    patientComboBox.Items.Add(patients[i]);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            patientComboBox.SelectedIndex = -1;

            patientComboBox.SelectedIndexChanged += patientComboBox_SelectedIndexChanged;
        }

        private void LoadMedicineIntoComboBox()
        {
            medicineComboBox.SelectedIndexChanged -= medicineComboBox_SelectedIndexChanged;

            medicineComboBox.Items.Clear();
            medicineComboBox.Items.Add(NoMedicineText);

            try
            {
                activeMedicines = medicineRepository.GetAllActive();
                for (int i = 0; i < activeMedicines.Count; i++)
                {
                    medicineComboBox.Items.Add(new MedicineChoice(activeMedicines[i]));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            medicineComboBox.SelectedIndex = 0;

            medicineComboBox.SelectedIndexChanged += medicineComboBox_SelectedIndexChanged;
        }

        private void LoadConsultationIntoComboBox(int patientId)
        {
            consultationComboBox.SelectedIndexChanged -= consultationComboBox_SelectedIndexChanged;

            consultationComboBox.Items.Clear();
            consultationComboBox.Items.Add(WalkInText);

            try
            {
                List<UnbilledConsultation> consultations = invoiceRepository.GetUnbilledConsultationsForPatient(patientId);
                for (int i = 0; i < consultations.Count; i++)
                {
                    consultationComboBox.Items.Add(consultations[i]);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

            consultationComboBox.SelectedIndex = 0;

            consultationComboBox.SelectedIndexChanged += consultationComboBox_SelectedIndexChanged;

            ApplySelectedConsultation();
        }

        private void ApplySelectedConsultation()
        {
            currentPrescriptionIds.Clear();
            cartTable.Rows.Clear();
            lMaterialLabel10.Visible = true;

            UnbilledConsultation consultation = consultationComboBox.SelectedItem as UnbilledConsultation;

            if (consultation == null)
            {
                // Walk-in / pharmacy sale: no consultation, no fee.
                consultationIdSelected = 0;
                consultationFeeSelected = 0m;
            }
            else
            {
                consultationIdSelected = consultation.GetConsultationId();
                consultationFeeSelected = consultation.GetConsultationFee();
                LoadPrescribedMedicinesIntoCart(consultationIdSelected);
            }

            RecalculateTotals();
        }

        private void LoadPrescribedMedicinesIntoCart(int consultationId)
        {
            try
            {
                List<PrescribedMedicineLine> lines = invoiceRepository.GetPrescribedMedicines(consultationId);
                for (int i = 0; i < lines.Count; i++)
                {
                    PrescribedMedicineLine line = lines[i];
                    int inStock = GetStockForMedicine(line.GetMedicineId());

                    AddMedicineToCart(line.GetMedicineId(), line.GetName(), line.GetUnitPrice(), line.GetQuantity(), inStock);

                    if (!currentPrescriptionIds.Contains(line.GetPrescriptionId()))
                    {
                        currentPrescriptionIds.Add(line.GetPrescriptionId());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private int GetStockForMedicine(int medicineId)
        {
            for (int i = 0; i < activeMedicines.Count; i++)
            {
                if (activeMedicines[i].GetMedicineId() == medicineId)
                {
                    return activeMedicines[i].GetQuantityInStock();
                }
            }
            return 0;
        }

        private void AddMedicineToCart(int medicineId, string medicineName, decimal unitPrice, int qty, int inStock)
        {
            DataRow newRow = cartTable.NewRow();
            newRow["MedicineId"] = medicineId;
            newRow["Medicine"] = medicineName;
            newRow["UnitPrice"] = unitPrice;
            newRow["Qty"] = qty;
            newRow["InStock"] = inStock;
            newRow["LineTotal"] = unitPrice * qty;
            cartTable.Rows.Add(newRow);

            lMaterialLabel10.Visible = false;

            RecalculateTotals();
        }

        private Invoice BuildInvoiceFromForm()
        {
            Invoice invoice = new Invoice(patientIdSelected);

            if (consultationIdSelected != 0)
            {
                invoice.SetConsultationId(consultationIdSelected);
            }

            invoice.SetConsultationFee(consultationFeeSelected);
            invoice.SetDiscount(discountNumericUpDown.Value);
            invoice.SetPaymentMethod(GetSelectedPaymentMethod());

            for (int i = 0; i < cartTable.Rows.Count; i++)
            {
                DataRow row = cartTable.Rows[i];
                int medicineId = Convert.ToInt32(row["MedicineId"]);
                string description = row["Medicine"].ToString();
                int qty = Convert.ToInt32(row["Qty"]);
                decimal unitPrice = Convert.ToDecimal(row["UnitPrice"]);

                invoice.AddLineItem(new InvoiceLineItem(medicineId, description, qty, unitPrice));
            }

            return invoice;
        }

        private string GetSelectedPaymentMethod()
        {
            if (cardRadioButton.Checked)
            {
                return "Card";
            }
            if (otherRadioButton.Checked)
            {
                return "Other";
            }
            return "Cash";
        }

        private void RecalculateTotals()
        {
            Invoice preview = BuildInvoiceFromForm();

            consultationFeeValueLabel.Text = "Rs. " + preview.GetConsultationFee().ToString("N2");
            subtotalValueLabel.Text = "Rs. " + preview.GetSubtotal().ToString("N2");
            grandTotalValueLabel.Text = "Rs. " + preview.GetTotalAmount().ToString("N2");
        }

        private void LoadRevenueSummary()
        {
            try
            {
                List<DailyRevenueSummary> revenue = invoiceRepository.GetDailyRevenue();

                if (revenue.Count == 0)
                {
                    revenueLabel.Text = "No paid invoices yet.";
                    return;
                }

                DailyRevenueSummary latest = revenue[0];
                revenueLabel.Text =
                    "Latest revenue (" + latest.GetRevenueDate().ToString("yyyy-MM-dd") + "):     " +
                    "Invoices " + latest.GetInvoiceCount() + "      ·      " +
                    "Consultations Rs. " + latest.GetConsultationRevenue().ToString("N2") + "      ·      " +
                    "Pharmacy Rs. " + latest.GetPharmacyRevenue().ToString("N2") + "      ·      " +
                    "Discounts Rs. " + latest.GetTotalDiscounts().ToString("N2") + "      ·      " +
                    "Total Rs. " + latest.GetTotalRevenue().ToString("N2");
            }
            catch (Exception ex)
            {
                revenueLabel.Text = "Revenue unavailable: " + ex.Message;
            }
        }

        private void ResetFormForNextCustomer()
        {
            cartTable.Rows.Clear();
            lMaterialLabel10.Visible = true;

            discountNumericUpDown.Value = 0;
            cashRadioButton.Checked = true;

            consultationIdSelected = 0;
            consultationFeeSelected = 0m;
            currentPrescriptionIds.Clear();

            patientIdSelected = 0;
            patientComboBox.SelectedIndexChanged -= patientComboBox_SelectedIndexChanged;
            patientComboBox.SelectedIndex = -1;
            patientComboBox.SelectedIndexChanged += patientComboBox_SelectedIndexChanged;

            consultationComboBox.SelectedIndexChanged -= consultationComboBox_SelectedIndexChanged;
            consultationComboBox.Items.Clear();
            consultationComboBox.SelectedIndexChanged += consultationComboBox_SelectedIndexChanged;

            RecalculateTotals();
        }

        private void ShowError(string message)
        {
            LMaterialDialog.Show(this, "Database Error", "A database error occurred:\r\n\r\n" + message);
        }

        // ---- event handlers wired in the designer ----------------------------

        private void patientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PatientOption selected = patientComboBox.SelectedItem as PatientOption;
            if (selected == null)
            {
                return;
            }

            patientIdSelected = selected.GetPatientId();
            LoadConsultationIntoComboBox(patientIdSelected);
        }

        private void consultationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplySelectedConsultation();
        }

        private void medicineComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicineChoice choice = medicineComboBox.SelectedItem as MedicineChoice;

            if (choice == null)
            {
                qtyNumericUpDown.Maximum = 9999;
                qtyNumericUpDown.Value = 0;
                return;
            }

            int inStock = choice.GetMedicine().GetQuantityInStock();

            if (inStock > 0)
            {
                qtyNumericUpDown.Maximum = inStock;
                qtyNumericUpDown.Value = 1;
            }
            else
            {
                qtyNumericUpDown.Maximum = 0;
                qtyNumericUpDown.Value = 0;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MedicineChoice choice = medicineComboBox.SelectedItem as MedicineChoice;

            if (choice == null)
            {
                LMaterialDialog.Show(this, "No Medicine Selected", "Please select a medicine first.");
                return;
            }

            int qtySelected = (int)qtyNumericUpDown.Value;

            if (qtySelected <= 0)
            {
                LMaterialDialog.Show(this, "No Quantity", "Please choose a quantity greater than zero.");
                return;
            }

            Medicine medicine = choice.GetMedicine();
            int inStock = medicine.GetQuantityInStock();

            if (qtySelected > inStock)
            {
                LMaterialDialog.Show(this, "Insufficient Stock",
                    "Only " + inStock + " unit(s) of " + medicine.GetName() + " left in stock.");
                return;
            }

            AddMedicineToCart(medicine.GetMedicineId(), medicine.GetName(), medicine.GetUnitPrice(), qtySelected, inStock);

            medicineComboBox.SelectedIndexChanged -= medicineComboBox_SelectedIndexChanged;
            medicineComboBox.SelectedIndex = 0;
            medicineComboBox.SelectedIndexChanged += medicineComboBox_SelectedIndexChanged;

            qtyNumericUpDown.Value = 0;
        }

        private void removeSelectedButton_Click(object sender, EventArgs e)
        {
            if (medicineDataGridView.CurrentRow == null)
            {
                LMaterialDialog.Show(this, "Nothing Selected", "Select a line in the cart first.");
                return;
            }

            DataRowView selectedRow = medicineDataGridView.CurrentRow.DataBoundItem as DataRowView;
            if (selectedRow == null)
            {
                return;
            }

            cartTable.Rows.Remove(selectedRow.Row);

            if (cartTable.Rows.Count == 0)
            {
                lMaterialLabel10.Visible = true;
            }

            RecalculateTotals();
        }

        private void discountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            RecalculateTotals();
        }

        private void completePaymentButton_Click(object sender, EventArgs e)
        {
            if (patientIdSelected == 0)
            {
                LMaterialDialog.Show(this, "No Patient", "Please select a patient first.");
                return;
            }

            Invoice invoice = BuildInvoiceFromForm();

            if (invoice.GetDiscount() > invoice.GetConsultationFee() + invoice.GetSubtotal())
            {
                LMaterialDialog.Show(this, "Discount Too Large",
                    "Discount cannot be more than the consultation fee plus the medicines subtotal.");
                return;
            }

            User currentUser = GlobalSession.GetCurrentUser();
            if (currentUser == null)
            {
                LMaterialDialog.Show(this, "Not Signed In", "You must be signed in to complete a payment.");
                return;
            }

            try
            {
                int invoiceId = invoiceRepository.SaveInvoice(invoice, currentPrescriptionIds, currentUser.GetUserID());

                LMaterialDialog.Show(this, "Payment Complete",
                    "Invoice #" + invoiceId + " completed.\r\n\r\nTotal paid: Rs. " + invoice.GetTotalAmount().ToString("N2") + ".");

                LoadMedicineIntoComboBox();   // stock changed after dispensing
                LoadRevenueSummary();
                ResetFormForNextCustomer();
            }
            catch (InsufficientStockException)
            {
                LMaterialDialog.Show(this, "Insufficient Stock",
                    "Insufficient stock for one or more medicines. Please adjust the quantities and try again.");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void consultationFeeValueLabel_Click(object sender, EventArgs e)
        {
        }

        private void cashRadioButton_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
