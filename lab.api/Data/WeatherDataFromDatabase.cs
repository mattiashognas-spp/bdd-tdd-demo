using System;
using lab.api.Contracts;

namespace lab.api.Data
{
    public class WeatherDataFromDatabase : IWeatherData
    {
        public int GetCelsiusTemperature(DateTime date)
        {
            var rnd = new Random();
            return rnd.Next(-40, 50);
        }
    }
}