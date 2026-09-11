namespace Bhisakka.Models
{
    internal class MedicineOption
    {
        private int medicineId;
        private string name;
        private decimal unitPrice;

        public MedicineOption(int medicineId, string name, decimal unitPrice)
        {
            this.medicineId = medicineId;
            this.name = name;
            this.unitPrice = unitPrice;
        }

        public int GetMedicineId()
        {
            return medicineId;
        }

        public string GetName()
        {
            return name;
        }

        public decimal GetUnitPrice()
        {
            return unitPrice;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
