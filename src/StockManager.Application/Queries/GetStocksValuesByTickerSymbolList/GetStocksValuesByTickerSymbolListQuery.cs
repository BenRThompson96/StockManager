using MediatR;
using StockManager.Application.Models;

namespace StockManager.Application.Queries.GetStocksValuesByTickerSymbolList
{
    public sealed record GetStocksValuesByTickerSymbolListQuery(List<string> TickerSymbols) : IRequest<List<StockValueReadModel>>;
}
