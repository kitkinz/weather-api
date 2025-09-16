using WeatherApi.Models;

namespace WeatherApi.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    private static readonly string[] summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    // public static IEnumerable<Weather> GetForecast()
    // {
    //     return Enumerable.Range(1, 5).Select(index =>
    //     new Weather
    //     (
    //         DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //         Random.Shared.Next(-20, 55),
    //         summaries[Random.Shared.Next(summaries.Length)]
    //     ));
    // }

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiKey = Environment.GetEnvironmentVariable("VISUAL_CROSSING_API_KEY")
                ?? throw new InvalidOperationException("API key not found in environment variables.");
    }

    public async Task<Weather?> GetWeatherAsync(string city)
    {
        var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=metric&key={_apiKey}&contentType=json";

        try
        {
            var response = await _httpClient.GetFromJsonAsync<Weather>(url);
            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching weather: {ex.Message}");
            return null;
        }
    }
}