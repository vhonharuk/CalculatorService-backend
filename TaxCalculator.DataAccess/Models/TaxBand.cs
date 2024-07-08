using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DataAccess.Models
{
    public class TaxBand : BaseDbModelWithUpdateData
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int LowerLimit { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int? UpperLimit { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Rate { get; set; }
    }
}
