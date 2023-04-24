using System.Globalization;
using System.Windows.Input;
using PropertyChanged;
using DanglCalculator = Dangl.Calculator.Calculator;


namespace Calculator.ViewModels;

[AddINotifyPropertyChangedInterface]
public sealed class CalculatorViewModel : IViewModel
{
	public CalculatorViewModel()
	{
		Result = $"0";

		OperationCommand = new Command(number => Formula += number);
		ResetCommand = new Command(_ =>
		{
			Result = $"0";
			Formula = string.Empty;
		});
		BackspaceCommand = new Command(_ =>
		{
			if(Formula is { Length: > 0 })
			{
				Formula = Formula.Replace(Formula.Last().ToString(), string.Empty).Trim();
			}
		});
		CalculateCommand = new Command(_ =>
		{
			Result = Formula is { Length: 0 } ?
				$"0" :
				DanglCalculator.Calculate(Formula).Result.ToString(CultureInfo.InvariantCulture);
		});
	}

	public string Formula { get; set; }
	public string Result { get; set; }

	public ICommand OperationCommand { get; }
	public ICommand ResetCommand { get; }
	public ICommand BackspaceCommand { get; }
	public ICommand CalculateCommand { get; }
}
