using System;
using System.Collections.Generic;
using System.Data;
using Bhisakka.Models;
using Npgsql;

namespace Bhisakka.DataAccess
{
    internal class MedicineRepository
    {
        public List<Medicine> GetAllActive()
        {
            List<Medicine> list = new List<Medicine>();

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM medicines WHERE is_active ORDER BY name;", conn))
            using (NpgsqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(MapRowToMedicine(reader));
                }
            }

            return list;
        }

        public DataTable GetLowStockAlerts()
        {
            DataTable table = new DataTable();

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM v_low_stock;", conn))
            using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
            {
                adapter.Fill(table);
            }

            return table;
        }

        public int Insert(Medicine medicine)
        {
            string sql = "INSERT INTO medicines (name, medicine_type, alcohol_content, unit, unit_price, " +
                         "quantity_in_stock, reorder_level, expiry_date, description) " +
                         "VALUES (@name, @type, @alcoholContent, @unit, @price, @qty, @reorderLevel, @expiry, @description) " +
                         "RETURNING medicine_id;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                decimal? alcoholContent = null;
                Arishta arishta = medicine as Arishta;
                if (arishta != null)
                {
                    alcoholContent = arishta.GetAlcoholContent();
                }

                cmd.Parameters.AddWithValue("@name", medicine.GetName());
                cmd.Parameters.AddWithValue("@type", medicine.GetMedicineType());

                if (alcoholContent.HasValue)
                {
                    cmd.Parameters.AddWithValue("@alcoholContent", alcoholContent.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@alcoholContent", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@unit", medicine.GetUnit());
                cmd.Parameters.AddWithValue("@price", medicine.GetUnitPrice());
                cmd.Parameters.AddWithValue("@qty", medicine.GetQuantityInStock());
                cmd.Parameters.AddWithValue("@reorderLevel", medicine.GetReorderLevel());

                if (medicine.GetExpiryDate().HasValue)
                {
                    cmd.Parameters.AddWithValue("@expiry", medicine.GetExpiryDate().Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiry", DBNull.Value);
                }

                if (medicine.GetDescription() != null)
                {
                    cmd.Parameters.AddWithValue("@description", medicine.GetDescription());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@description", DBNull.Value);
                }

                int newId = (int)cmd.ExecuteScalar();
                medicine.SetMedicineId(newId);
                return newId;
            }
        }

        public void Update(Medicine medicine)
        {
            string sql = "UPDATE medicines SET unit_price = @price, quantity_in_stock = @qty, " +
                         "reorder_level = @reorderLevel, expiry_date = @expiry, updated_at = now() " +
                         "WHERE medicine_id = @id;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@price", medicine.GetUnitPrice());
                cmd.Parameters.AddWithValue("@qty", medicine.GetQuantityInStock());
                cmd.Parameters.AddWithValue("@reorderLevel", medicine.GetReorderLevel());

                if (medicine.GetExpiryDate().HasValue)
                {
                    cmd.Parameters.AddWithValue("@expiry", medicine.GetExpiryDate().Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiry", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@id", medicine.GetMedicineId());
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDelete(int medicineId)
        {
            string sql = "UPDATE medicines SET is_active = FALSE, updated_at = now() WHERE medicine_id = @id;";

            using (NpgsqlConnection conn = DatabaseHelper.GetConnection())
            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", medicineId);
                cmd.ExecuteNonQuery();
            }
        }

        private Medicine MapRowToMedicine(NpgsqlDataReader reader)
        {
            string medicineType = reader["medicine_type"].ToString();
            Medicine medicine = MedicineFactory.Create(medicineType);

            medicine.SetMedicineId(Convert.ToInt32(reader["medicine_id"]));
            medicine.SetName(reader["name"].ToString());
            medicine.SetUnit(reader["unit"].ToString());
            medicine.SetUnitPrice(Convert.ToDecimal(reader["unit_price"]));
            medicine.SetQuantityInStock(Convert.ToInt32(reader["quantity_in_stock"]));
            medicine.SetReorderLevel(Convert.ToInt32(reader["reorder_level"]));

            if (reader["expiry_date"] == DBNull.Value)
            {
                medicine.SetExpiryDate(null);
            }
            else
            {
                medicine.SetExpiryDate(Convert.ToDateTime(reader["expiry_date"]));
            }

            if (reader["description"] == DBNull.Value)
            {
                medicine.SetDescription(null);
            }
            else
            {
                medicine.SetDescription(reader["description"].ToString());
            }

            medicine.SetIsActive(Convert.ToBoolean(reader["is_active"]));

            Arishta arishta = medicine as Arishta;
            if (arishta != null && reader["alcohol_content"] != DBNull.Value)
            {
                arishta.SetAlcoholContent(Convert.ToDecimal(reader["alcohol_content"]));
            }

            return medicine;
        }
    }
}
