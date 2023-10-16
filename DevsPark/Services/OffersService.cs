using DevsPark.Models;


namespace DevsPark.Services;
public sealed class OffersService
{
	public OffersService()
	{
		Offers = new ();
		for(var i = 0; i < 5; i++)
		{
			Offers.Add(new () {
				Id = 1, ImagePath = "offer.jpg", Discount = i * 5,
				Description = $"Travel deal {i + 1}",
				Name = $"Travel Offer {i + 1}"
			});

			Offers.Add(new () {
				Id = 2, ImagePath = "offer.jpg", Discount = (i * 5) + 5,
				Description = $"Hotel deal {i + 1}",
				Name = $"Hotel Offer {i + 1}"
			});

			Offers.Add(new () {
				Id = 3, ImagePath = "offer.jpg", Discount = (i * 5) + 10,
				Description = $"Supermarket deal {i + 1}",
				Name = $"Supermarket Offer {i + 1}"
			});

			Offers.Add(new () {
				Id = 4, ImagePath = "offer.jpg", Discount = (i * 5) + 15,
				Description = $"Clothing deal {i + 1}",
				Name = $"Clothing Offer {i + 1}"
			});
		}
	}

	public List<Offer> Offers { get; set; }

	public List<Offer> GetOffers(int id)
		=> Offers.Where(offer => offer.Id == id).ToList();
}
