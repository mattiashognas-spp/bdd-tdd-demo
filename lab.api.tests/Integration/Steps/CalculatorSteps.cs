using System.Threading.Tasks;
using lab.api.Contracts;
using lab.api.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace lab.api.tests.Integration
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly ScenarioContext _scenarioContext;
        public CalculatorSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        private int _result
        {
            get
            {
                return (int)_scenarioContext["_result"];
            }
            set
            {
                _scenarioContext["_result"] = value;
            }
        }

        [When(@"i ask api to add (.*) and (.*)")]
        public async Task WhenIAddAndAsync(int value0, int value1)
        {
            // Arrange
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var weatherData = new Mock<IWeatherData>();
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<lab.api.Startup>();
            var testServer = new TestServer(builder);
            var client = testServer.CreateClient();

            // Act
            var responseMessage = await client.GetAsync("/Calculator/Add/" + value0 + "/" + value1);
            responseMessage.EnsureSuccessStatusCode();
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            _result = JsonConvert.DeserializeObject<int>(responseJson);
        }
    }
}
