using MarketData.Infrastructure.Trades.Dtos;
using MediatR;

namespace MarketData.Application.Trades.Queries.GetLatestInstrumentClosePrices
{
    public record GetLatestInstrumentClosePricesQuery : IRequest<List<TradeClosePriceDto>>
    {
    }
}
