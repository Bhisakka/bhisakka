namespace Bhisakka.Models
{
    internal class OtherMedicine : Medicine
    {
        public OtherMedicine()
        {
        }

        public override string GetMedicineType()
        {
            return "Other";
        }
    }
}
