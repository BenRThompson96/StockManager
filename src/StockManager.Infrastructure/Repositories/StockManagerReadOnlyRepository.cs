using Microsoft.EntityFrameworkCore;
using StockManager.Application.Models;
using StockManager.Application.Repositories;
using StockManager.Domain;
using StockManager.Infrastructure.DbContexts;

namespace StockManager.Infrastructure.Repositories
{
    public sealed class StockManagerReadOnlyRepository : IStockManagerReadOnlyRepository
    {
        public StockManagerDbContext DbContext { get; }

        public StockManagerReadOnlyRepository(StockManagerDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<decimal?> GetStockValueByTickerSymbol(string tickerSymbol, CancellationToken cancellationToken)
        {
            return await DbContext.Transactions
                .AsNoTracking()
                .Where(t => t.Stock.TickerSymbol == tickerSymbol)
                .Select(t => (decimal?)t.Price) 
                .DefaultIfEmpty() 
                .AverageAsync(cancellationToken);
        }

        public async Task<List<StockValueReadModel>> GetStocksValuesByTickerSymbolList(List<string> tickerSymbols, CancellationToken cancellationToken)
        {
            return await DbContext.Transactions
                .AsNoTracking()
                .Include(t => t.Stock)
                .Where(t => tickerSymbols.Contains(t.Stock.TickerSymbol))
                .GroupBy(t => t.Stock.TickerSymbol)
                .Select(t => new StockValueReadModel(t.Key, t.Average(t => t.Price)))
                .ToListAsync(cancellationToken);
        }

        public async Task<List<StockValueReadModel>> GetAllStocksValues(CancellationToken cancellationToken)
        {
            return await DbContext.Transactions
                .AsNoTracking()
                .Include(t => t.Stock)
                .GroupBy(t => t.Stock.TickerSymbol)
                .Select(t => new StockValueReadModel(t.Key, t.Average(t => t.Price)))
                .ToListAsync(cancellationToken);
        }

        public async Task<Stock?> GetStockByTickerSymbol(string tickerSymbol, CancellationToken cancellationToken)
        {
            return await DbContext.Stocks
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.TickerSymbol == tickerSymbol, cancellationToken);
        }

        public async Task<List<TransactionReadModel>> GetAllTransactions(CancellationToken cancellationToken)
        {
            return await DbContext.Transactions
                .AsNoTracking()
                .Include(t => t.Stock)
                .Include(t => t.Broker)
                .Select(t =>
                    new TransactionReadModel(t.Stock.Name, t.Stock.TickerSymbol, t.Price, t.NumberOfShares, t.Broker.Name, t.Broker.Id, t.CreatedDateTime))
                .ToListAsync(cancellationToken);
        }

        public async Task<Broker?> GetBrokerById(Guid id, CancellationToken cancellationToken)
        {
            return await DbContext.Brokers
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.Id == id, cancellationToken);
        }
    }
}
