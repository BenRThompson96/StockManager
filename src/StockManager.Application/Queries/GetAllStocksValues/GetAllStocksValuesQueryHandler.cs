using MediatR;
using StockManager.Application.Models;
using StockManager.Application.Repositories;

namespace StockManager.Application.Queries.GetAllStocksValues
{
    internal sealed class GetAllStocksValuesQueryHandler : IRequestHandler<GetAllStocksValuesQuery, IReadOnlyList<StockValueReadModel>>
    {
        private readonly IStockManagerReadOnlyRepository _stockManagerRepository;

        public GetAllStocksValuesQueryHandler(IStockManagerReadOnlyRepository stockManagerRepository)
        {
            _stockManagerRepository = stockManagerRepository;
        }

        public async Task<IReadOnlyList<StockValueReadModel>> Handle(GetAllStocksValuesQuery request, CancellationToken cancellationToken)
        {
            return await _stockManagerRepository.GetAllStocksValues(cancellationToken);
        }
    }
}
