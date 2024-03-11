namespace StockManager.Domain
{
    public sealed class Broker
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
