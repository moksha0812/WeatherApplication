using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OpenweatherWebApi.Repositories;

namespace OpenweatherWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherForecast _weatherRepository;

        public WeatherController(IWeatherForecast weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        // GET: api/weather/current?city={city}
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather(string city)
        {
            try
            {
                var weatherData = await _weatherRepository.GetCurrentWeatherByCityAsync(city);
                return Ok(weatherData);
            }
            catch (HttpRequestException ex)
            {
                // Log the exception details if necessary
                return StatusCode(500, "Error fetching current weather data. Please try again later.");
            }
            catch (Exception ex)
            {
                // Log the exception details if necessary
                return StatusCode(500, "An unexpected error occurred while fetching current weather data.");
            }
        }

        // GET: api/weather/forecast?city={city}
        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeatherForecast(string city)
        {
            try
            {
                var forecastData = await _weatherRepository.GetWeatherForecastByCityAsync(city);
                return Ok(forecastData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, "Error fetching weather forecast data. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while fetching weather forecast data.");
            }
        }

        // GET: api/weather/airquality?city={city}
        [HttpGet("airquality")]
        public async Task<IActionResult> GetAirQuality(string city)
        {
            try
            {
                var airQualityData = await _weatherRepository.GetAirQualityByCityAsync(city);
                return Ok(airQualityData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, "Error fetching air quality data. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while fetching air quality data.");
            }
        }

        // GET: api/weather/currentbypincode?pincode={pincode}
        [HttpGet("currentbypincode")]
        public async Task<IActionResult> GetCurrentWeatherByPincode(string pincode)
        {
            try
            {
                var weatherData = await _weatherRepository.GetCurrentWeatherByPincodeAsync(pincode);
                Console.WriteLine(weatherData);
                return Ok(weatherData);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, "Error fetching weather data by pincode. Please try again later.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while fetching weather data by pincode.");
            }
        }
    }
}
