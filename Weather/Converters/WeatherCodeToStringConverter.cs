using System.Globalization;


namespace Weather.Converters;
public sealed class WeatherCodeToStringConverter : IValueConverter
{
	private readonly Dictionary<int, string> _weatherCodes = new () {
		{ 0, "Clear Sky" },
		{ 1, "Mainly Clear" },
		{ 2, "Partly Cloudy" },
		{ 3, "Overcast" },
		{ 45, "Fog" },
		{ 48, "Depositing Rime Fog" },
		{ 51, "Drizzle: Light" },
		{ 53, "Drizzle: Moderate" },
		{ 55, "Drizzle: Dense Intensity" },
		{ 56, "Freezing Drizzle: Light" },
		{ 57, "Freezing Drizzle: Dense Intensity" },
		{ 61, "Rain: Slight" },
		{ 63, "Rain: Moderate" },
		{ 65, "Rain: Heavy Intensity" },
		{ 66, "Freezing Rain: Light" },
		{ 67, "Freezing Rain: Heavy Intensity" },
		{ 71, "Snow Fall: Slight" },
		{ 73, "Snow Fall: Moderate" },
		{ 75, "Snow Fall: Heavy Intensity" },
		{ 77, "Snow Grains" },
		{ 80, "Rain Showers: Slight" },
		{ 81, "Rain Showers: Moderate" },
		{ 82, "Rain Showers: Violent" },
		{ 85, "Snow Showers: Slight" },
		{ 86, "Snow Showers: Heavy" },
		{ 95, "Thunderstorm: Slight or Moderate" },
		{ 96, "Thunderstorm with Slight" },
		{ 99, "Thunderstorm with Heavy Hail" },
	};

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		=> _weatherCodes[(int)value] ?? "Unknown";

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}
