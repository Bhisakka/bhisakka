namespace Bhisakka.Models
{
    internal static class MedicineFactory
    {
        public static readonly string[] AllTypes = { "Arishta", "Churna", "Kashaya", "Thaila", "Guli", "Other" };

        public static Medicine Create(string medicineType)
        {
            if (medicineType == "Arishta")
            {
                return new Arishta();
            }
            if (medicineType == "Churna")
            {
                return new Churna();
            }
            if (medicineType == "Kashaya")
            {
                return new Kashaya();
            }
            if (medicineType == "Thaila")
            {
                return new Thaila();
            }
            if (medicineType == "Guli")
            {
                return new Guli();
            }
            return new OtherMedicine();
        }
    }
}
