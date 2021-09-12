using System.Linq;
using Xunit;
using FluentAssertions;
using Moq;
using Microsoft.Extensions.Logging;
using lab.api.Data;

namespace lab.api.tests.Units
{
    [Trait("Category","UnitTest")]
    public class CalculatorTests
    {
        [Theory]
        [InlineData(3, 3, 6)]
        [InlineData(3, -1, 2)]
        [InlineData(-3, -1, -4)]
        public void Verify_that_calculator_adds_values_correct(int value1, int value2, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(value1, value2);
            
            // Assert
            result
                .Should()
                .Be(expected);
        }

        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(3, 5, -2)]
        [InlineData(-3, -3, 0)]
        public void Verify_that_calculator_subtract_values_correct(int value1, int value2, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Subtract(value1, value2);
            
            // Assert
            result
                .Should()
                .Be(expected);
        }

        // [Theory]
        // [InlineData(10, 49)]
        // [InlineData(15, 58)]
        // [InlineData(43, 109)]
        // public void Verify_that_calculator_gets_fahrenheit_from_celsius_correct(int value, int expected)
        // {
        //     // Arrange
        //     var calculator = new Calculator();

        //     // Act
        //     var result = calculator.GetFahrenheitFromCelsius(value);
            
        //     // Assert
        //     result
        //         .Should()
        //         .Be(expected);
        // }
    }
}
