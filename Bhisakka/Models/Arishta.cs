namespace Bhisakka.Models
{
    internal class Arishta : Medicine
    {
        private decimal? alcoholContent;

        public Arishta()
        {
        }

        public decimal? GetAlcoholContent()
        {
            return alcoholContent;
        }

        public void SetAlcoholContent(decimal? value)
        {
            alcoholContent = value;
        }

        public override string GetMedicineType()
        {
            return "Arishta";
        }

        public override string GetStorageGuidance()
        {
            return "Store upright in a cool, dark place, tightly sealed.";
        }

        public override string GetSpecificDetails()
        {
            if (alcoholContent.HasValue)
            {
                return "Alcohol " + alcoholContent.Value.ToString("0.##") + "%";
            }
            return "Alcohol -";
        }
    }
}
