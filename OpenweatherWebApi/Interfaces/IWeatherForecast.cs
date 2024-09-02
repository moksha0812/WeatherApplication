using System.Threading.Tasks;
 
namespace OpenweatherWebApi.Repositories
{
    public interface IWeatherForecast
    {
        Task<string> GetCurrentWeatherByCityAsync(string city);
        Task<string> GetWeatherForecastByCityAsync(string city);
        Task<string> GetAirQualityByCityAsync(string city);
        Task<string> GetCurrentWeatherByPincodeAsync(string pincode);
        Task<(double lat, double lon)> GetCityCoordinatesAsync(string city);
    }
}