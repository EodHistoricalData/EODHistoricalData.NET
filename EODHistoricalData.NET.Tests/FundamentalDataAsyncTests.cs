using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class FundamentalDataAsyncTests
    {
        [TestMethod]
        public async Task fundamental_stock_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var fundamental = await client.GetFundamentalStockAsync(Constants.Instance.TestSymbol);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_etf_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var fundamental = await client.GetFundamentalETFAsync(Constants.Instance.TestETF);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_fund_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var fundamental = await client.GetFundamentalFundAsync(Constants.Instance.TestFund);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public async Task index_composition_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var index = await client.GetIndexCompositionAsync(Constants.Instance.TestIndex);
            Assert.IsNotNull(index);
        }
        
        [TestMethod]
        public async Task exchange_instruments_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var instruments = await client.GetExchangeInstrumentsAsync(Constants.Instance.Exchange);
            Assert.IsNotNull(instruments);
            Assert.IsNotNull(instruments.Count > 1000);
        }
    }
}
