Feature: Weather
Scenario: Get 1 day of weather
    When i get todays weather
    Then celcius should be -15
    And fahrenheit should be 6
