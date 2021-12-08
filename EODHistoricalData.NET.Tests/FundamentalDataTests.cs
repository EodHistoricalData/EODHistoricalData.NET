using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class FundamentalDataTests
    {
        [TestMethod]
        public void fundamental_stock_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalStock(Consts.Instance.TestSymbol);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public void fundamental_etf_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalETF(Consts.Instance.TestETF);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public void fundamental_fund_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalFund(Consts.Instance.TestFund);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public void index_composition_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var index = client.GetIndexComposition(Consts.Instance.TestIndex);
            Assert.IsNotNull(index);
        }
        
        [TestMethod]
        public void exchange_instruments_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var instruments = client.GetExchangeInstruments(Consts.Instance.Exchange);
            Assert.IsNotNull(instruments);
            Assert.IsNotNull(instruments.Count > 1000);
        }
    }
}
