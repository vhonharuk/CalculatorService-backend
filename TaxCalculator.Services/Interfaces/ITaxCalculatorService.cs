using TaxCalculator.Services.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface ITaxCalculatorService
    {
        public Task<TaxCalculatorResult> GetCalculatedTaxAsync(decimal salary);
    }
}
