using DevsPark.Utils;
using DevsPark.Utils.Extensions;
using DevsPark.ViewModels;


namespace DevsPark.Views.TropicalParadise.JungleAdventures;

public partial class AnimalShows : ContentPage
{
	public AnimalShows(PlacesViewModel viewModel)
	{
		InitializeComponent();

		viewModel.SetCurrentPlace(this.GetName());
		BindingContext = viewModel;
	}
}