namespace WeatherApi.Models;

public class Weather()
{
    public string? ResolvedAddress { get; set; }
    public CurrentConditions? CurrentConditions { get; set; }
    // public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class CurrentConditions
{
    public decimal Temp { get; set; }
    public string? Conditions { get; set; }
}