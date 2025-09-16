using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;
    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    // [HttpGet]
    // public IEnumerable<Weather> Get()
    // {
    //     return WeatherService.GetForecast();
    // }

    [HttpGet("{city}")]
    public async Task<IActionResult> GetWeather(string city)
    {
        var result = await _weatherService.GetWeatherAsync(city);

        if (result == null)
        {
            return NotFound(new { message = "weather data not available" });
        }

        return Ok(result);
    }
}