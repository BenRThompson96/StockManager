using MediatR;
using StockManager.Application.Repositories;

namespace StockManager.Application.Queries.GetStockValueByTickerSymbol
{
    internal sealed class GetStockValueByTickerSymbolQueryHandler : IRequestHandler<GetStockValueByTickerSymbolQuery, decimal?>
    {
        private readonly IStockManagerReadOnlyRepository _stockManagerRepository;

        public GetStockValueByTickerSymbolQueryHandler(IStockManagerReadOnlyRepository stockManagerRepository)
        {
            _stockManagerRepository = stockManagerRepository;
        }

        public async Task<decimal?> Handle(GetStockValueByTickerSymbolQuery request, CancellationToken cancellationToken)
        {
            return await _stockManagerRepository.GetStockValueByTickerSymbol(request.TickerSymbol, cancellationToken);
        }
    }
}
