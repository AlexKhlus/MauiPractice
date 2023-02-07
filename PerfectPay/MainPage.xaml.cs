namespace PerfectPay;
public partial class MainPage : ContentPage
{
	private decimal _bill;
	private int _tip;
	private int _personsNumber;

	public MainPage()
	{
		InitializeComponent();

		_personsNumber = 1;
	}

	private void OnEntryInputCompleted(object sender, EventArgs e)
	{
		_bill = decimal.Parse(BillTextEntry.Text);
		CalculateTotal();
	}

	private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
	{
		_tip = (int)TipSlider.Value;
		PercentageTipLabel.Text = $"Tip: {_tip}%";
		CalculateTotal();
	}

	private void OnTipButtonClicked(object sender, EventArgs e)
	{
		if(sender is not Button button) return;

		var percentage = int.Parse(button.Text.Replace("%", string.Empty));
		TipSlider.Value = percentage;

	}

	private void OnMinusButtonClicked(object sender, EventArgs e)
	{
		if(_personsNumber < 2) return;

		_personsNumber--;
		SetPersonsNumber();
	}

	private void OnPlusButtonClicked(object sender, EventArgs e)
	{
		_personsNumber++;
		SetPersonsNumber();
	}

	private void SetPersonsNumber()
	{
		PersonsNumberLabel.Text = _personsNumber.ToString();
		CalculateTotal();
	}

	private void CalculateTotal()
	{
		var totalTip = _bill * _tip / 100;
		var tipByPerson = totalTip / _personsNumber;
		var subtotal = _bill / _personsNumber;
		var totalByPerson = (_bill + totalTip) / _personsNumber;

		FlatTipLabel.Text = $"{tipByPerson:C}";
		SubtotalLabel.Text = $"{subtotal:C}";
		TotalLabel.Text = $"{totalByPerson:C}";
	}
}
