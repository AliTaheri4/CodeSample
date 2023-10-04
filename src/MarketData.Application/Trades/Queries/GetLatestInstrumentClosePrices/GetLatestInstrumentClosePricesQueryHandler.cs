using MarketData.Infrastructure.Trades.Contracts;
using MarketData.Infrastructure.Trades.Dtos;
using MediatR;

namespace MarketData.Application.Trades.Queries.GetLatestInstrumentClosePrices
{

    public class GetLatestInstrumentClosePricesQueryHandler : IRequestHandler<GetLatestInstrumentClosePricesQuery, List<TradeClosePriceDto>>
    {
        private readonly ITradeRepository _tradeRepository;

        public GetLatestInstrumentClosePricesQueryHandler(ITradeRepository tradeRepository)
        {
            _tradeRepository = tradeRepository;
        }
        public async Task<List<TradeClosePriceDto>> Handle(GetLatestInstrumentClosePricesQuery request, CancellationToken cancellationToken)
        {
            var result = await _tradeRepository.GetLatestInstrumentClosePrices(cancellationToken);
            return result;
        }
    }
}