<!-- ABOUT THE PROJECT -->

## About The Project

I spent around 2 hours putting this together to meet the requirements set out in the specification document.

Things to note:

- Because of the nature of the test I decided to go with an in-memory database so it is easy to run without any unnecessary config changes to point to a local DB or the need for a docker container to run the DB.
- I've pre-seeded some data into the DB for ease of testing, see `StockManager.Infrastructure.Infrastructure.InfrastructureLayerRegistry.SeedDataOnStartup`

<!-- GETTING STARTED -->

## Getting Started

Running the project should be simple:

- Just run the API project (either in your IDE or via `dotnet run`).
- Hit the swagger endpoints provided.

- I've also added some E2E API Tests for a couple of the endpoints just as examples of my testing style. See

  - `StockManager\tests\StockManager.Api.E2E.Tests\StocksController\GetStockValueByTickerSymbolTests.cs`
  - `StockManager\tests\StockManager.Api.E2E.Tests\TransactionsController\CreateNewTransactionTests.cs`

Here's an example request for the POST endpoint for creating a transaction. The TickerSymbol and BrokerId should match one currently in the DB. (You can use the Get endpoint to see previous transactions to get them. `api/Transactions`)

```json
{
  "TickerSymbol": "ABC",
  "Price": 1.5,
  "NumberOfShares": 10,
  "BrokerId": "a3970cd4-b0ae-4e85-82b4-792c3713ce66"
}
```
