using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lab.api.Data
{
    public class WeatherDataFromDatabase : IWeatherData
    {
        public string[] Summaries 
        {
            get
            {
                return new[]
                {
                    "Freezing", "Cool", "Mild", "Warm", "Hot"
                };
            }
        }

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