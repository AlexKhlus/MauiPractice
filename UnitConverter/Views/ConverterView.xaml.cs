using UnitConverter.ViewModels;


namespace UnitConverter.Views;
public partial class ConverterView : ContentPage
{
	public ConverterView()
		=> InitializeComponent();

	private void OnSelectedIndexChanged(object sender, EventArgs e)
		=> ((ConverterViewModel)BindingContext).Convert();
}

