namespace StockManager.Domain
{
    public sealed class Stock
    {
        public Guid Id { get; init; }
        public string TickerSymbol { get; init; } = null!;
        public string Name { get; init; } = null!;
    }
}