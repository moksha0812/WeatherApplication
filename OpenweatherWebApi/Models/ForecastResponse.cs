using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenweatherWebApi.Models
{
    public class ForecastResponse
    {
        public City City { get; set; }
    public List<List<WeatherForecastItem>> List { get; set; }
    }
}