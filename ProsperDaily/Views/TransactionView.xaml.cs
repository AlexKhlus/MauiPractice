using ProsperDaily.ViewModels;


namespace ProsperDaily.Views;
public partial class TransactionView : ContentPage
{
	public TransactionView()
	{
		InitializeComponent();

		BindingContext = new TransactionViewModel();
	}

	private async void OnSaveClicked(object sender, EventArgs e)
	{
		(BindingContext as TransactionViewModel)?.SaveTransaction();
		await Navigation.PopToRootAsync();
	}

	private async void OnCancelClicked(object sender, EventArgs e)
		=> await Navigation.PopToRootAsync();
}

