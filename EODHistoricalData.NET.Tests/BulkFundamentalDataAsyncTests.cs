using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class BulkFundamentalDataAsyncTests
    {
        [TestMethod]
        public async Task bulk_fundamental_stocks_returns_data()
        {
            var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = await client.GetBulkFundamentalStocksAsync(Consts.Exchange, 0, 5);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(5, bulkFundamentalStocks.Count);
        }
        
        [TestMethod]
        public async Task bulk_fundamental_stocks_large_returns_data_default_values()
        {
            var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = await client.GetBulkFundamentalStocksAsync(Consts.LargeExchange);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(1000, bulkFundamentalStocks.Count);
        }
        
        [TestMethod]
        public async Task bulk_fundamental_stocks_large_returns_data_no_greater_than_1000()
        {
            var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = await client.GetBulkFundamentalStocksAsync(Consts.LargeExchange, 0, 5000);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(1000, bulkFundamentalStocks.Count);
        }
        
        [TestMethod]
        public async Task bulk_fundamental_stocks_returns_data_lower_case_exchange()
        {
            var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = await client.GetBulkFundamentalStocksAsync(Consts.LargeExchange.ToLower(), 0, 5);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(5, bulkFundamentalStocks.Count);
        }
    }
}
