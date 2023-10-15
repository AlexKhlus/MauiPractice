using System;
using Humanizer;
using ProsperDaily.Repositories.Base;


namespace ProsperDaily.Models;
public sealed class Transaction : TableData
{
	public string Name { get; set; }
	public decimal Amount { get; set; }
	public DateTime Date { get; set; }
	public bool Income { get; set; }

	public string HumanDate
	{
		get => Date.Humanize();
	}
}
