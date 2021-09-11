using System;
using System.Collections.Generic;
using System.Linq;
using lab.api.Contracts;
using lab.api.Models;
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
        private readonly ICalculator _calculator;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWeatherData weatherData,
            ICalculator calculator)
        {
            _logger = logger;
            _weatherData = weatherData;
            _calculator = calculator;
        }

        [HttpGet("{days?}")]
        public IEnumerable<WeatherForecast> Get(int days = 5)
        {
            return Enumerable
                .Range(0, days)
                .Select(index => 
                    new WeatherForecast(
                        DateTime.Now.AddDays(index+1),
                        _weatherData.Temperatures[index],
                        _calculator.GetFahrenheitFromCelsius(_weatherData.Temperatures[index])))
                .ToArray();
        }
    }
}
