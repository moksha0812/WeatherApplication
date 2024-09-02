using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenweatherWebApi.Models
{
    public class WeatherForecastItem
    {
        public int Dt { get; set; }
    public Main Main { get; set; }
    public List<Weather> Weather { get; set; }
    public Clouds Clouds { get; set; }
    public Wind Wind { get; set; }
    public int Dt_txt { get; set; }
    }
}