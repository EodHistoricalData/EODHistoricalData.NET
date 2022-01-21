using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public async Task search_by_isin_number_test_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var instruments = await client.SearchAsync(Consts.ValidIsinNumber);
            Assert.IsTrue(instruments.Count > 0);
        }
        
        [TestMethod]
        public async Task search_by_company_name_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var instruments = await client.SearchAsync(Consts.TestCompanyName);
            Assert.IsTrue(instruments.Count > 0);
        }
    }
}
