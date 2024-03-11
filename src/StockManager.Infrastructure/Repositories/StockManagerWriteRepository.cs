using StockManager.Application.Repositories;
using StockManager.Domain;
using StockManager.Infrastructure.DbContexts;

namespace StockManager.Infrastructure.Repositories
{
    public class StockManagerWriteRepository : IStockManagerWriteRepository
    {
        public StockManagerDbContext DbContext { get; }

        public StockManagerWriteRepository(StockManagerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task InsertTransaction(Transaction transaction)
        {
            await DbContext.Transactions.AddAsync(transaction);
            await DbContext.SaveChangesAsync();
        }
    }
}
