using PropertyChanged;


namespace Tasker.Models;

[AddINotifyPropertyChangedInterface]
public sealed class Task
{
	public string Name { get; set; }
	public bool Completed { get; set; }
	public int CategoryId { get; set; }
	public string Color { get; set; }
}
