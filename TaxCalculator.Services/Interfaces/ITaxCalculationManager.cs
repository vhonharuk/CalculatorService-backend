namespace TaxCalculator.Services.Interfaces
{
    public interface ITaxCalculationManager
    {
        decimal CalculateAnnualTax(decimal grossAnnualSalary, List<DataAccess.Models.TaxBand> taxBands);

        decimal CalculateMonthlySalary(decimal grossAnnualSalary);

        decimal CalculateNetMonthlySalary(decimal netAnnualSalary);

        decimal CalculateMonthlyTaxPaid(decimal annualTaxPaid);
    }
}
