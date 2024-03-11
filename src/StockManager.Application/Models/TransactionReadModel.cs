namespace StockManager.Application.Models;

public sealed record TransactionReadModel(
    string StockName,
    string TickerSymbol,
    decimal Price,
    decimal NumberOfShares,
    string BrokerName,
    Guid BrokerId,
    DateTime CreatedDateTime);