using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StockManager.Application.Commands.CreateTransaction;
using StockManager.Application.Models;
using StockManager.Domain;
using StockManager.Infrastructure.DbContexts;

namespace StockManager.Api.E2E.Tests.TransactionsController
{
    [TestFixture]
    internal sealed class CreateNewTransactionTests : ApiTestBase
    {
        private StockManagerDbContext _dbContext = null!;
        private Stock _stock = null!;
        private Broker _broker = null!;

        [SetUp]
        public async Task SetUp()
        {
            _dbContext = new StockManagerDbContext();

            _stock = new Stock { Id = Guid.NewGuid(), Name = "TestStock", TickerSymbol = "123" };
            await _dbContext.Stocks.AddAsync(_stock);

            _broker = new Broker { Id = Guid.NewGuid(), Name = "TestBroker" };
            await _dbContext.Brokers.AddAsync(_broker);

            await _dbContext.SaveChangesAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _dbContext.DisposeAsync();
        }

        [Test]
        public async Task Should_NotCreateNewTransaction_WhenStockDoesNotExist()
        {
            // Arrange
            var command = CreateCommand("RandomTickerSymbol");

            // Act
            var response = await HttpClient.PostAsync("api/Transactions",
                new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json"));

            // Assert - status code
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Assert - database not updated
            var transactionFromDb = await _dbContext.Transactions
                .Include(t => t.Stock)
                .SingleOrDefaultAsync(t => t.Stock.TickerSymbol == command.TickerSymbol);

            transactionFromDb.Should().BeNull();
        }

        [Test]
        public async Task Should_CreateNewTransaction()
        {
            // Arrange
            var command = CreateCommand(_stock.TickerSymbol);

            // Act 
            var response = await HttpClient.PostAsync("api/Transactions",
                new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json"));

            var responseTransaction = JsonSerializer.Deserialize<TransactionCreateModel>(
                await response.Content.ReadAsStringAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            // Assert - response 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseTransaction.Should().NotBeNull();
            responseTransaction!.TickerSymbol.Should().Be(_stock.TickerSymbol);
            responseTransaction!.Price.Should().Be(command.Price);

            // Assert - database updated
            var transactionFromDb = await _dbContext.Transactions
                .Include(t => t.Stock)
                .SingleOrDefaultAsync(t => t.Stock.TickerSymbol == _stock.TickerSymbol);

            transactionFromDb.Should().NotBeNull();
            transactionFromDb!.StockId.Should().Be(_stock.Id);
            transactionFromDb.BrokerId.Should().Be(command.BrokerId);
            transactionFromDb.Price.Should().Be(command.Price);
        }

        private CreateTransactionCommand CreateCommand(
            string? tickerSymbol = null,
            decimal price = 1.5m,
            decimal numberOfShares = 10m,
            Guid? brokerId = null)
        {
            tickerSymbol ??= _stock.TickerSymbol;
            brokerId ??= _broker.Id;

            return new CreateTransactionCommand
            {
                TickerSymbol = tickerSymbol, 
                Price = price, 
                NumberOfShares = numberOfShares, 
                BrokerId = brokerId.Value
            };
        }
    }
}
