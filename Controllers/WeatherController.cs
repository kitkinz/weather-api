using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    public WeatherController()
    {

    }

    [HttpGet]
    public IEnumerable<Weather> Get()
    {
        return WeatherService.GetForecast();
    }
}