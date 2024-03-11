using System.Net;
using System.Text.Json;
using FluentAssertions;

namespace StockManager.Api.E2E.Tests.StocksController
{
    [TestFixture]
    internal sealed class GetStockValueByTickerSymbolTests : ApiTestBase
    {
        [Test]
        public async Task Should_ReturnCorrectStockValue()
        {
            // Arrange
            // Would usually insert test DB data here, but as i've seeded some data already on startup i'll use that.
            const string tickerSymbol = "ABC";

            // Act
            var response = await HttpClient.GetAsync($"api/Stocks/{tickerSymbol}/value");

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseValue = JsonSerializer.Deserialize<decimal>(responseContent);

            // Assert 
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseValue.Should().Be(25.4875M);
        }

        [Test]
        public async Task Should_ReturnNotFound_WhenStockDoesNotExist()
        {
            // Act
            var response = await HttpClient.GetAsync("api/Stocks/RandomTickerSymbol/value");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
