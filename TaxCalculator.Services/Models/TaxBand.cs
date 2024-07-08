namespace TaxCalculator.Services.Models
{
    public class TaxBand
    {
        public int LowerLimit { get; set; }
        public int? UpperLimit { get; set; }
        public decimal Rate { get; set; }
    }
}
