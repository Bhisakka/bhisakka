namespace Bhisakka.Models
{
    internal class Kashaya : Medicine
    {
        public Kashaya()
        {
        }

        public override string GetMedicineType()
        {
            return "Kashaya";
        }

        public override string GetStorageGuidance()
        {
            return "Refrigerate after opening and use within the shelf period.";
        }
    }
}
