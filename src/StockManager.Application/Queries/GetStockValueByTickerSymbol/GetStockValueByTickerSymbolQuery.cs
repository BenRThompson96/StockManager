using MediatR;

namespace StockManager.Application.Queries.GetStockValueByTickerSymbol
{
    public sealed record GetStockValueByTickerSymbolQuery(string TickerSymbol) : IRequest<decimal?>;
}
