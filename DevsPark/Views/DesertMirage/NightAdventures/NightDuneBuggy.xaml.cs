using DevsPark.ViewModels;


namespace DevsPark.Views.DesertMirage.NightAdventures;

public partial class NightDuneBuggy : ContentPage
{
	public NightDuneBuggy(PlacesViewModel viewModel)
	{
		InitializeComponent();

        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}