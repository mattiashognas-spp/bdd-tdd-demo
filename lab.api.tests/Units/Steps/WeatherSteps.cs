using System.Linq;
using FluentAssertions;
using lab.api.Controllers;
using lab.api.Data;
using lab.api.Models;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace lab.api.tests.Steps
{
    [Binding]
    public class WeatherSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public WeatherSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        private WeatherForecast _result
        {
            get
            {
                return (WeatherForecast)_scenarioContext["_result"];
            }
            set
            {
                _scenarioContext["_result"] = value;
            }
        }

        [When(@"i get todays weather")]
        public void WhenIAskForTodaysWeather()
        {
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var weatherData = new WeatherDataFromDatabase();
            var weatherForecastController = new WeatherForecastController(logger.Object, weatherData);
            _result = weatherForecastController.Get(1).First();
        }

        [Then(@"celcius should be (.*)")]
        public void ThenCelciusShouldBe(int celcius)
        {
            _result.TemperatureC.Should().Be(celcius);
        }
        
        [Then(@"fahrenheit should be (.*)")]
        public void ThenFahrenheitShouldBe(int fahrenheit)
        {
            _result.TemperatureF.Should().Be(fahrenheit);
        }
    }
}
