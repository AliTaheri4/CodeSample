using MarketData.Infrastructure.Commons;
using MarketData.Infrastructure.Trades.Contracts;
using MarketData.Infrastructure.Trades.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MarketData.Infrastructure.Trades
{
    public class TradeRepository : ITradeRepository
    {
        private readonly IConfiguration _configuration;
        public TradeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TradeClosePriceDto>> GetLatestInstrumentClosePrices(CancellationToken cancellationToken)
        {
            var connectionString = _configuration.GetConnectionString("MarketData");
            var list = new List<TradeClosePriceDto>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetLatestInstrumentClosePrices", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();
                        var reader = await command.ExecuteReaderAsync();

                        while (reader.Read())
                            list.Add(new TradeClosePriceDto(int.Parse(reader["InstrumentId"].ToString()),
                                reader["Name"].ToString(),
                                decimal.Parse(reader["LastestClosePrice"].ToString()),
                                DateTime.Parse(reader["LatestDate"].ToString())));
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL Error: " + ex.Message);
                        throw new CustomMarketDataException("Problem in fetching data");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return list;
        }
    }
}
