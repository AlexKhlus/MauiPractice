using System.Collections.ObjectModel;
using PropertyChanged;
using Tasker.Models;
using Task = Tasker.Models.Task;


namespace Tasker.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class CreateTaskViewModel : IViewModel
{
	public string Task { get; set; }

	public ObservableCollection<Task> Tasks { get; set; }
	public ObservableCollection<Category> Categories { get; set; }
}
