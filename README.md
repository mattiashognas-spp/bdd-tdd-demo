# bdd-tdd-demo

BDD + TDD demo code

## Branches
demo-started    Demo ready     
demo-complete   Demo finished
master          Demo finished

## Procedure
- [ ] pull master
- [ ] dotnet add lab.api.tests package SpecFlow.xUnit --version 3.9.22
- [ ] dotnet add lab.api.tests package SpecFlow.Plus.LivingDocPlugin --version 3.9.57
- [ ] dotnet add lab.api.tests package Microsoft.AspNetCore.TestHost --version 5.0.9
- [ ] md .\lab.api.tests\Drivers
- [ ] md .\lab.api.tests\Features
- [ ] md .\lab.api.tests\Hooks
- [ ] md .\lab.api.tests\Steps
- [ ] make specflow.json containing:
```json
{ 
    "language": {
        "feature": "en-gb"
    }
}
```
- [ ] make lab.api.tests/Features/Add.feature containing:
```gherkin
Feature: Add
Scenario: Add two numbers
	When i add 2 and 3
	Then the result should be 5
```
- [ ] make Calculator.cs containing:
```csharp
namespace lab.api.Controllers
{
    public class Calculator
    {
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}
```
- [ ] dotnet test .\lab.api.tests
- [ ] make CalculatorSteps.cs containing:
```csharp
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
```
- [ ] dotnet test .\lab.api.tests
- [ ] done