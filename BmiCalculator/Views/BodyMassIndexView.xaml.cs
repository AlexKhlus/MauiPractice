using BmiCalculator.ViewModels;


namespace BmiCalculator.Views;
public partial class BodyMassIndexView : ContentPage
{
	public BodyMassIndexView()
	{
		InitializeComponent();

		BindingContext = new BodyMassIndexViewModel();
	}
}

