using PropertyChanged;


namespace BmiCalculator.Models;

[AddINotifyPropertyChangedInterface]
public class BodyMassIndex
{
	private float _index;

	public float Height { get; set; }
	public float Weight { get; set; }

	public float Index
		=> ((Weight / Height) / Height) * 10000;

	public string IndexAsTextGrade
	{
		get
		{
			const string TEMPLATE = "BMI: #";

			return Index switch {
				<= 16                   => TEMPLATE.Replace("#", "Severe Thinness"),
				> 16 and <= 17          => TEMPLATE.Replace("#", "Moderate Thinness"),
				> 17 and <= (float)18.5 => TEMPLATE.Replace("#", "Mild Thinness"),
				> (float)18.5 and <= 25 => TEMPLATE.Replace("#", "Normal"),
				> 25 and <= 30          => TEMPLATE.Replace("#", "Overweight"),
				> 30 and <= 35          => TEMPLATE.Replace("#", "Obese Class I"),
				> 35 and <= 40          => TEMPLATE.Replace("#", "Obese Class II"),
				_                       => TEMPLATE.Replace("#", "Obese Class III")
			};
		}
	}
}
