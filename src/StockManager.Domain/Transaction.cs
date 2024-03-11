namespace StockManager.Domain;

public sealed class Transaction
{
    public Guid Id { get; init; }
    public decimal Price { get; init; }
    public decimal NumberOfShares { get; init; }
    public DateTime CreatedDateTime { get; init; }
    public Guid StockId { get; init; }
    public Guid BrokerId { get; init; }

    public Stock Stock { get; private set; } = null!;
    public Broker Broker { get; private set; } = null!;
}