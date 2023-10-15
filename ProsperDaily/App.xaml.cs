using ProsperDaily.Models;
using ProsperDaily.Repositories.Base;
using ProsperDaily.Views;


namespace ProsperDaily;
public partial class App : Application
{
	public App(IBaseRepository<Transaction> repo)
	{
		InitializeComponent();

		Repo = repo;
		MainPage = new AppContainer();
	}

	public static IBaseRepository<Transaction> Repo { get; private set; }
}
