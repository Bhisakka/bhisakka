namespace Bhisakka.Models
{
    internal class Thaila : Medicine
    {
        public Thaila()
        {
        }

        public override string GetMedicineType()
        {
            return "Thaila";
        }

        public override string GetStorageGuidance()
        {
            return "For external use only. Store away from heat.";
        }
    }
}
