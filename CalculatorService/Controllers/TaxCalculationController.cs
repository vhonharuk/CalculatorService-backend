using CalculatorService.Models;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Services.Interfaces;

namespace CalculatorService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculationController : ControllerBase
    {
        private readonly ITaxCalculatorService taxCalculatorService;
        private readonly ILogger<TaxCalculationController> _logger;

        public TaxCalculationController(ITaxCalculatorService taxCalculatorService, ILogger<TaxCalculationController> logger)
        {
            this.taxCalculatorService = taxCalculatorService;
            _logger = logger;
        }

        [HttpGet(Name = "GetTaxCalculation")]
        public async Task<ActionResult<TaxCalculationResult>> Get(decimal salary)
        {
            var result = await this.taxCalculatorService.GetCalculatedTaxAsync(salary);

            return Ok(result);
        }
    }
}
