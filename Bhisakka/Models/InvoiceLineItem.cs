using System;

namespace Bhisakka.Models
{
    internal class InvoiceLineItem
    {
        private int medicineId;
        private string description;
        private int quantity;
        private decimal unitPrice;

        public InvoiceLineItem(int medicineId, string description, int quantity, decimal unitPrice)
        {
            this.medicineId = medicineId;
            this.description = description;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public int GetMedicineId()
        {
            return medicineId;
        }

        public void SetMedicineId(int value)
        {
            medicineId = value;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int value)
        {
            quantity = value;
        }

        public decimal GetUnitPrice()
        {
            return unitPrice;
        }

        public void SetUnitPrice(decimal value)
        {
            unitPrice = value;
        }

        public decimal GetLineTotal()
        {
            return quantity * unitPrice;
        }
    }
}
