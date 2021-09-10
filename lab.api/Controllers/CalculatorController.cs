using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Add/{value1}/{value2}")]
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}