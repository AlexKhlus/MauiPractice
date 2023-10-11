using System.Globalization;
using SkiaSharp.Extended.UI.Controls;


namespace Weather.Converters;
public sealed class WeatherCodeToLottie : IValueConverter
{
	private readonly Dictionary<int, string> _lottieImages = new () {
		{ 0, "sunny.json" },
		{ 1, "sunny.json" },
		{ 2, "foggy.json" },
		{ 3, "foggy.json" },
		{ 45, "foggy.json" },
		{ 48, "foggy.json" },
		{ 51, "partly-shower.json" },
		{ 53, "partly-shower.json" },
		{ 55, "partly-shower.json" },
		{ 56, "partly-shower.json" },
		{ 57, "partly-shower.json" },
		{ 61, "storm-n-shower.json" },
		{ 63, "storm-n-shower.json" },
		{ 65, "storm-n-shower.json" },
		{ 66, "snow.json" },
		{ 67, "snow.json" },
		{ 71, "snow.json" },
		{ 73, "snow.json" },
		{ 75, "snow.json" },
		{ 77, "snow.json" },
		{ 80, "storm.json" },
		{ 81, "storm.json" },
		{ 82, "storm.json" },
		{ 85, "storm.json" },
		{ 86, "storm.json" },
		{ 95, "storm.json" },
		{ 96, "storm.json" },
		{ 99, "storm.json" },
	};

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		var code = (int)value;
		var lottieImageSource = new SKFileLottieImageSource {
			File = _lottieImages[code]
		};

		return lottieImageSource;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}
