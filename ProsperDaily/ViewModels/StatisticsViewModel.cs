using System.Collections.ObjectModel;
using PropertyChanged;
using ProsperDaily.Extensions;
using ProsperDaily.Models;


namespace ProsperDaily.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class StatisticsViewModel : IViewModel
{
	public StatisticsViewModel()
	{
		Summary = new ();
		Spends = new ();
	}

	public ObservableCollection<TransactionSummary> Summary { get; set; }
	public ObservableCollection<Transaction> Spends { get; set; }

	public void GetSummary()
	{
		Summary.Clear();
		Spends.Clear();
		var transactions = App.Repo.GetList();
		var groupedTransactions = transactions.GroupBy(transaction => transaction.Date);

		Summary.AddRange(groupedTransactions.
			Select(group =>
				new TransactionSummary {
					Date = group.Key,
					Total = group.Sum(item => item.Income ? item.Amount : -item.Amount),
					ShownDate = group.Key.ToString("MM/dd")
				})
			.OrderBy(transaction => transaction.Date)
			.ToList()
		);

		Spends.AddRange(transactions.Where(transaction => transaction.Income is false));
	}
}
