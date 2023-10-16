using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevsPark.Models;
using DevsPark.Services;


namespace DevsPark.ViewModels;
public partial class OffersViewModel : ObservableObject
{
	[ObservableProperty]
	private ObservableCollection<Offer> _offers;

	[ObservableProperty]
	private string _name = "Company Name";

	private readonly OffersService _offersService;

	public OffersViewModel(OffersService offersService)
	{
		_offersService = offersService;
	}


	[RelayCommand]
	public async Task Back()
	{
		await Shell.Current.DisplayAlert("Back pressed", "Back pressed", "OK");
	}
}
