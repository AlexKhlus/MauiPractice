using Calculator.ViewModels;


namespace Calculator.Views;
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new CalculatorViewModel();
	}
}
