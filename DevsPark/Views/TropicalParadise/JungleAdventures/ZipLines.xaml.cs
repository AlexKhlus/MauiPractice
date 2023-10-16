using DevsPark.ViewModels;


namespace DevsPark.Views.TropicalParadise.JungleAdventures;

public partial class ZipLines : ContentPage
{
	public ZipLines(PlacesViewModel viewModel)
	{
		InitializeComponent();

		viewModel.SetCurrentPlace(this.GetName());
		BindingContext = viewModel;
	}
}