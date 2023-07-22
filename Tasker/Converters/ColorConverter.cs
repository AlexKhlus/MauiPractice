using System.Globalization;


namespace Tasker.Converters;
public sealed class ColorConverter : IValueConverter
{

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		=> Color.FromArgb(value.ToString());

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}
