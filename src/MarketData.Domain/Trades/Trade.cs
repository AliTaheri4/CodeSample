using MarketData.Domain.Utilities;

namespace MarketData.Domain.Trades
{
    public class Trade: BaseEntity<int>
    {
        public Trade(int instrumentId, DateTime dateEn, decimal open, decimal high, decimal low, decimal close)
        {
            InstrumentId = instrumentId;
            DateEn = dateEn;
            Open= open;
            High = high;
            Low = low;
            Close = close;
        }
        public int InstrumentId { get; set; }
        public DateTime DateEn { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
    }
}
