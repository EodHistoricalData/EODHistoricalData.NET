using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class ExchangesDataTests
    {
        [TestMethod]
        public void exchange_list_returns_data()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var exchanges = client.GetExchangeList();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }
        
        [TestMethod]
        public async Task exchange_list_returns_data_async()
        {
            var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var exchanges = await client.GetExchangeListAsync();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }
    }
}
