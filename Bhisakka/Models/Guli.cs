namespace Bhisakka.Models
{
    internal class Guli : Medicine
    {
        public Guli()
        {
        }

        public override string GetMedicineType()
        {
            return "Guli";
        }

        public override string GetStorageGuidance()
        {
            return "Store in a dry, child-proof container.";
        }
    }
}
