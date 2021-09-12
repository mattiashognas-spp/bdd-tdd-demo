using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using lab.api.Contracts;
using lab.api.Controllers;
using lab.api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace lab.api.tests.Integration
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

        [When(@"I ask api for todays weather with celcius (.*)")]
        public async Task WhenIAskApiForTodaysWeatherWithCelsiusAsync(int celcius)
        {
            // Arrange
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var weatherData = new Mock<IWeatherData>();
            weatherData.Setup(x => x.GetCelsiusTemperature(It.IsAny<DateTime>())).Returns(celcius);
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<lab.api.Startup>()
                .ConfigureTestServices(services => services.AddScoped<IWeatherData>((x) => weatherData.Object));
            var testServer = new TestServer(builder);
            var client = testServer.CreateClient();

            // Act
            var responseMessage = await client.GetAsync("/WeatherForecast/1");
            responseMessage.EnsureSuccessStatusCode();
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            _result = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseJson).First();
        }

        [Then(@"celsius should be (.*)")]
        public void ThenApiShouldReturnCelciusAndTodaysDate(int celcius)
        {
            _result.TemperatureC.Should().Be(celcius);
        }

        [Then(@"date should be today")]
        public void ThenTodaysDate()
        {
            _result.Date.Day.Should().Be(DateTime.Now.Day);
        }
        
        // [Then(@"fahrenheit should be (.*)")]
        // public void ThenFahrenheitShouldBe(int fahrenheit)
        // {
        //     _result.TemperatureF.Should().Be(fahrenheit);
        // }
    }
}
