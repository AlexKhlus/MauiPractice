using System.Collections.ObjectModel;
using System.Collections.Specialized;
using PropertyChanged;
using Tasker.Models;
using Task = Tasker.Models.Task;


namespace Tasker.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class MainViewModel : IViewModel
{
	public MainViewModel()
	{
		FillData();
		Tasks.CollectionChanged += TasksOnCollectionChanged;
	}

	public ObservableCollection<Category> Categories { get; set; }
	public ObservableCollection<Task> Tasks { get; set; }

	public void UpdateData()
	{
		foreach(var category in Categories)
		{
			var tasks = Tasks.Where(task => task.CategoryId == category.Id).ToList();

			category.PendingTasks = tasks.Count(task => task.Completed is false);
			category.Percentage = (float)tasks.Count(task => task.Completed) / tasks.Count;
		}

		foreach(var task in Tasks)
		{
			task.Color = Categories
				.Where(category => category.Id == task.CategoryId)
				.Select(category => category.Color)
				.FirstOrDefault();
		}
	}

	private void FillData()
	{
		Categories = new () {
			new () {
				Id = 1,
				Name = ".NET MAUI Course",
				Color = "#cf14df"
			},
			new () {
				Id = 2,
				Name = "Tutorials",
				Color = "#df6f14"
			},
			new () {
				Id = 3,
				Name = "Shopping",
				Color = "#14df80"
			}
		};
		Tasks = new () {
			new () {
				Name = "Upload exercise files",
				Completed = false,
				CategoryId = 1
			},
			new () {
				Name = "Plan next course",
				Completed = false,
				CategoryId = 1
			},
			new () {
				Name = "Upload new ASP.NET video on YouTube",
				Completed = false,
				CategoryId = 2
			},
			new () {
				Name = "Fix Settings.cs class of the project",
				Completed = false,
				CategoryId = 2
			},
			new () {
				Name = "Update github repository",
				Completed = true,
				CategoryId = 2
			},
			new () {
				Name = "Buy eggs",
				Completed = false,
				CategoryId = 3
			},
			new () {
				Name = "Go for the pepperoni pizza",
				Completed = true,
				CategoryId = 3
			},
		};

		UpdateData();
	}

	private void TasksOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		=> UpdateData();
}
