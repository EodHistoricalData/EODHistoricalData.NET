using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class ExchangesDataAsyncTests
    {
        [TestMethod]
        public async Task exchange_list_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var exchanges = await client.GetExchangeListAsync();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }
    }
}
