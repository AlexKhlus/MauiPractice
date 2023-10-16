namespace DevsPark.Views.TropicalParadise.JungleAdventures;

public partial class AnimalShows : ContentPage
{
	public AnimalShows(LoactionsViewModel viewModel)
	{
		InitializeComponent();

		viewModel.SetCurrentPlace(this.GetName());
		BindingContext = viewModel;
	}
}