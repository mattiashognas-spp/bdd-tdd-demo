using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using lab.api.Controllers;

namespace lab.api.tests
{
    public class WeatherTests
    {
        [Theory]
        [InlineData(3, new int[] { 10,20,30 }, new int[] { 49,67,85 }, new string[]{ "a", "b", "c" })]
        public void Verify_that_correct_weather_per_day_is_returned(int days, int[] celcius, int[] fahrenheits, string[] summaries)
        {
            // Arrange
            var logger = new Mock<ILogger<WeatherForecastController>>();
            var weatherData = new Mock<IWeatherData>();
            weatherData.Setup(x => x.Summaries).Returns(summaries);
            weatherData.Setup(x => x.Temperatures).Returns(celcius);

            // Act
            var weatherForecastController = new WeatherForecastController(logger.Object, weatherData.Object);
            var response = weatherForecastController.Get(days).ToList();
            
            // Assert
            response
                .Should()
                .NotBeEmpty()
                .And.HaveCount(3)
                .And.AllBeOfType<WeatherForecast>();
            response
                .Select(x => x.Summary)
                .Should()
                .ContainInOrder(summaries);
            response
                .Select(x => x.TemperatureC)
                .Should()
                .ContainInOrder(celcius);
            response
                .Select(x => x.TemperatureF)
                .Should()
                .ContainInOrder(fahrenheits);
        }
    }
}
