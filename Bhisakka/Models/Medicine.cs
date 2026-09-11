using System;

namespace Bhisakka.Models
{
    internal abstract class Medicine
    {
        private int medicineId;
        private string name;
        private string unit;
        private decimal unitPrice;
        private int quantityInStock;
        private int reorderLevel;
        private DateTime? expiryDate;
        private string description;
        private bool isActive;

        protected Medicine()
        {
            reorderLevel = 10;
            isActive = true;
        }

        public int GetMedicineId()
        {
            return medicineId;
        }

        public void SetMedicineId(int value)
        {
            medicineId = value;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public string GetUnit()
        {
            return unit;
        }

        public void SetUnit(string value)
        {
            unit = value;
        }

        public decimal GetUnitPrice()
        {
            return unitPrice;
        }

        public void SetUnitPrice(decimal value)
        {
            unitPrice = value;
        }

        public int GetQuantityInStock()
        {
            return quantityInStock;
        }

        public void SetQuantityInStock(int value)
        {
            quantityInStock = value;
        }

        public int GetReorderLevel()
        {
            return reorderLevel;
        }

        public void SetReorderLevel(int value)
        {
            reorderLevel = value;
        }

        public DateTime? GetExpiryDate()
        {
            return expiryDate;
        }

        public void SetExpiryDate(DateTime? value)
        {
            expiryDate = value;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string value)
        {
            description = value;
        }

        public bool GetIsActive()
        {
            return isActive;
        }

        public void SetIsActive(bool value)
        {
            isActive = value;
        }

        public abstract string GetMedicineType();

        public bool GetIsLowStock()
        {
            return quantityInStock <= reorderLevel;
        }

        public bool GetIsNearExpiry()
        {
            if (!expiryDate.HasValue)
            {
                return false;
            }
            return expiryDate.Value.Date <= DateTime.Today.AddDays(30);
        }

        public virtual string GetStorageGuidance()
        {
            return "Store in a cool, dry place away from direct sunlight.";
        }

        public virtual string GetSpecificDetails()
        {
            return "-";
        }

        public override string ToString()
        {
            return name + " (" + GetMedicineType() + ")";
        }
    }
}
