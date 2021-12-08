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
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken);
            var options = client.GetOptions(null, null, null);
        }

        [TestMethod]
        public void options_valid_symbols_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, null, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, Constants.Instance.OptionsStartDate, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, null, Constants.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradestartdate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate, Constants.Instance.OptionsTradeStartDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradesenddate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate, null, Constants.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_both_tradedate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var options = client.GetOptions(Constants.Instance.TestSymbol, Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate, Constants.Instance.OptionsTradeStartDate, Constants.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }
    }
}
