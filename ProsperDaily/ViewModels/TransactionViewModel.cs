using System.Windows.Input;
using PropertyChanged;
using ProsperDaily.Models;
using ProsperDaily.ViewModels.Base;


namespace ProsperDaily.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class TransactionViewModel : IViewModel
{
	public TransactionViewModel()
	{
		Transaction = new ();
	}

	public ICommand SaveTransactionCommand { get; set; }

	public Transaction Transaction { get; set; }

	public void SaveTransaction()
	{
		App.Repo.Save(Transaction);
	}
}
