using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class ExchangesDataTests
    {
        [TestMethod]
        public void exchange_list_returns_data()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<Exchange> exchanges = client.GetExchangeList();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }
    }
}
