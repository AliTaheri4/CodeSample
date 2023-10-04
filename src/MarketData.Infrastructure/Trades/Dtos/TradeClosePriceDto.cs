using System;

namespace MarketData.Infrastructure.Trades.Dtos
{
    public class TradeClosePriceDto
    {
        public TradeClosePriceDto(int instrumentId,string name, decimal closePrice, DateTime date)
        {
            InstrumentId = instrumentId;
            Name= name;
            ClosePrice= closePrice;
            Date = date;
        }
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public decimal ClosePrice { get; set; }
        public DateTime Date{ get; set; }
    }
}
