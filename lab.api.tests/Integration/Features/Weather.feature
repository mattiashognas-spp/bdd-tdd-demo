# The application should have a werather api
# The api should be able to return the date or the weather with weather in celsius and fahrenheit
Feature: Weather

    Scenario: Get 1 day of weather
        When i ask api for todays weather
        Then celcius should be -15
        And fahrenheit should be 6
