using FluentAssertions;
using lab.api.Controllers;
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
        private int _result { get; set; }

        [When(@"i add (.*) and (.*)")]
        public void WhenIAddAnd(int p0, int p1)
        {
            var calculator = new Calculator();
            _result = calculator.Add(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            _result.Should().Be(p0);
        }
    }
}
