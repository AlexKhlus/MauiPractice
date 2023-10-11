using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Weather.Models;
public sealed class WeatherData
{
    public WeatherData()
    {
        Dailies = new ();
    }

    [JsonProperty("latitude")] public double Latitude { get; set; }
    [JsonProperty("longitude")] public double Longitude { get; set; }
    [JsonProperty("generationtime_ms")] public double GenerationTime { get; set; }
    [JsonProperty("utc_offset_seconds")] public int UtcOffsetSeconds { get; set; }
    [JsonProperty("timezone")] public string TimeZone { get; set; }
    [JsonProperty("timezone_abbreviation")] public string TimeZoneAbbreviation { get; set; }
    [JsonProperty("elevation")] public double Elevation { get; set; }
    [JsonProperty("current_weather")] public CurrentWeather CurrentWeather { get; set; }
    [JsonProperty("daily_units")] public DailyUnits DailyUnits { get; set; }
    [JsonProperty("daily")] public Daily Daily { get; set; }

    public ObservableCollection<DailyDTO> Dailies { get; set; }
}

public sealed class CurrentWeather
{
    [JsonProperty("temperature")] public double Temperature { get; set; }
    [JsonProperty("windspeed")] public double WindSpeed { get; set; }
    [JsonProperty("winddirection")] public double WindDirection { get; set; }
    [JsonProperty("weathercode")] public int WeatherCode { get; set; }
    [JsonProperty("is_day")] public int IsDay { get; set; }
    [JsonProperty("time")] public string Time { get; set; }
}

public sealed class DailyUnits
{
    [JsonProperty("time")] public string Time { get; set; }
    [JsonProperty("weathercode")] public string WeatherCode { get; set; }
    [JsonProperty("temperature_2m_max")] public string TemperatureMax { get; set; }
    [JsonProperty("temperature_2m_min")] public string TemperatureMin { get; set; }
}

public sealed class Daily
{
    [JsonProperty("time")] public List<string> Time { get; set; }
    [JsonProperty("weathercode")] public List<int> WeatherCode { get; set; }
    [JsonProperty("temperature_2m_max")] public List<double> TemperatureMax { get; set; }
    [JsonProperty("temperature_2m_min")] public List<double> TemperatureMin { get; set; }
}

public sealed class DailyDTO
{
    public string Time { get; set; }
    public int WeatherCode { get; set; }
    public double TemperatureMax { get; set; }
    public double TemperatureMin { get; set; }
}