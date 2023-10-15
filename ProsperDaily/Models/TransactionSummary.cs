namespace ProsperDaily.Models;
public sealed class TransactionSummary
{
	public DateTime Date { get; set; }
	public string ShownDate { get; set; }
	public decimal Total { get; set; }
}
