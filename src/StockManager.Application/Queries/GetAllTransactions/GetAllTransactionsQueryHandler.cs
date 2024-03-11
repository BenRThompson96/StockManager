using MediatR;
using StockManager.Application.Models;
using StockManager.Application.Repositories;

namespace StockManager.Application.Queries.GetAllTransactions
{
    internal sealed class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionReadModel>>
    {
        private readonly IStockManagerReadOnlyRepository _stockManagerReadOnlyRepository;

        public GetAllTransactionsQueryHandler(IStockManagerReadOnlyRepository stockManagerReadOnlyRepository)
        {
            _stockManagerReadOnlyRepository = stockManagerReadOnlyRepository;
        }

        public async Task<List<TransactionReadModel>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _stockManagerReadOnlyRepository.GetAllTransactions(cancellationToken);
        }
    }
}
