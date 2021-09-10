using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherData _weatherData;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherData weatherData)
        {
            _logger = logger;
            _weatherData = weatherData;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(int days = 5)
        {
            return Enumerable.Range(0, days).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index+1),
                TemperatureC = _weatherData.Temperatures[index],
                Summary = _weatherData.Summaries[index]
            })
            .ToArray();
        }
    }
}
