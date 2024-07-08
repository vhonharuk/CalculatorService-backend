using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.DataAccess.Models
{
    public class BaseDbModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
