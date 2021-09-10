using lab.api.Contracts;

namespace lab.api.Data
{
    public class WeatherDataFromDatabase : IWeatherData
    {
        public int[] Temperatures
        {
            get
            {
                return new[]
                {
                    -15, 5, 15, 25, 30
                };
            }
        }
    }
}