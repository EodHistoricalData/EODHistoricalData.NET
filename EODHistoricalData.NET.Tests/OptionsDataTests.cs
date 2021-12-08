using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class OptionsDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void options_null_list_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken);
            var options = client.GetOptions(null, null, null);
        }

        [TestMethod]
        public void options_valid_symbols_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, null, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, null, Consts.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradestartdate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, Consts.Instance.OptionsTradeStartDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradesenddate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, null, Consts.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_both_tradedate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
            var options = client.GetOptions(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, Consts.Instance.OptionsTradeStartDate, Consts.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }
    }
}
