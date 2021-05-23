using CoinJar.Management.Application.Features.CoinJar.Commands.CreateCoinJar;
using CoinJar.Management.Application.Features.CoinJar.Queries.GetCoinJarTotalAmount;
using CoinJar.Management.Application.Features.CoinJar.Queries.ResetCoinJar;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoinJar.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinJarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoinJarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("total", Name = "GetTotalAmount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetTotalAmount()
        {
            var total = await _mediator.Send(new GetCoinTotalAmountQuery());
            return Ok(total);
        }

        [HttpPut("reset", Name = "ResetCoins")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ResetCoins()
        {
            await _mediator.Send(new ResetCoinQuery());
            return NoContent();
        }

        [HttpPost("add", Name = "AddCoin")]
        public async Task<ActionResult<CreateCoinJarCommandResponse>> AddCoin([FromBody] CreateCoinJarCommand createCoinJarCommand)
        {
            var response = await _mediator.Send(createCoinJarCommand);
            return Ok(response);
        }
    }
}
