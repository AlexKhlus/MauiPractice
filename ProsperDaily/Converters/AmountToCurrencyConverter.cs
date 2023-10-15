using System.Globalization;


namespace ProsperDaily.Converters;
public sealed class AmountToCurrencyConverter : IValueConverter
{

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		var isIncome = (parameter as Label)?.Text ?? "False";
		var amount = (decimal)value;
		return isIncome.Equals("True") ? $"+ {amount:C}" : $"- {amount:C}";
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		=> throw new NotImplementedException();
}
