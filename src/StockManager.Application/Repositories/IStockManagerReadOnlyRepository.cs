using StockManager.Application.Models;
using StockManager.Domain;

namespace StockManager.Application.Repositories
{
    public interface IStockManagerReadOnlyRepository
    {
        Task<decimal?> GetStockValueByTickerSymbol(string tickerSymbol, CancellationToken cancellationToken);
        Task<List<StockValueReadModel>> GetStocksValuesByTickerSymbolList(List<string> tickerSymbols, CancellationToken cancellationToken);
        Task<List<StockValueReadModel>> GetAllStocksValues(CancellationToken cancellationToken);
        Task<Stock?> GetStockByTickerSymbol(string tickerSymbol, CancellationToken cancellationToken);
        Task<List<TransactionReadModel>> GetAllTransactions(CancellationToken cancellationToken);
        Task<Broker?> GetBrokerById(Guid id, CancellationToken cancellationToken);
    }
}
