using System;

namespace lab.api.Contracts
{
    public interface IWeatherData
    {
        int GetCelsiusTemperature(DateTime days);
    }
}