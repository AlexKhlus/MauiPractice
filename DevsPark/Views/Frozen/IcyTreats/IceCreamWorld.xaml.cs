using DevsPark.Utils;
using DevsPark.Utils.Extensions;
using DevsPark.ViewModels;


namespace DevsPark.Views.Frozen.IcyTreats;

public partial class IceCreamWorld : ContentPage
{
	public IceCreamWorld(PlacesViewModel viewModel)
	{
		InitializeComponent();

        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}