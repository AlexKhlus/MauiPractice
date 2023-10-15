using ProsperDaily.ViewModels;


namespace ProsperDaily.Views;
public partial class DashboardView : ContentPage
{

	public DashboardView()
	{
		InitializeComponent();

		BindingContext = new DashboardViewModel();
	}
	private async void OnAddTransactionClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new TransactionView());
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		(BindingContext as DashboardViewModel)?.UpdateData();
	}
}

