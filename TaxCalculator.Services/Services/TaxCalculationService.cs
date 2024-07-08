using Microsoft.Extensions.Logging;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Models;

namespace TaxCalculator.Services.Services
{
    public class TaxCalculationService : ITaxCalculatorService
    {
        private readonly ITaxRepository<DataAccess.Models.TaxBand> _taxBandRepository;
        private readonly ITaxCalculationManager _taxCalculationManager;
        private readonly ILogger<TaxCalculationService> _logger;

        public static List<DataAccess.Models.TaxBand> TaxBands = new List<DataAccess.Models.TaxBand>
        {
            new DataAccess.Models.TaxBand() { LowerLimit = 0, UpperLimit = 5000, Rate = 0},
            new DataAccess.Models.TaxBand() { LowerLimit = 5000, UpperLimit = 20000, Rate = 0.20M},
            new DataAccess.Models.TaxBand() { LowerLimit = 20000, UpperLimit = null, Rate = 0.40M}
        };

        public TaxCalculationService(
            ITaxRepository<DataAccess.Models.TaxBand> taxBandRepository,
            ITaxCalculationManager taxCalculationManager,
            ILogger<TaxCalculationService> logger) 
        {
            _taxBandRepository = taxBandRepository;
            _taxCalculationManager = taxCalculationManager;
            _logger = logger;
        }  

        public async Task<TaxCalculatorResult> GetCalculatedTaxAsync(decimal salary)
        {
            _logger.LogDebug("The tax calculation has been started.");

            //TODO: call real DB

            //var taxBands = await _taxBandRepository.GetAllAsync();

            //if (taxBands is null || !taxBands.Any())
            //{
            //    _logger.LogWarning("The TaxBands is null or empty.");
            //}

            var taxBands = TaxBands;

            var annualTaxPaid = _taxCalculationManager.CalculateAnnualTax(salary, taxBands);

            _logger.LogDebug("The tax calculation has been finished.");

            var netAnnualSalary = salary - annualTaxPaid;

            var grossMonthlySalary = _taxCalculationManager.CalculateMonthlySalary(salary);
            var netMonthlySalary = _taxCalculationManager.CalculateNetMonthlySalary(netAnnualSalary);
            var monthlyTaxPaid = _taxCalculationManager.CalculateMonthlyTaxPaid(annualTaxPaid);

            return new TaxCalculatorResult
            {
                GrossAnnualSalary = salary,
                GrossMonthlySalary = grossMonthlySalary,
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = netMonthlySalary,
                AnnualTaxPaid = annualTaxPaid,
                MonthlyTaxPaid = monthlyTaxPaid
            };
        }
    }
}
