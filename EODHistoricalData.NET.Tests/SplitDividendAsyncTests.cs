using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class SplitDividendAsyncTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_dividend_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            List<Dividend> divs = client.GetDividendsAsync(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_no_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividendsAsync(Consts.TestSymbol, null, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividendsAsync(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividendsAsync(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividendsAsync(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_split_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            List<ShareSplit> splits = client.GetShareSplitsAsync(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_split_with_no_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplitsAsync(Consts.TestSymbol, null, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplitsAsync(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplitsAsync(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplitsAsync(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }
    }
}
