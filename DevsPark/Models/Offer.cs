namespace DevsPark.Models;
public sealed class Offer
{
	public int    Id          { get; set; }
	public string Name        { get; set; }
	public string ImagePath   { get; set; }
	public string Description { get; set; }
	public int    Discount    { get; set; }
}
