using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class FundamentalDataAsyncTests
    {
        [TestMethod]
        public void fundamental_stock_returns_data()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = client.GetFundamentalStock(Consts.TestSymbol);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_stock_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = await client.GetFundamentalStockAsync(Consts.TestSymbol);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public void fundamental_etf_returns_data()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = client.GetFundamentalETF(Consts.TestETF);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public async Task fundamental_etf_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = await client.GetFundamentalETFAsync(Consts.TestETF);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public void fundamental_fund_returns_data()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var fundamental = client.GetFundamentalFund(Consts.TestFund);
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
        public void index_composition_returns_data()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var index = client.GetIndexComposition(Consts.TestIndex);
            Assert.IsNotNull(index);
        }

        [TestMethod]
        public async Task index_composition_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var index = await client.GetIndexCompositionAsync(Consts.TestIndex);
            Assert.IsNotNull(index);
        }
        
        [TestMethod]
        public void exchange_instruments_returns_data()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var instruments = client.GetExchangeInstruments(Consts.Exchange);
            Assert.IsNotNull(instruments);
            Assert.IsNotNull(instruments.Count > 1000);
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
