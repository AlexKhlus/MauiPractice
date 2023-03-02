using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;
using UnitsNet;


namespace UnitConverter.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class ConverterViewModel : IViewModel
{
	public ConverterViewModel(string quantityName)
	{
		QuantityName = quantityName;
		FromMeasures = LoadMeasures();
		ToMeasures = LoadMeasures();

		CurrentFromMeasure = FromMeasures.FirstOrDefault();
		CurrentToMeasure = ToMeasures.Skip(1).FirstOrDefault();
		FromValue = 1;

		ReturnCommand = new Command(Convert);

		Convert();
	}

	public string QuantityName { get; set; }
	public ObservableCollection<string> FromMeasures { get; set; }
	public ObservableCollection<string> ToMeasures { get; set; }

	public string CurrentFromMeasure { get; set; }
	public string CurrentToMeasure { get; set; }
	public double FromValue { get; set; }
	public double ToValue { get; set; }

	public ICommand ReturnCommand { get; }

	public void Convert()
	{
		var result = UnitsNet.UnitConverter.ConvertByName
		(
			FromValue,
			QuantityName,
			fromUnit: CurrentFromMeasure,
			toUnit: CurrentToMeasure
		);
		ToValue = result;
	}

	private ObservableCollection<string> LoadMeasures()
	{
		var types = Quantity.Infos.FirstOrDefault(info => info.Name.Equals(QuantityName))!
			.UnitInfos.Select(info => info.Name).ToList();
		return new (types!);
	}
}