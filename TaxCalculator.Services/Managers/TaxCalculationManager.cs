using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Managers
{
    public class TaxCalculationManager : ITaxCalculationManager
    {
        private const decimal Months = 12M;
        public decimal CalculateAnnualTax(decimal grossAnnualSalary, List<DataAccess.Models.TaxBand> taxBands)
        {
            decimal totalTax = 0;
            foreach (var band in taxBands)
            {
                if (grossAnnualSalary >= band.LowerLimit)
                {
                    var taxableSalary = (band.UpperLimit != null ? Math.Min(band.UpperLimit.Value, grossAnnualSalary) : grossAnnualSalary) - band.LowerLimit;
                    var tax = taxableSalary * band.Rate;
                    totalTax += tax;
                }
            }
            return totalTax;
        }

        public decimal CalculateMonthlySalary(decimal grossAnnualSalary)
        {
            decimal monthlySalary = grossAnnualSalary / Months;
            return decimal.Round(monthlySalary, 2);
        }

        public decimal CalculateNetMonthlySalary(decimal netAnnualSalary)
        {
            return decimal.Round(netAnnualSalary / Months, 2);
        }

        public decimal CalculateMonthlyTaxPaid(decimal annualTaxPaid)
        {
            return decimal.Round(annualTaxPaid / Months, 2);
        }
    }
}
