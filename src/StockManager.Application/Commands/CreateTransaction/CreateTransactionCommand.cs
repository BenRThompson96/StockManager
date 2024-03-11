using MediatR;
using StockManager.Application.Models;

namespace StockManager.Application.Commands.CreateTransaction
{
    public sealed class CreateTransactionCommand : IRequest<TransactionCreateModel?>
    {
        public string TickerSymbol { get; init; } = null!;
        public decimal Price { get; init; }
        public decimal NumberOfShares { get; init; }
        public Guid BrokerId { get; init; }
    }
}
