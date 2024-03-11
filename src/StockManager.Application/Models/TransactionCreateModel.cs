namespace StockManager.Application.Models
{
    public sealed record TransactionCreateModel(
        string TickerSymbol,
        decimal Price,
        decimal NumberOfShares,
        DateTime CreatedDateTime,
        Guid BrokerId);
}
