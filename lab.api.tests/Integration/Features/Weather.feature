# The application should have a werather api
# The api should be able to return the date or the weather with weather in celsius and fahrenheit
@IntegrationTest
Feature: Weather

    Scenario: Get todays weather
        When I ask api for todays weather with celcius -15
        Then celsius should be -15
        And date should be today
        # And fahrenheit should be 6
