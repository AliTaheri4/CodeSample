using MarketData.Domain.Utilities;

namespace MarketData.Domain.Instruments
{
    public class Instrument: BaseEntity<int>
    {
        public Instrument(string name)
        {
            Name = name;
        }
        public string Name{ get; set; }
    }
}
