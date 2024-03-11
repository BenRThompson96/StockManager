using Microsoft.EntityFrameworkCore;
using StockManager.Domain;
using StockManager.Infrastructure.Configurations;

namespace StockManager.Infrastructure.DbContexts
{
    public sealed class StockManagerDbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<Broker> Brokers { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new StockConfiguration())
                .ApplyConfiguration(new BrokerConfiguration())
                .ApplyConfiguration(new TransactionConfiguration());


            modelBuilder.Entity<Stock>().HasData(new Stock {Id = Guid.NewGuid(), Name = "TestName", TickerSymbol = "ABC"});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "StockManager");
            }
        }
    }
}
