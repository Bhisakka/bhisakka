namespace Bhisakka.Models
{
    internal class Churna : Medicine
    {
        public Churna()
        {
        }

        public override string GetMedicineType()
        {
            return "Churna";
        }

        public override string GetStorageGuidance()
        {
            return "Keep in an airtight container, away from moisture.";
        }
    }
}
