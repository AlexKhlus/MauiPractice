using BmiCalculator.Models;
using PropertyChanged;


namespace BmiCalculator.ViewModels;

[AddINotifyPropertyChangedInterface]
public class BodyMassIndexViewModel : IViewModel
{
	public BodyMassIndexViewModel()
	{
		BodyMassIndex = new () {
			Height = 180,
			Weight = 73
		};
	}

	public BodyMassIndex BodyMassIndex { get; set; }
}