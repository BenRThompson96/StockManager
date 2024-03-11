using MediatR;
using StockManager.Application.Models;

namespace StockManager.Application.Queries.GetAllStocksValues
{
    public sealed record GetAllStocksValuesQuery : IRequest<IReadOnlyList<StockValueReadModel>>;
}
