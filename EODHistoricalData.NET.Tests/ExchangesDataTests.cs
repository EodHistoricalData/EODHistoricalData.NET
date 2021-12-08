using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class ExchangesDataTests
    {
        [TestMethod]
        public void exchange_list_returns_data()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var exchanges = client.GetExchangeList();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }
    }
}
