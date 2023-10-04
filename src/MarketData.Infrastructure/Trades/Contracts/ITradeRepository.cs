using MarketData.Infrastructure.Trades.Dtos;

namespace MarketData.Infrastructure.Trades.Contracts
{
    public interface ITradeRepository
    {
        Task<List<TradeClosePriceDto>> GetLatestInstrumentClosePrices(CancellationToken cancellationToken=default);
    }
}
