# The application should have a calculator
# The calculator should be able to add, subtract and recalculate celsius from fahrenheit
@UnitTest
Feature: Calculator

    Scenario: Add two numbers
        When I add 2 and 3
        Then the result should be 5

    Scenario: Subtract two numbers
        When I subtract 2 from 3
        Then the result should be 1

    # Scenario: Get fahrenheit from celsius
    #     When I ask for fahrenheit from -15 celsius
    #     Then the result should be 6
