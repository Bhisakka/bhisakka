using System;
using System.Collections.Generic;
using Bhisakka.Models;
using Npgsql;

namespace Bhisakka.DataAccess
{
    internal class UnbilledConsultation
    {
        private int consultationId;
        private int patientId;
        private string patientName;
        private decimal consultationFee;
        private string diagnosis;

        public UnbilledConsultation(int consultationId, int patientId, string patientName, decimal consultationFee, string diagnosis)
        {
            this.consultationId = consultationId;
            this.patientId = patientId;
            this.patientName = patientName;
            this.consultationFee = consultationFee;
            this.diagnosis = diagnosis;
        }

        public int GetConsultationId()
        {
            return consultationId;
        }

        public int GetPatientId()
        {
            return patientId;
        }

        public string GetPatientName()
        {
            return patientName;
        }

        public decimal GetConsultationFee()
        {
            return consultationFee;
        }

        public string GetDiagnosis()
        {
            return diagnosis;
        }

        public override string ToString()
        {
            return patientName + " - " + (string.IsNullOrEmpty(diagnosis) ? "(no diagnosis)" : diagnosis) + " - Rs. " + consultationFee.ToString("N2");
        }
    }

    internal class PrescribedMedicineLine
    {
        private int prescriptionId;
        private int medicineId;
        private string name;
        private int quantity;
        private decimal unitPrice;

        public PrescribedMedicineLine(int prescriptionId, int medicineId, string name, int quantity, decimal unitPrice)
        {
            this.prescriptionId = prescriptionId;
            this.medicineId = medicineId;
            this.name = name;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public int GetPrescriptionId()
        {
            return prescriptionId;
        }

        public int GetMedicineId()
        {
            return medicineId;
        }

        public string GetName()
        {
            return name;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public decimal GetUnitPrice()
        {
            return unitPrice;
        }
    }

    internal class DailyRevenueSummary
    {
        private DateTime revenueDate;
        private int invoiceCount;
        private decimal consultationRevenue;
        private decimal pharmacyRevenue;
        private decimal totalDiscounts;
        private decimal totalRevenue;

        public DailyRevenueSummary(DateTime revenueDate, int invoiceCount, decimal consultationRevenue,
            decimal pharmacyRevenue, decimal totalDiscounts, decimal totalRevenue)
        {
            this.revenueDate = revenueDate;
            this.invoiceCount = invoiceCount;
            this.consultationRevenue = consultationRevenue;
            this.pharmacyRevenue = pharmacyRevenue;
            this.totalDiscounts = totalDiscounts;
            this.totalRevenue = totalRevenue;
        }

        public DateTime GetRevenueDate()
        {
            return revenueDate;
        }

        public int GetInvoiceCount()
        {
            return invoiceCount;
        }

        public decimal GetConsultationRevenue()
        {
            return consultationRevenue;
        }

        public decimal GetPharmacyRevenue()
        {
            return pharmacyRevenue;
        }

        public decimal GetTotalDiscounts()
        {
            return totalDiscounts;
        }

        public decimal GetTotalRevenue()
        {
            return totalRevenue;
        }
    }

    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    internal class InvoiceRepository
    {
        public List<UnbilledConsultation> GetUnbilledConsultations()
        {
            List<UnbilledConsultation> list = new List<UnbilledConsultation>();

            string query =
                "SELECT c.consultation_id, c.patient_id, p.first_name || ' ' || p.last_name AS patient_name, " +
                "c.consultation_fee, c.diagnosis " +
                "FROM consultations c " +
                "JOIN patients p ON p.patient_id = c.patient_id " +
                "WHERE NOT EXISTS (SELECT 1 FROM invoices i WHERE i.consultation_id = c.consultation_id) " +
                "ORDER BY c.started_at DESC;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string diagnosis = reader["diagnosis"] == DBNull.Value ? "" : reader["diagnosis"].ToString();

                    list.Add(new UnbilledConsultation(
                        Convert.ToInt32(reader["consultation_id"]),
                        Convert.ToInt32(reader["patient_id"]),
                        reader["patient_name"].ToString(),
                        Convert.ToDecimal(reader["consultation_fee"]),
                        diagnosis));
                }
            }

            return list;
        }

        public List<UnbilledConsultation> GetUnbilledConsultationsForPatient(int patientId)
        {
            List<UnbilledConsultation> list = new List<UnbilledConsultation>();

            string query =
                "SELECT c.consultation_id, c.patient_id, p.first_name || ' ' || p.last_name AS patient_name, " +
                "c.consultation_fee, c.diagnosis " +
                "FROM consultations c " +
                "JOIN patients p ON p.patient_id = c.patient_id " +
                "WHERE c.patient_id = @patientId " +
                "AND NOT EXISTS (SELECT 1 FROM invoices i WHERE i.consultation_id = c.consultation_id AND i.payment_status <> 'Cancelled') " +
                "ORDER BY c.started_at DESC;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientId", patientId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string diagnosis = reader["diagnosis"] == DBNull.Value ? "" : reader["diagnosis"].ToString();

                        list.Add(new UnbilledConsultation(
                            Convert.ToInt32(reader["consultation_id"]),
                            Convert.ToInt32(reader["patient_id"]),
                            reader["patient_name"].ToString(),
                            Convert.ToDecimal(reader["consultation_fee"]),
                            diagnosis));
                    }
                }
            }

            return list;
        }

        public List<PrescribedMedicineLine> GetPrescribedMedicines(int consultationId)
        {
            List<PrescribedMedicineLine> list = new List<PrescribedMedicineLine>();

            string query =
                "SELECT pr.prescription_id, pi.medicine_id, m.name, pi.quantity, m.unit_price " +
                "FROM prescriptions pr " +
                "JOIN prescription_items pi ON pi.prescription_id = pr.prescription_id " +
                "JOIN medicines m ON m.medicine_id = pi.medicine_id " +
                "WHERE pr.consultation_id = @consultationId AND pr.is_fulfilled = FALSE;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@consultationId", consultationId);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PrescribedMedicineLine(
                            Convert.ToInt32(reader["prescription_id"]),
                            Convert.ToInt32(reader["medicine_id"]),
                            reader["name"].ToString(),
                            Convert.ToInt32(reader["quantity"]),
                            Convert.ToDecimal(reader["unit_price"])));
                    }
                }
            }

            return list;
        }

        public int SaveInvoice(Invoice invoice, List<int> prescriptionIdsToFulfill, int userId)
        {
            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            {
                NpgsqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    int invoiceId;

                    string insertInvoiceSql =
                        "INSERT INTO invoices (consultation_id, patient_id, consultation_fee, subtotal, discount, " +
                        "total_amount, payment_status, payment_method, paid_at, created_by) " +
                        "VALUES (@consultationId, @patientId, @fee, @subtotal, @discount, @total, 'Paid', @method, now(), @userId) " +
                        "RETURNING invoice_id;";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertInvoiceSql, conn, transaction))
                    {
                        if (invoice.GetConsultationId().HasValue)
                        {
                            cmd.Parameters.AddWithValue("@consultationId", invoice.GetConsultationId().Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@consultationId", DBNull.Value);
                        }

                        cmd.Parameters.AddWithValue("@patientId", invoice.GetPatientId());
                        cmd.Parameters.AddWithValue("@fee", invoice.GetConsultationFee());
                        cmd.Parameters.AddWithValue("@subtotal", invoice.GetSubtotal());
                        cmd.Parameters.AddWithValue("@discount", invoice.GetDiscount());
                        cmd.Parameters.AddWithValue("@total", invoice.GetTotalAmount());
                        cmd.Parameters.AddWithValue("@method", invoice.GetPaymentMethod());
                        cmd.Parameters.AddWithValue("@userId", userId);

                        invoiceId = (int)cmd.ExecuteScalar();
                    }

                    List<InvoiceLineItem> lineItems = invoice.GetLineItems();
                    for (int i = 0; i < lineItems.Count; i++)
                    {
                        InvoiceLineItem item = lineItems[i];

                        using (NpgsqlCommand cmd = new NpgsqlCommand(
                            "INSERT INTO invoice_line_items (invoice_id, medicine_id, description, quantity, unit_price) " +
                            "VALUES (@invoiceId, @medicineId, @description, @qty, @unitPrice);", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                            cmd.Parameters.AddWithValue("@medicineId", item.GetMedicineId());
                            cmd.Parameters.AddWithValue("@description", item.GetDescription());
                            cmd.Parameters.AddWithValue("@qty", item.GetQuantity());
                            cmd.Parameters.AddWithValue("@unitPrice", item.GetUnitPrice());
                            cmd.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmd = new NpgsqlCommand(
                            "UPDATE medicines SET quantity_in_stock = quantity_in_stock - @qty, updated_at = now() " +
                            "WHERE medicine_id = @medicineId;", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@qty", item.GetQuantity());
                            cmd.Parameters.AddWithValue("@medicineId", item.GetMedicineId());
                            cmd.ExecuteNonQuery();
                        }

                        using (NpgsqlCommand cmd = new NpgsqlCommand(
                            "INSERT INTO stock_transactions (medicine_id, quantity_change, transaction_type, invoice_id, created_by) " +
                            "VALUES (@medicineId, @quantityChange, 'Dispense', @invoiceId, @userId);", conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@medicineId", item.GetMedicineId());
                            cmd.Parameters.AddWithValue("@quantityChange", -item.GetQuantity());
                            cmd.Parameters.AddWithValue("@invoiceId", invoiceId);
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (prescriptionIdsToFulfill != null)
                    {
                        for (int i = 0; i < prescriptionIdsToFulfill.Count; i++)
                        {
                            using (NpgsqlCommand cmd = new NpgsqlCommand(
                                "UPDATE prescriptions SET is_fulfilled = TRUE, fulfilled_at = now() WHERE prescription_id = @prescriptionId;",
                                conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@prescriptionId", prescriptionIdsToFulfill[i]);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    transaction.Commit();

                    invoice.SetInvoiceId(invoiceId);
                    return invoiceId;
                }
                catch (PostgresException pgEx)
                {
                    transaction.Rollback();

                    bool isStockCheck = pgEx.SqlState == "23514"
                        && pgEx.ConstraintName != null
                        && pgEx.ConstraintName.IndexOf("quantity_in_stock", StringComparison.Ordinal) >= 0;

                    if (isStockCheck)
                    {
                        throw new InsufficientStockException(
                            "Insufficient stock to dispense one or more medicines for this invoice.", pgEx);
                    }

                    throw;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public List<DailyRevenueSummary> GetDailyRevenue()
        {
            List<DailyRevenueSummary> list = new List<DailyRevenueSummary>();

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM v_daily_revenue ORDER BY revenue_date DESC;", conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new DailyRevenueSummary(
                        Convert.ToDateTime(reader["revenue_date"]),
                        Convert.ToInt32(reader["invoice_count"]),
                        Convert.ToDecimal(reader["consultation_revenue"]),
                        Convert.ToDecimal(reader["pharmacy_revenue"]),
                        Convert.ToDecimal(reader["total_discounts"]),
                        Convert.ToDecimal(reader["total_revenue"])));
                }
            }

            return list;
        }
    }
}
