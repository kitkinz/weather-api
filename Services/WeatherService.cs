using WeatherApi.Models;

namespace WeatherApi.Services;

public static class WeatherService
{
    private static readonly string[] summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public static IEnumerable<Weather> GetForecast()
    {
        return Enumerable.Range(1, 5).Select(index =>
        new Weather
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ));
    }
}