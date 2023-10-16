using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevsPark.Models;


namespace DevsPark.ViewModels;
public partial class FeaturedViewModel : ObservableObject
{
	[ObservableProperty]
    private FeaturedPromotion _selectedItem;

    public FeaturedViewModel()
    {
        Promotions = new () {
            new () {
                Id = 1, Name = "VoyageVista",
                ImagePath = "voyagevista.png",
                Description = "Explore the world with VoyageVista. Your adventures await!"
            },
            new () {
                Id = 2, Name = "LuxLoom Hotels",
                ImagePath = "luxloom.png",
                Description = "Luxury stays that feel like home. Book with LuxLoom."
            },
            new () {
                Id = 3, Name = "UrbanUmbra Stores",
                ImagePath = "urbanumbra.png",
                Description = "Shop fresh, live healthy. Find everything you need at UrbanUmbra."
            },
            new () {
                Id = 4, Name = "ChicChase Outlets",
                ImagePath = "chicchase.png",
                Description = "Define your style with the latest trends at ChicChase."
            }
        };
    }

    public List<FeaturedPromotion> Promotions { get; set; }

    [RelayCommand]
    public async Task SelectionChanged() { }
}
