using StockManager.Domain;

namespace StockManager.Application.Repositories
{
    public interface IStockManagerWriteRepository
    {
        Task InsertTransaction(Transaction transaction);
    }
}
