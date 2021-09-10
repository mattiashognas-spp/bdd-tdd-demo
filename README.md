# bdd-tdd-demo

BDD + TDD demo code

## Branches
master              Before specflow is added
adding-specflow     Finished

## Procedure
pull master
dotnet add lab.api.tests package SpecFlow.xUnit --version 3.9.22
dotnet add lab.api.tests package SpecFlow.Plus.LivingDocPlugin --version 3.9.57
md .\lab.api.tests\Drivers
md .\lab.api.tests\Features
md .\lab.api.tests\Hooks
md .\lab.api.tests\Steps
make specflow.json containing:
{ 
    "language": {
        "feature": "en-gb"
    }
}
make lab.api.tests/Features/Add.feature containing:
Feature: Add
Scenario: Add two numbers
	When i add 2 and 3
	Then the result should be 5
make Calculator.cs containing:
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
dotnet test .\lab.api.tests
implement missing steps
dotnet test .\lab.api.tests
done