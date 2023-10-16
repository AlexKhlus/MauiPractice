using DevsPark.ViewModels;


namespace DevsPark.Views.DesertMirage.NightAdventures;

public partial class StarGazing : ContentPage
{
	public StarGazing(PlacesViewModel viewModel)
	{
		InitializeComponent();

        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}