using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Services.Managers;
using Xunit;

namespace TaxCalculator.Tests.Managers
{
    public class TaxCalculationManagerTests
    {
        private readonly List<DataAccess.Models.TaxBand> taxBands = new List<DataAccess.Models.TaxBand>()
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
                    UpperLimit = null,
                    Rate = 40
                }
                };

        [Fact]
        public void CalculateMonthlySalary_ReturnsResult()
        {
            var expectedResult = 3333.33M;

            var taxManager = new TaxCalculationManager();
            var result = taxManager.CalculateMonthlySalary(40000.00M);

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateNetMonthlySalary_ReturnsResult()
        {
            var expectedResult = 2416.67M;

            var taxManager = new TaxCalculationManager();
            var result = taxManager.CalculateNetMonthlySalary(29000.00M);

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CalculateMonthlyTaxPaid_ReturnsResult()
        {
            var expectedResult = 916.67M;

            var taxManager = new TaxCalculationManager();
            var result = taxManager.CalculateMonthlyTaxPaid(11000.00M);

            Assert.NotNull(result);
            Assert.Equal(expectedResult, result);
        }
    }
}
