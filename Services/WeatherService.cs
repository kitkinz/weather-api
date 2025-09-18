using WeatherApi.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace WeatherApi.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly IDatabase _redis;

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

    public WeatherService(HttpClient httpClient, IDatabase redis)
    {
        _httpClient = httpClient;
        _apiKey = Environment.GetEnvironmentVariable("VISUAL_CROSSING_API_KEY")
                ?? throw new InvalidOperationException("API key not found in environment variables.");
        _redis = redis;
    }

    public async Task<Weather?> GetWeatherAsync(string city)
    {
        var cachedResult = await _redis.StringGetAsync(city);

        if (!string.IsNullOrEmpty(cachedResult))
        {
            Console.WriteLine($"Cached: {city}");
            return JsonSerializer.Deserialize<Weather>(cachedResult);
        }

        var url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=metric&key={_apiKey}&contentType=json";

        try
        {
            var response = await _httpClient.GetFromJsonAsync<Weather>(url);

            if (response != null)
            {
                Console.WriteLine($"Not Cached: {city}");
                var json = JsonSerializer.Serialize(response);
                await _redis.StringSetAsync(city, json, TimeSpan.FromHours(1));
            }

            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching weather: {ex.Message}");
            return null;
        }
    }
}