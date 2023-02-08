using System.Text.Json;
using ColorUtility;
using Color = System.Drawing.Color;
using MauiColor = Microsoft.Maui.Graphics;


namespace AufQuotes;
public partial class MainPage : ContentPage
{
	private readonly Random _random;
	private readonly List<string> _quotes;
	private int _previousQuoteIndex;

	public MainPage()
	{
		InitializeComponent();
		_random = new (DateTime.UtcNow.Millisecond);
		_quotes = new ();
		_previousQuoteIndex = default;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await LoadMauiAsset();
	}

	private void OnGenerateQuoteButtonClicked(object sender, EventArgs e)
	{
		SetRandomGradient();
		var quoteIndex = _previousQuoteIndex;
		while(quoteIndex == _previousQuoteIndex)
		{
			quoteIndex = _random.Next(_quotes.Count);
		}

		_previousQuoteIndex = quoteIndex;
		QuoteLabel.Text = _quotes[quoteIndex];
	}

	private void SetRandomGradient()
	{
		var startColor = Color.FromArgb(
			_random.Next(byte.MinValue, byte.MaxValue),
			_random.Next(byte.MinValue, byte.MaxValue),
			_random.Next(byte.MinValue, byte.MaxValue)
		);
		var endColor = Color.FromArgb(
			_random.Next(byte.MinValue, byte.MaxValue),
			_random.Next(byte.MinValue, byte.MaxValue),
			_random.Next(byte.MinValue, byte.MaxValue)
		);

		var colors = ColorControls.GetColorGradient(startColor, endColor, 6);
		var stopOffset = default(float);
		var stops = new GradientStopCollection();

		foreach(var color in colors)
		{
			stops.Add(
				new (MauiColor.Color.FromArgb(color.Name), stopOffset)
			);
			stopOffset += 0.2f;
		}

		var gradient = new LinearGradientBrush(stops, new (0, 0), new (1, 1));
		RootGrid.Background = gradient;
	}

	private async Task LoadMauiAsset()
	{
		await using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.json");

		var contents = await new StreamReader(stream).ReadToEndAsync();
		_quotes.AddRange(JsonSerializer.Deserialize<List<string>>(contents));
	}
}
