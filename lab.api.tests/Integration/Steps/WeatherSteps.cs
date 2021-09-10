using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab.api.Controllers;
using lab.api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
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

        [When(@"i ask api for todays weather")]
        public async Task WhenIAskForTodaysWeatherAsync()
        {
            // Arrange
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<lab.api.Startup>();
            var testServer = new TestServer(builder);
            var client = testServer.CreateClient();

            // Act
            var responseMessage = await client.GetAsync("/WeatherForecast/1");
            responseMessage.EnsureSuccessStatusCode();
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            _result = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseJson).First();
        }
    }
}
