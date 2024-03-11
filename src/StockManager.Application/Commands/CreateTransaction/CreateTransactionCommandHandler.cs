using MediatR;
using StockManager.Application.Models;
using StockManager.Application.Repositories;
using StockManager.Domain;

namespace StockManager.Application.Commands.CreateTransaction
{
    internal sealed class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionCreateModel?>
    {
        private readonly IStockManagerReadOnlyRepository _stockManagerReadOnlyRepository;
        private readonly IStockManagerWriteRepository _stockManagerWriteRepository;

        public CreateTransactionCommandHandler(
            IStockManagerReadOnlyRepository stockManagerReadOnlyRepository,
            IStockManagerWriteRepository stockManagerWriteRepository)
        {
            _stockManagerReadOnlyRepository = stockManagerReadOnlyRepository;
            _stockManagerWriteRepository = stockManagerWriteRepository;
        }

        public async Task<TransactionCreateModel?> Handle(CreateTransactionCommand request,
            CancellationToken cancellationToken)
        {
            // If requirements are concrete and cannot have stockId in the request, have to get the stockId from the DB.
            var stock = await _stockManagerReadOnlyRepository.GetStockByTickerSymbol(request.TickerSymbol,
                cancellationToken);

            if (stock is null)
            {
                return null;
            }

            var broker = await _stockManagerReadOnlyRepository.GetBrokerById(request.BrokerId, cancellationToken);

            if (broker is null)
            {
                return null;
            }

            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                NumberOfShares = request.NumberOfShares,
                StockId = stock.Id,
                BrokerId = request.BrokerId,
                CreatedDateTime = DateTime.UtcNow
            };

            await _stockManagerWriteRepository.InsertTransaction(transaction);

            return new TransactionCreateModel(stock.TickerSymbol, transaction.Price, transaction.NumberOfShares,
                transaction.CreatedDateTime, transaction.BrokerId);
        }
    }
}
