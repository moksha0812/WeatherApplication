using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenweatherWebApi.Models
{
    public class City
    {
        public string Name { get; set; }
    public Coord Coord { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }
    }
}