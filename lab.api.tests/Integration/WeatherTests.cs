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
using Xunit;

namespace lab.api.tests.Integration
{
    [Trait("Category","IntegrationTest")]
    public class WeatherTests
    {
        [Theory]
        [InlineData(
            3
            ,new int[] { 10, 20, 30 }
            //,new int[] { 49, 67, 85 }
            )]
        public async Task Verify_that_correct_weather_is_calculated_correct(
            int days
            ,int[] celcius
            //,int[] fahrenheits
            )
        {
            // Arrange
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var weatherData = new Mock<IWeatherData>();
            weatherData.Setup(x => x.GetCelsiusTemperature(It.Is<DateTime>((d) => d.Day == DateTime.Now.Day))).Returns(celcius[0]);
            weatherData.Setup(x => x.GetCelsiusTemperature(It.Is<DateTime>((d) => d.Day == DateTime.Now.AddDays(1).Day))).Returns(celcius[1]);
            weatherData.Setup(x => x.GetCelsiusTemperature(It.Is<DateTime>((d) => d.Day == DateTime.Now.AddDays(2).Day))).Returns(celcius[2]);
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<lab.api.Startup>()
                .ConfigureTestServices(services => services.AddScoped<IWeatherData>((x) => weatherData.Object));
            var testServer = new TestServer(builder);
            var client = testServer.CreateClient();

            // Act
            var responseMessage = await client.GetAsync("/WeatherForecast/" + days);
            responseMessage.EnsureSuccessStatusCode();
            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseJson);
            
            // Assert
            response
                .Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.AllBeOfType<WeatherForecast>();
            response
                .Select(x => x.TemperatureC)
                .Should()
                .ContainInOrder(celcius);
            // response
            //     .Select(x => x.TemperatureF)
            //     .Should()
            //     .ContainInOrder(fahrenheits);
        }
    }
}
