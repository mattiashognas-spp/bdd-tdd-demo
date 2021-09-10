using System;
using System.Collections.Generic;
using System.Linq;

public interface IWeatherData
{
    string[] Summaries { get; }
    int[] Temperatures { get; }
}