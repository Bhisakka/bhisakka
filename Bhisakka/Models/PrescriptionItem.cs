namespace Bhisakka.Models
{
    internal class PrescriptionItem
    {
        private int medicineId;
        private string medicineName;
        private int quantity;
        private string dosageInstructions;

        public PrescriptionItem(int medicineId, string medicineName, int quantity, string dosageInstructions)
        {
            this.medicineId = medicineId;
            this.medicineName = medicineName;
            this.quantity = quantity;
            this.dosageInstructions = dosageInstructions;
        }

        public int GetMedicineId()
        {
            return medicineId;
        }

        public string GetMedicineName()
        {
            return medicineName;
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public string GetDosageInstructions()
        {
            return dosageInstructions;
        }

        public override string ToString()
        {
            return medicineName + "  x" + quantity + "  (" + dosageInstructions + ")";
        }
    }
}
