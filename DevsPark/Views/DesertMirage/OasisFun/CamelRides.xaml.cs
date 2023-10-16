using DevsPark.Utils;
using DevsPark.Utils.Extensions;
using DevsPark.ViewModels;


namespace DevsPark.Views.DesertMirage.OasisFun;

public partial class CamelRides : ContentPage
{
	public CamelRides(PlacesViewModel viewModel)
	{
		InitializeComponent();

        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}