using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class BulkFundamentalDataTests
    {
        [TestMethod]
        public void bulk_fundamental_stocks_returns_data()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = client.GetBulkFundamentalStocks(Consts.Exchange, 0, 5);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(5, bulkFundamentalStocks.Count());
        }
        
        [TestMethod]
        public void bulk_fundamental_stocks_large_returns_data_default_values()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = client.GetBulkFundamentalStocks(Consts.LargeExchange);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(1000, bulkFundamentalStocks.Count());
        }
        
        [TestMethod]
        public void bulk_fundamental_stocks_large_returns_data_no_greater_than_1000()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = client.GetBulkFundamentalStocks(Consts.LargeExchange, 0, 5000);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(1000, bulkFundamentalStocks.Count());
        }
        
        [TestMethod]
        public void bulk_fundamental_stocks_returns_data_lower_case_exchange()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var bulkFundamentalStocks = client.GetBulkFundamentalStocks(Consts.LargeExchange.ToLower(), 0, 5);
            Assert.IsNotNull(bulkFundamentalStocks);
            Assert.AreEqual(5, bulkFundamentalStocks.Count());
        }
    }
}
