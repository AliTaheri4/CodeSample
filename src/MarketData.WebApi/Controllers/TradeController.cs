using Microsoft.AspNetCore.Mvc;
using MediatR;
using MarketData.Application.Trades.Queries.GetLatestInstrumentClosePrices;
using MarketData.Infrastructure.Trades.Dtos;

namespace MarketData.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TradeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLatestTradeClosePrices")]
        public async Task<List<TradeClosePriceDto>> GetLatestTradeClosePrices()
        {
            return await _mediator.Send(new GetLatestInstrumentClosePricesQuery());
        }
    }
}