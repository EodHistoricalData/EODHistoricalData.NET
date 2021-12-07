using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class StockPriceDataAsyncTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task historical_null_symbol_throws_exception_async_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            var prices = await client.GetHistoricalPricesAsync(null, null, null);
        }

        [TestMethod]
        public async Task historical_valid_symbols_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbol, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbol, Consts.StartDate, null);
            var minDate = prices.Min(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.StartDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbol, null, Consts.EndDate);
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(maxDate == Consts.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_and_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            var minDate = prices.Min(x => x.Date).Date;
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.StartDate);
            Assert.IsTrue(maxDate == Consts.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_null_data_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbolNullData, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public void historical_valid_symbols_throws_not_found_async()
        {
            Assert.ThrowsException<System.Net.Http.HttpRequestException>(async () =>
            {
                using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
                var prices = await client.GetHistoricalPricesAsync(Consts.TestSymbolReturnsEmpty, null, null);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            var prices = await client.GetRealTimePricesAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_symbol_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            var prices = await client.GetRealTimePriceAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_empty_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_list_with_null_element_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { null });
        }

        [TestMethod]
        public async Task realtime_multiple_valid_symbols_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var prices = await client.GetRealTimePricesAsync(Consts.MultipleTestSymbol);
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count == Consts.MultipleTestSymbol.Length);
        }

        [TestMethod]
        public async Task realtime_valid_symbol_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var price = await client.GetRealTimePriceAsync(Consts.TestSymbol);
            Assert.IsNotNull(price);
        }

        [TestMethod]
        public async Task realtime_valid_symbol_return_nonparsing_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var price = await client.GetRealTimePriceAsync(Consts.TestSymbolNonParsingData);
            Assert.IsNotNull(price);
            Assert.IsTrue(price.ErrorMessages.Count > 1);
        }
    }
}
