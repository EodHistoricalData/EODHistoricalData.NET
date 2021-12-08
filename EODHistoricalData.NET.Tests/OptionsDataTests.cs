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
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var options = client.GetOptions(null, null, null);
        }

        [TestMethod]
        public void options_valid_symbols_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, null, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, Consts.OptionsStartDate, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, null, Consts.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradestartdate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, Consts.OptionsTradeStartDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradesenddate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, null, Consts.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_both_tradedate_returns_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var options = client.GetOptions(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, Consts.OptionsTradeStartDate, Consts.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }
    }
}
