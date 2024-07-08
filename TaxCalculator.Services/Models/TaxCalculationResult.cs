using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Services.Models
{
    public class TaxCalculatorResult
    {
        [Range(0, double.PositiveInfinity)]
        public decimal GrossAnnualSalary { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal GrossMonthlySalary { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal NetAnnualSalary { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal NetMonthlySalary { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal AnnualTaxPaid { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal MonthlyTaxPaid { get; set; }
    }
}
