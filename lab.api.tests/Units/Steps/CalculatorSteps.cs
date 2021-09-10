using FluentAssertions;
using lab.api.Controllers;
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

        [When(@"i add (.*) and (.*)")]
        public void WhenIAddAnd(int value0, int value1)
        {
            var logger = new Mock<ILogger<CalculatorController>>();
            var calculator = new CalculatorController(logger.Object);
            _result = calculator.Add(value0, value1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            _result.Should().Be(result);
        }
    }
}
