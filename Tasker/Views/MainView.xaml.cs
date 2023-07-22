using Tasker.ViewModels;


namespace Tasker.Views;
public partial class MainView : ContentPage
{
	private readonly MainViewModel _mainViewModel;

	public MainView()
	{
		InitializeComponent();

		_mainViewModel = new ();
		BindingContext = _mainViewModel;
	}

	private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
		=> _mainViewModel.UpdateData();

	private void OnClicked(object sender, EventArgs e)
	{
		var taskView = new CreateTaskView() {
			BindingContext = new CreateTaskViewModel() {
				Categories = _mainViewModel.Categories,
				Tasks = _mainViewModel.Tasks
			}
		};

		Navigation.PushAsync(taskView);
	}
}

