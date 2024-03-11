using StockManager.Application.Infrastructure;
using StockManager.Infrastructure.Infrastructure;

namespace StockManager.Api.Infrastructure
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterAllDependencies(this IServiceCollection services)
        {
            return services
                .RegisterApplicationLayerDependencies()
                .RegisterInfrastructureLayerDependencies();
        }
    }
}
