using DevsPark.ViewModels;


namespace DevsPark.Views.Frozen.IcyTreats;

public partial class FrozenDrinksBar : ContentPage
{
	public FrozenDrinksBar(PlacesViewModel viewModel)
	{
		InitializeComponent();

        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}