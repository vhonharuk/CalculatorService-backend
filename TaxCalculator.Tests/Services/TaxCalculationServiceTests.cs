using Microsoft.Extensions.Logging;
using Moq;
using TaxCalculator.DataAccess.Interfaces;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Models;
using TaxCalculator.Services.Services;
using Xunit;

namespace TaxCalculator.Tests.Services
{
    public class TaxCalculationServiceTests
    {
        private readonly TaxCalculationService _taxCalculationService;
        private readonly Mock<ILogger<TaxCalculationService>> _loggerMock;
        private readonly Mock<ITaxRepository<DataAccess.Models.TaxBand>> _taxRepositoryMock;
        private readonly Mock<ITaxCalculationManager> _taxCalculationManager;

        public TaxCalculationServiceTests()
        {
            var taxBands = new List<DataAccess.Models.TaxBand>()
                {
                new()
                {
                    Id = Guid.NewGuid(),
                    LowerLimit = 0,
                    UpperLimit = 5000,
                    Rate = 0
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    LowerLimit = 5000,
                    UpperLimit = 20000,
                    Rate = 20
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    LowerLimit = 20000,
                    UpperLimit = 40000,
                    Rate = 40
                }
                };

            _loggerMock = new Mock<ILogger<TaxCalculationService>>();

            _taxRepositoryMock = new Mock<ITaxRepository<DataAccess.Models.TaxBand>>();
            _taxRepositoryMock.Setup(x => x.GetAllAsync()).ReturnsAsync(
                taxBands);

            _taxCalculationManager = new Mock<ITaxCalculationManager>();
            _taxCalculationManager.Setup(x => x.CalculateAnnualTax(40000, It.IsAny<List<DataAccess.Models.TaxBand>>()))
                .Returns(11000);
            _taxCalculationManager.Setup(x => x.CalculateMonthlySalary(40000))
                .Returns(3333.33M);
            _taxCalculationManager.Setup(x => x.CalculateNetMonthlySalary(29000))
                .Returns(2416.67M);
            _taxCalculationManager.Setup(x => x.CalculateMonthlyTaxPaid(11000))
                .Returns(916.67M);

            _taxCalculationService = new TaxCalculationService(_taxRepositoryMock.Object, _taxCalculationManager.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CalculateTask_ReturnsTaxCalculatorResult()
        {
            var expectedResult = new TaxCalculatorResult
            {
                GrossAnnualSalary = 40000.00M,
                GrossMonthlySalary = 3333.33M,
                NetAnnualSalary = 29000.00M,
                NetMonthlySalary = 2416.67M,
                AnnualTaxPaid = 11000.00M,
                MonthlyTaxPaid = 916.67M
            };

            var result = await _taxCalculationService.GetCalculatedTaxAsync(40000);

            Assert.NotNull(result);
            Assert.Equal(expectedResult.GrossAnnualSalary, result.GrossAnnualSalary);
            Assert.Equal(expectedResult.GrossMonthlySalary, result.GrossMonthlySalary);
            Assert.Equal(expectedResult.NetAnnualSalary, result.NetAnnualSalary);
            Assert.Equal(expectedResult.NetMonthlySalary, result.NetMonthlySalary);
            Assert.Equal(expectedResult.AnnualTaxPaid, result.AnnualTaxPaid);
            Assert.Equal(expectedResult.MonthlyTaxPaid, result.MonthlyTaxPaid);
        }
    }
}
