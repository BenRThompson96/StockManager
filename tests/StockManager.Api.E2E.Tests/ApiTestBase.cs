using Microsoft.AspNetCore.Mvc.Testing;

namespace StockManager.Api.E2E.Tests
{
    internal abstract class ApiTestBase
    {
        protected WebApplicationFactory<Program> WebApplicationFactory = null!;
        protected HttpClient HttpClient = null!;

        [OneTimeSetUp]
        public void OneTimeSetUpBase()
        {
            WebApplicationFactory = new WebApplicationFactory<Program>();
        }

        [SetUp]
        public void SetUpBase()
        {
            HttpClient = WebApplicationFactory.CreateClient();
        }

        [TearDown]
        public void TearDownBase()
        {
            HttpClient.Dispose();
        }

        [OneTimeTearDown]
        public void OneTimeTearDownBase()
        {
            WebApplicationFactory.Dispose();
        }
    }
}
