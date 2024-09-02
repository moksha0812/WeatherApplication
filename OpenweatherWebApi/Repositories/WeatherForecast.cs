using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace OpenweatherWebApi.Repositories
{
    public class WeatherForecast : IWeatherForecast
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherForecast(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _apiKey = configuration["env:OPENWEATHER_API_KEY"];
        }

        public async Task<string> GetCurrentWeatherByCityAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                // Log the exception details
                // Return a user-friendly message
                throw new Exception("Error fetching current weather data. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                // Log the exception details
                throw new Exception("An unexpected error occurred while fetching current weather data.", ex);
            }
        }

        public async Task<string> GetWeatherForecastByCityAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching weather forecast data. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching weather forecast data.", ex);
            }
        }

        public async Task<(double lat, double lon)> GetCityCoordinatesAsync(string city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={_apiKey}");
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                var weatherData = JObject.Parse(data);

                double lat = (double)weatherData["coord"]["lat"];
                double lon = (double)weatherData["coord"]["lon"];

                return (lat, lon);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching city coordinates. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching city coordinates.", ex);
            }
        }

        public async Task<string> GetAirQualityByCityAsync(string city)
        {
            try
            {
                var (lat, lon) = await GetCityCoordinatesAsync(city);
                var response = await _httpClient.GetAsync($"http://api.openweathermap.org/data/2.5/air_pollution?lat={lat}&lon={lon}&appid={_apiKey}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching air quality data. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching air quality data.", ex);
            }
        }

        public async Task<string> GetCurrentWeatherByPincodeAsync(string pincode)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?zip={pincode},in&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error fetching weather data by pincode. Please try again later.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while fetching weather data by pincode.", ex);
            }
        }
    }
}
