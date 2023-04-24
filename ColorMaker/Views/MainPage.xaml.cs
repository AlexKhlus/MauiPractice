using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace ColorMaker.Views;
public partial class MainPage : ContentPage
{
	private bool _isRandom;
	private string _hexColorValue;

	public MainPage()
	{
		InitializeComponent();

		_isRandom = default;
		_hexColorValue = "#000000";
	}

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		if(_isRandom) return;

		SetColor(Color.FromRgb(
			red: RedColorSlider.Value,
			green: GreenColorSlider.Value,
			blue: BlueColorSlider.Value
		));
	}

	private void SetColor(Color color)
	{
		RandomColorButton.BackgroundColor
			= RootContainer.BackgroundColor
				= color;

		RandomColorButton.TextColor = Color.FromRgb(
			red:   1 - color.Red,
			green: 1 - color.Green,
			blue:  1 - color.Blue
		);

		_hexColorValue = color.ToHex();
		HexColorLabel.Text = $"HEX Color: {_hexColorValue}";
	}

	private void OnButtonClicked(object sender, EventArgs e)
	{
		_isRandom = true;

		var random = new Random(DateTime.UtcNow.Millisecond);
		var color = Color.FromRgb(
			red:   random.Next(byte.MinValue, byte.MaxValue),
			green: random.Next(byte.MinValue, byte.MaxValue),
			blue:  random.Next(byte.MinValue, byte.MaxValue)
		);

		SetColor(color);

		RedColorSlider.Value   = color.Red;
		GreenColorSlider.Value = color.Green;
		BlueColorSlider.Value  = color.Blue;

		_isRandom = false;
	}

	private async void OnImageButtonClicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(_hexColorValue);
		await Toast.Make(
			message: $"Color {_hexColorValue} is copied!",
			duration: ToastDuration.Short,
			textSize: 12
		).Show();
	}
}
