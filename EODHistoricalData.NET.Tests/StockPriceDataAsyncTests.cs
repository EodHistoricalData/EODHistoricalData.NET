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
            using var client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var prices = await client.GetHistoricalPricesAsync(null, null, null);
        }

        [TestMethod]
        public async Task historical_valid_symbols_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbol, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, null);
            var minDate = prices.Min(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.Instance.StartDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbol, null, Consts.Instance.EndDate);
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(maxDate == Consts.Instance.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_and_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbol, Consts.Instance.StartDate, Consts.Instance.EndDate);
            var minDate = prices.Min(x => x.Date).Date;
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.Instance.StartDate);
            Assert.IsTrue(maxDate == Consts.Instance.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_null_data_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbolNullData, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public async Task historical_valid_symbols_throws_not_found_async()
        {
            await Assert.ThrowsExceptionAsync<System.Net.Http.HttpRequestException>(async () =>
            {
                using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
                var prices = await client.GetHistoricalPricesAsync(Consts.Instance.TestSymbolReturnsEmpty, null, null);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_symbol_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var prices = await client.GetRealTimePriceAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_empty_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_list_with_null_element_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { null });
        }

        [TestMethod]
        public async Task realtime_multiple_valid_symbols_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var prices = await client.GetRealTimePricesAsync(Consts.Instance.MultipleTestSymbol);
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count == Consts.Instance.MultipleTestSymbol.Length);
        }

        [TestMethod]
        public async Task realtime_valid_symbol_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Consts.Instance.ApiToken, true);
            var price = await client.GetRealTimePriceAsync(Consts.Instance.TestSymbol);
            Assert.IsNotNull(price);
        }
    }
}
