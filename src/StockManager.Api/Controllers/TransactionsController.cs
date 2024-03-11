using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManager.Application.Commands.CreateTransaction;
using StockManager.Application.Queries.GetAllTransactions;

namespace StockManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllTransactionsQuery(), cancellationToken);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTransaction([FromBody] CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);

            if (response is null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}