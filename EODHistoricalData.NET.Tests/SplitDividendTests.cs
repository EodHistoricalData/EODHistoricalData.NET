using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class SplitDividendTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_dividend_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var divs = client.GetDividends(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_no_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var divs = client.GetDividends(Consts.TestSymbol, null, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var divs = client.GetDividends(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var divs = client.GetDividends(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var divs = client.GetDividends(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_split_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var splits = client.GetShareSplits(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_split_with_no_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var splits = client.GetShareSplits(Consts.TestSymbol, null, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var splits = client.GetShareSplits(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var splits = client.GetShareSplits(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var splits = client.GetShareSplits(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }
    }
}
