using ProsperDaily.ViewModels;


namespace ProsperDaily.Views;
public partial class StatisticView : ContentPage
{
	public StatisticView()
	{
		InitializeComponent();

		BindingContext = new StatisticsViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		(BindingContext as StatisticsViewModel)?.GetSummary();
	}
}

