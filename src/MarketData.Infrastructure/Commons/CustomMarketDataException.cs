using System;

namespace MarketData.Infrastructure.Commons
{
    internal class CustomMarketDataException : Exception
    {
        public CustomMarketDataException()
        {
        }

        public CustomMarketDataException(string message)
            : base(message)
        {
        }

        public CustomMarketDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
