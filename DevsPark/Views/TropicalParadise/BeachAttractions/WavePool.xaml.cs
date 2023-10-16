using DevsPark.Utils;
using DevsPark.Utils.Extensions;
using DevsPark.ViewModels;


namespace DevsPark.Views.TropicalParadise.BeachAttractions;

public partial class WavePool : ContentPage
{
	public WavePool(PlacesViewModel viewModel)
	{
		InitializeComponent();

		viewModel.SetCurrentPlace(this.GetName());
		BindingContext = viewModel;
	}
}