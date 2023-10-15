using ProsperDaily.Models;
using ProsperDaily.Repositories.Base;


namespace ProsperDaily.Extensions;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services
			.AddSingleton<IBaseRepository<Transaction>, Repository<Transaction>>();

		return services;
	}
}
