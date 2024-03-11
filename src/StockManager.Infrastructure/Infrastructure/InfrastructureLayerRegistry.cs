using Microsoft.Extensions.DependencyInjection;
using StockManager.Application.Repositories;
using StockManager.Domain;
using StockManager.Infrastructure.DbContexts;
using StockManager.Infrastructure.Repositories;

namespace StockManager.Infrastructure.Infrastructure
{
    public static class InfrastructureLayerRegistry
    {
        public static IServiceCollection RegisterInfrastructureLayerDependencies(this IServiceCollection services)
        {
            services.AddScoped<StockManagerDbContext>();
            SeedDataOnStartup(services.BuildServiceProvider());

            services.AddScoped<IStockManagerWriteRepository, StockManagerWriteRepository>();
            return services.AddScoped<IStockManagerReadOnlyRepository, StockManagerReadOnlyRepository>();
        }

        private static void SeedDataOnStartup(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StockManagerDbContext>();

            // Insert Stocks
            var appleStock = new Stock { Id = Guid.NewGuid(), Name = "Apple", TickerSymbol = "ABC" };
            var googleStock = new Stock { Id = Guid.NewGuid(), Name = "Google", TickerSymbol = "XYZ" };
            dbContext.Stocks.AddRange(appleStock, googleStock);

            // Insert Broker
            var broker = new Broker { Id = Guid.NewGuid(), Name = "Frank Sidebottom" };
            dbContext.Brokers.Add(broker);

            // Insert Transactions
            dbContext.Transactions.AddRange(new List<Transaction>
            {
                new() { Id  = Guid.NewGuid(), Price = 1.98m, NumberOfShares = 100, StockId = appleStock.Id, BrokerId = broker.Id},
                new() { Id  = Guid.NewGuid(), Price = 0.77m, NumberOfShares = 16, StockId = appleStock.Id, BrokerId = broker.Id},

                new() { Id  = Guid.NewGuid(), Price = 99.1m, NumberOfShares = 55, StockId = appleStock.Id, BrokerId = broker.Id},
                new() { Id  = Guid.NewGuid(), Price = 0.10m, NumberOfShares = 7, StockId = appleStock.Id, BrokerId = broker.Id},
                new() { Id  = Guid.NewGuid(), Price = 123.12m, NumberOfShares = 1000, StockId = googleStock.Id, BrokerId = broker.Id},
                new() { Id  = Guid.NewGuid(), Price = 100.01m, NumberOfShares = 200, StockId = googleStock.Id, BrokerId = broker.Id},
            });

            dbContext.SaveChanges();
        }
    }
}
