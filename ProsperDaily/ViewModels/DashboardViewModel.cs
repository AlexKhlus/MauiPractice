using System.Collections.ObjectModel;
using PropertyChanged;
using ProsperDaily.Extensions;
using ProsperDaily.Models;
using ProsperDaily.Repositories.Base;


namespace ProsperDaily.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class DashboardViewModel : IViewModel
{

	public DashboardViewModel()
	{
		Transactions = new ();

		Balance = Income = Expenses = 0;

        UpdateData();
	}

	public decimal Balance { get; set; }
	public decimal Income { get; set; }
	public decimal Expenses { get; set; }

	public ObservableCollection<Transaction> Transactions { get; set; }

	public void UpdateData()
	{
		Transactions.Clear();
		Balance = Income = Expenses = 0;

		var transactions = App.Repo.GetList()
			.OrderByDescending(transaction => transaction.Date)
			.ToList();

		Transactions.AddRange(transactions);

		foreach(var transaction in Transactions)
		{
			if(transaction.Income) Income += transaction.Amount;
			else Expenses += transaction.Amount;
		}

		Balance = Income - Expenses;
	}
}
