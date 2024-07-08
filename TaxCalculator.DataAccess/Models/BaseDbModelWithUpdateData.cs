using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DataAccess.Models
{
    public class BaseDbModelWithUpdateData : BaseDbModel
    {
        [Required]
        public DateTime FirstInserted { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
