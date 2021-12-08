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
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken);
            var divs = client.GetDividends(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_no_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var divs = client.GetDividends(Consts.Instance.TestSymbol, null, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var divs = client.GetDividends(Consts.Instance.TestSymbol, Consts.Instance.StartDate, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var divs = client.GetDividends(Consts.Instance.TestSymbol, null, Consts.Instance.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var divs = client.GetDividends(Consts.Instance.TestSymbol, Consts.Instance.StartDate, Consts.Instance.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_split_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken);
            var splits = client.GetShareSplits(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_split_with_no_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var splits = client.GetShareSplits(Consts.Instance.TestSymbol, null, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var splits = client.GetShareSplits(Consts.Instance.TestSymbol, Consts.Instance.StartDate, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var splits = client.GetShareSplits(Consts.Instance.TestSymbol, null, Consts.Instance.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var splits = client.GetShareSplits(Consts.Instance.TestSymbol, Consts.Instance.StartDate, Consts.Instance.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }
    }
}
