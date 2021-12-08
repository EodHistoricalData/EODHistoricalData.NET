using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class OptionsDataAsyncTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task options_null_list_throws_exception_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var options = await client.GetOptionsAsync(null, null, null);
        }

        [TestMethod]
        public async Task options_valid_symbols_returns_prices_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, null, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, null);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, null, Consts.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_and_to_date_and_tradestartdate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, Consts.Instance.OptionsTradeStartDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_and_to_date_and_tradesenddate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, null, Consts.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }

        [TestMethod]
        public async Task valid_symbol_split_with_from_and_to_date_and_both_tradedate_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var options = await client.GetOptionsAsync(Consts.Instance.TestSymbol, Consts.Instance.OptionsStartDate, Consts.Instance.OptionsEndDate, Consts.Instance.OptionsTradeStartDate, Consts.Instance.OptionsTradeEndDate);
            Assert.IsNotNull(options);
            Assert.IsTrue(options.Data.Count > 0);
        }
    }
}
