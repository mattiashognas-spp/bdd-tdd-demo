using FluentAssertions;
using lab.api.Data;
using Microsoft.Extensions.Logging;
using Moq;
using TechTalk.SpecFlow;

namespace lab.api.tests.Steps
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

        [When(@"I add (.*) and (.*)")]
        public void WhenIAddAnd(int value0, int value1)
        {
            var calculator = new Calculator();
            _result = calculator.Add(value0, value1);
        }

        [When(@"I subtract (.*) from (.*)")]
        public void WhenISubtractFrom(int value0, int value1)
        {
            var calculator = new Calculator();
            _result = calculator.Subtract(value1, value0);
        }

        // [When(@"I ask for fahrenheit from (.*) celsius")]
        // public void WhenIAskForFahrenheitFromCelsius(int value0)
        // {
        //     var calculator = new Calculator();
        //     _result = calculator.GetFahrenheitFromCelsius(value0);
        // }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}
