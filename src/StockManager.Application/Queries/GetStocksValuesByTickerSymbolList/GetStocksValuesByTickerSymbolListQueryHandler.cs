using MediatR;
using StockManager.Application.Models;
using StockManager.Application.Repositories;

namespace StockManager.Application.Queries.GetStocksValuesByTickerSymbolList
{
    internal class GetStocksValuesByTickerSymbolListQueryHandler : IRequestHandler<GetStocksValuesByTickerSymbolListQuery, List<StockValueReadModel>>
    {
        private readonly IStockManagerReadOnlyRepository _stockManagerReadOnlyRepository;

        public GetStocksValuesByTickerSymbolListQueryHandler(IStockManagerReadOnlyRepository stockManagerReadOnlyRepository)
        {
            _stockManagerReadOnlyRepository = stockManagerReadOnlyRepository;
        }

        public async Task<List<StockValueReadModel>> Handle(GetStocksValuesByTickerSymbolListQuery request, CancellationToken cancellationToken)
        {
            return await _stockManagerReadOnlyRepository.GetStocksValuesByTickerSymbolList(request.TickerSymbols, cancellationToken);
        }
    }
}
