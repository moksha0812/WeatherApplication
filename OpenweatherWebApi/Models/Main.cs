using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenweatherWebApi.Models
{
    public class Main
    {
        public float Temp { get; set; }
    public float Feels_Like { get; set; }
    public float Temp_Min { get; set; }
    public float Temp_Max { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    }
}