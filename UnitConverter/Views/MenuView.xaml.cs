using UnitConverter.ViewModels;


namespace UnitConverter.Views;
public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}
	private void OnTapped(object sender, TappedEventArgs e)
	{
		var labelText = ((sender as Grid)?.Children.LastOrDefault() as Label)?.Text;
		Navigation.PushAsync(new ConverterView() {
			BindingContext = new ConverterViewModel(labelText)
		});
	}
}

