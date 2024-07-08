namespace CalculatorService.Models
{
    public class TaxCalculationResult
    {
        public decimal Salary { get; set; }

        public decimal GrossMonthlySalary { get; set; }

        public decimal NetAnnualSalary { get; set; }

        public decimal NetMonthlySalary { get; set; }

        public decimal AnnualTaxPaid { get; set; }

        public decimal MonthlyTaxPaid { get; set; }
    }
}
