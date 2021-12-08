using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class FundamentalDataTests
    {
        [TestMethod]
        public void fundamental_stock_returns_data()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalStock(Constants.Instance.TestSymbol);
            Assert.IsNotNull(fundamental);
        }
        
        [TestMethod]
        public void fundamental_etf_returns_data()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalETF(Constants.Instance.TestETF);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public void fundamental_fund_returns_data()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var fundamental = client.GetFundamentalFund(Constants.Instance.TestFund);
            Assert.IsNotNull(fundamental);
        }

        [TestMethod]
        public void index_composition_returns_data()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var index = client.GetIndexComposition(Constants.Instance.TestIndex);
            Assert.IsNotNull(index);
        }
        
        [TestMethod]
        public void exchange_instruments_returns_data()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var instruments = client.GetExchangeInstruments(Constants.Instance.Exchange);
            Assert.IsNotNull(instruments);
            Assert.IsNotNull(instruments.Count > 1000);
        }
    }
}
