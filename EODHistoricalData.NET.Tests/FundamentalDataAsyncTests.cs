using System.Linq;
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
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = await client.GetFundamentalStockAsync(Consts.TestSymbol);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_etf_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = await client.GetFundamentalETFAsync(Consts.TestETF);
            
            Assert.IsNotNull(fundamental.EtfData.Top10_Holdings.First().Value.Assets);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_fund_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = await client.GetFundamentalFundAsync(Consts.TestFund);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public async Task index_composition_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var index = await client.GetIndexCompositionAsync(Consts.TestIndex);
            Assert.IsNotNull(index);
        }
        
        [TestMethod]
        public async Task exchange_instruments_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var instruments = await client.GetExchangeInstrumentsAsync(Consts.Exchange);
            Assert.IsNotNull(instruments);
            Assert.IsNotNull(instruments.Count > 1000);
        }
    }
}
