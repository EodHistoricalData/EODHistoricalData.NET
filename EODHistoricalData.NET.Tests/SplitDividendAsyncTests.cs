using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class SplitDividendAsyncTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task null_symbol_dividend_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var divs = await client.GetDividendsAsync(null, null, null);
        }

        [TestMethod]
        public async Task valid_symbol_dividend_with_no_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var divs = await client.GetDividendsAsync(Consts.Instance.TestSymbol, null, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_dividend_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var divs = await client.GetDividendsAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_dividend_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var divs = await client.GetDividendsAsync(Consts.Instance.TestSymbol, null, Consts.Instance.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_dividend_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var divs = await client.GetDividendsAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, Consts.Instance.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task null_symbol_split_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var splits = await client.GetShareSplitsAsync(null, null, null);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_no_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var splits = await client.GetShareSplitsAsync(Consts.Instance.TestSymbol, null, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var splits = await client.GetShareSplitsAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var splits = await client.GetShareSplitsAsync(Consts.Instance.TestSymbol, null, Consts.Instance.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var splits = await client.GetShareSplitsAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, Consts.Instance.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }
    }
}
