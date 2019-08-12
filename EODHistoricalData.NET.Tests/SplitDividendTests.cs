using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class SplitDividendTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_dividend_throws_exception()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken);
            List<Dividend> divs = client.GetDividends(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_no_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividends(Consts.TestSymbol, null, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividends(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_to_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividends(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_dividend_with_from_and_to_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<Dividend> divs = client.GetDividends(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(divs.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void null_symbol_split_throws_exception()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken);
            List<ShareSplit> splits = client.GetShareSplits(null, null, null);
        }

        [TestMethod]
        public void valid_symbol_split_with_no_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplits(Consts.TestSymbol, null, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplits(Consts.TestSymbol, Consts.StartDate, null);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplits(Consts.TestSymbol, null, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);
            List<ShareSplit> splits = client.GetShareSplits(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            Assert.IsTrue(splits.Count > 0);
        }
    }
}
