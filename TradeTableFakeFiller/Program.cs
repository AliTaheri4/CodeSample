using Microsoft.Data.SqlClient;
using MarketData.Infrastructure.Trades.Dtos;
using System.Data;
using MarketData.Domain.Trades;
using System.Text;

namespace CLI;
class Program
{

    public static int fakeRecordNeededCount = 10; // how many fake record is needed?
    public static string connectionString = "Server=.;Database=MabnaCodeChallengeDb;Integrated Security=true;TrustServerCertificate=true;";

    static void Main()
    {
        Executer().Wait();
    }
    public static async Task Executer()
    {
        var instruments = await GetLatestInstrumentClosePrices();
        foreach (var instrument in instruments)
        {

            var trades = new List<Trade>();
            for (int i = 1; i <= fakeRecordNeededCount; i++)
                trades.AddRange(FakeDataGenerator(instrument.InstrumentId, instrument.ClosePrice, instrument.Date.AddDays(i)));

            await BulkTradeInsert(trades);
        }
    }

    private static List<Trade> FakeDataGenerator(int instrumentId, decimal latestClosePrice, DateTime date)
    {
        var randomPrices = FakePriceGenerator(latestClosePrice);
        var trades = new List<Trade>();
        trades.Add(new Trade(instrumentId,
            date,
            randomPrices[0],
            randomPrices.Max(),
            randomPrices.Min(),
            randomPrices[3]));

        return trades;
    }
    private static List<decimal> FakePriceGenerator(decimal latestClosePrice)
    {
        Random random = new Random();
        var prices = new List<decimal>();

        //generate random price between -5 and +5 of last close price
        var fivePercentOfClosePrice = latestClosePrice / 100 * 5;
        for (int i = 0; i < 4; i++)
            prices.Add(random.Next((int)(latestClosePrice - fivePercentOfClosePrice), (int)(latestClosePrice + fivePercentOfClosePrice)));

        return prices;
    }

    private static async Task BulkTradeInsert(List<Trade> trades)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string tableName = "Trade";

            var sb = new StringBuilder();
            sb.AppendLine("use MabnaCodeChallengeDb");
            for (int i = 0; i < fakeRecordNeededCount; i++)
                sb.AppendLine($" INSERT INTO {tableName} (InstrumentId, [Open], Low, High, [Close], DateEn) " +
                  $"VALUES ({trades[i].InstrumentId},{trades[i].Open}, {trades[i].Low}, {trades[i].High}, {trades[i].Close}, '{trades[i].DateEn.ToShortDateString()}') ");

            using (SqlCommand command = new SqlCommand(sb.ToString(), connection))
            {
                await command.ExecuteScalarAsync();
            }

        }
    }

    public static async Task<List<TradeClosePriceDto>> GetLatestInstrumentClosePrices()
    {
        var list = new List<TradeClosePriceDto>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("dbo.GetLatestInstrumentClosePrices", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                    list.Add(new TradeClosePriceDto(int.Parse(reader["InstrumentId"].ToString()),
                                reader["Name"].ToString(),
                                decimal.Parse(reader["LastestClosePrice"].ToString()),
                                DateTime.Parse(reader["LatestDate"].ToString())
                                ));

                connection.Close();
            }
        }
        return list;
    }
}
