using Tasker.Models;
using Tasker.ViewModels;
using Task = Tasker.Models.Task;


namespace Tasker.Views;
public partial class CreateTaskView : ContentPage
{
	public CreateTaskView()
		=> InitializeComponent();

	private async void OnAddTaskClicked(object sender, EventArgs e)
	{
		var viewModel = (BindingContext as CreateTaskViewModel)!;
		var selectedCategory = viewModel.Categories.FirstOrDefault(category => category.IsSelected);

		if(selectedCategory != null)
		{
			var task = new Task() {
				Name = viewModel.Task,
				CategoryId = selectedCategory.Id,
			};
			viewModel.Tasks.Add(task);
			await Navigation.PopAsync();
		}
		else
		{
			await DisplayAlert(
				title: "Invalid Selection",
				message: "You must select a category",
				cancel: "Ok"
			);
		}
	}

	private async void OnAddCategoryClicked(object sender, EventArgs e)
	{
		var random = new Random();
		var viewModel = (BindingContext as CreateTaskViewModel)!;
		var newCategoryName = await DisplayPromptAsync(
			title: "New Category",
			message: "Write the new category name",
			maxLength: 15,
			keyboard: Keyboard.Text
		);

		if(string.IsNullOrEmpty(newCategoryName) is false)
		{
			viewModel.Categories.Add(new () {
				Id = viewModel.Categories.Max(category => category.Id) + 1,
				Color = Color.FromRgb(
					red: random.Next(0, 255),
					green: random.Next(0, 255),
					blue: random.Next(0, 255)
				).ToHex(),
				Name = newCategoryName
			});
		}
	}
}

