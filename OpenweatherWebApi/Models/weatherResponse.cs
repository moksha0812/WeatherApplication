using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenweatherWebApi.Models
{
    public class weatherResponse
    {
         public Coord Coord { get; set; }
    public Weather[] Weather { get; set; }
    public string Base { get; set; }
    public Main Main { get; set; }
    public int Visibility { get; set; }
    public Wind Wind { get; set; }
    public Clouds Clouds { get; set; }
    public int Dt { get; set; }
    public Sys Sys { get; set; }
    public int Timezone { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cod { get; set; }
    }
}