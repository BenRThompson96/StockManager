using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace StockManager.Application.Infrastructure
{
    public static class ApplicationLayerRegistry
    {
        public static IServiceCollection RegisterApplicationLayerDependencies(this IServiceCollection services)
        {
            return services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
