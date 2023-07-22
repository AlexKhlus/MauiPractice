using BmiCalculator.ViewModels;
using Microsoft.Maui.Controls;


namespace BmiCalculator.Views;
public partial class BodyMassIndexView : ContentPage
{
	public BodyMassIndexView()
	{
		InitializeComponent();

		BindingContext = new BodyMassIndexViewModel();
	}
}

