using DevsPark.ViewModels;


namespace DevsPark.Views;
public partial class FeaturedView : ContentPage
{
	public FeaturedView(FeaturedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

