using DevsPark.Utils;
using DevsPark.Utils.Extensions;
using DevsPark.ViewModels;


namespace DevsPark.Views.Frozen.SnowActivities;

public partial class Snowboarding : ContentPage
{
	public Snowboarding(PlacesViewModel viewModel)
	{
		InitializeComponent();
        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}