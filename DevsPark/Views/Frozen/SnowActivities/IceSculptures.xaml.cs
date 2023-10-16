using DevsPark.ViewModels;


namespace DevsPark.Views.Frozen.SnowActivities;

public partial class IceSculptures : ContentPage
{
	public IceSculptures(PlacesViewModel viewModel)
	{
		InitializeComponent();
        viewModel.SetCurrentPlace(this.GetName());
        BindingContext = viewModel;
    }
}