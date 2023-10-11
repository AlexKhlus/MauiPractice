using System.Text.Json;
using System.Windows.Input;
using Newtonsoft.Json;
using PropertyChanged;
using Weather.Models;


namespace Weather.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class WeatherViewModel : IViewModel
{
	private readonly HttpClient _client;
	private readonly string _apiUrl;
	private readonly string _constantParameters;

	public WeatherViewModel()
	{
		_client = new ();
		_apiUrl = "https://api.open-meteo.com/v1/forecast";
		_constantParameters = "daily=weathercode,temperature_2m_max,temperature_2m_min&current_weather=true&windspeed_unit=ms&timezone=Europe%2FBerlin";

		LocationName = "Neverland";
		Date = DateTime.Now;

		IsVisible = false;
		IsLoading = false;

		SearchCommand = new Command(Search);
	}

	public WeatherData WeatherData { get; set; }
	public string LocationName { get; set; }
	public DateTime Date { get; set; }
	public bool IsVisible { get; set; }
	public bool IsLoading { get; set; }

	public ICommand SearchCommand { get; }

	private async Task<WeatherData> GetWeather(Location location)
	{
		IsLoading = true;

		var url = $"{_apiUrl}?latitude={location.Latitude}&longitude={location.Longitude}&{_constantParameters}";
		var response = await _client.GetAsync(url);

		if(response.IsSuccessStatusCode)
		{
			var responseContent = await response.Content.ReadAsStringAsync();
			var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);

			for(var i = 0; i < weatherData.Daily.Time.Count; i++)
			{
				var dailyUnits = new DailyDTO() {
					Time = weatherData.Daily.Time[i],
					TemperatureMax = weatherData.Daily.TemperatureMax[i],
					TemperatureMin = weatherData.Daily.TemperatureMin[i],
					WeatherCode = weatherData.Daily.WeatherCode[i]
				};
				weatherData.Dailies.Add(dailyUnits);
			}

			IsVisible = true;
			IsLoading = false;

			return weatherData;
		}

		IsLoading = false;

		return new ();
	}

	private async void Search(object parameter)
	{
		var location = parameter as string ?? string.Empty;
		LocationName = location;
		WeatherData = await GetWeather(await GetCoordinatesAsync(location));
	}

	private async Task<Location> GetCoordinatesAsync(string address)
		=> (await Geocoding.Default.GetLocationsAsync(address)).FirstOrDefault();
}
