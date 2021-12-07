using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class OptionsDataAsyncTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void options_null_list_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            Options options = client.GetOptionsAsync(null, null, null);
        }

        [TestMethod]
        public void options_valid_symbols_returns_prices_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, null, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, Consts.OptionsStartDate, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, null, Consts.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradestartdate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, Consts.OptionsTradeStartDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_tradesenddate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, null, Consts.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public void valid_symbol_split_with_from_and_to_date_and_both_tradedate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            Options options = client.GetOptionsAsync(Consts.TestSymbol, Consts.OptionsStartDate, Consts.OptionsEndDate, Consts.OptionsTradeStartDate, Consts.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }
    }
}
