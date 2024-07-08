using CalculatorService.Controllers;
using CalculatorService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Managers;
using TaxCalculator.Services.Models;
using Xunit;

namespace TaxCalculator.Tests.Controllers
{
    public class TaxCalculationControllerTests
    {
        private readonly Mock<ITaxCalculatorService> _taxCalculatorService;
        private readonly Mock<ILogger<TaxCalculationController>> _logger;

        public TaxCalculationControllerTests()
        {
            _taxCalculatorService = new Mock<ITaxCalculatorService>();
            _logger = new Mock<ILogger<TaxCalculationController>>();
        }

        [Fact]
        public async Task Get_ReturnsResult()
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
            
            _taxCalculatorService.Setup(x=> x.GetCalculatedTaxAsync(40000M))
                .ReturnsAsync(expectedResult);

            var taxCalculationController = new TaxCalculationController(_taxCalculatorService.Object, _logger.Object);

            var result = await taxCalculationController.Get(40000);

            var taxCalculationStatusCodeResult = ((OkObjectResult)result.Result).StatusCode;
            var taxCalculationResult = ((OkObjectResult)result.Result).Value as TaxCalculatorResult;

            Assert.NotNull(result);
            Assert.Equal(expectedResult.GrossMonthlySalary, taxCalculationResult.GrossMonthlySalary);
            Assert.Equal(expectedResult.NetAnnualSalary, taxCalculationResult.NetAnnualSalary);
            Assert.Equal(expectedResult.NetMonthlySalary, taxCalculationResult.NetMonthlySalary);
            Assert.Equal(expectedResult.AnnualTaxPaid, taxCalculationResult.AnnualTaxPaid);
            Assert.Equal(expectedResult.MonthlyTaxPaid, taxCalculationResult.MonthlyTaxPaid);
            Assert.Equal(taxCalculationStatusCodeResult, StatusCodes.Status200OK);
        }
    }
}
