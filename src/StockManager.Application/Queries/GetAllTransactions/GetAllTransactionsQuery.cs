using MediatR;
using StockManager.Application.Models;

namespace StockManager.Application.Queries.GetAllTransactions
{
    // This would normally include paging to avoid huge DB queries, but given the requirements this seemed fine.
    public sealed record GetAllTransactionsQuery : IRequest<List<TransactionReadModel>>;
}
