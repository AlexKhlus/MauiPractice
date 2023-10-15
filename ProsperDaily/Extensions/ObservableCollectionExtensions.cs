using System.Collections.ObjectModel;


namespace ProsperDaily.Extensions;
public static class ObservableCollectionExtensions
{
	public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> enumerable)
	{
		foreach(var item in enumerable) collection.Add(item);

		return collection;
	}
}
