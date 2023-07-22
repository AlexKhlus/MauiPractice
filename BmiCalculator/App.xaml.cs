using BmiCalculator.Views;
using Microsoft.Maui.Controls;


namespace BmiCalculator;
public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new BodyMassIndexView();
	}
}
