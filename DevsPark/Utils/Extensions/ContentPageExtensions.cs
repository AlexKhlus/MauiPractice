using System.Text.RegularExpressions;


namespace DevsPark.Utils.Extensions;
public static class ContentPageExtensions
{
	public static string GetName(this ContentPage page)
		=> Regex.Replace(page.GetType().Name, "([a-z])([A-Z])", "$1 $2");
}
