using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManager.Application.Queries.GetAllStocksValues;
using StockManager.Application.Queries.GetStockValueByTickerSymbol;

namespace StockManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{tickerSymbol}/value")]
        public async Task<IActionResult> GetStockValueByTickerSymbol(string tickerSymbol, CancellationToken cancellationToken)
        {
            var query = new GetStockValueByTickerSymbolQuery(tickerSymbol);

            var response = await _mediator.Send(query, cancellationToken);

            if (response is null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("values")]
        public async Task<IActionResult> GetAllStockValues(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllStocksValuesQuery(), cancellationToken);

            return Ok(response);
        }
    }
}