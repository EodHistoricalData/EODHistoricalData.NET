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
            using var client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken);
            var prices = await client.GetHistoricalPricesAsync(null, null, null);
        }

        [TestMethod]
        public async Task historical_valid_symbols_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbol, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbol, Constants.Instance.StartDate, null);
            var minDate = prices.Min(x => x.Date).Date;
            Assert.IsTrue(minDate == Constants.Instance.StartDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbol, null, Constants.Instance.EndDate);
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(maxDate == Constants.Instance.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_with_from_and_to_date_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbol, Constants.Instance.StartDate, Constants.Instance.EndDate);
            var minDate = prices.Min(x => x.Date).Date;
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(minDate == Constants.Instance.StartDate);
            Assert.IsTrue(maxDate == Constants.Instance.EndDate);
        }

        [TestMethod]
        public async Task historical_valid_symbols_null_data_returns_prices_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbolNullData, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public async Task historical_valid_symbols_throws_not_found_async()
        {
            await Assert.ThrowsExceptionAsync<System.Net.Http.HttpRequestException>(async () =>
            {
                using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
                var prices = await client.GetHistoricalPricesAsync(Constants.Instance.TestSymbolReturnsEmpty, null, null);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_null_symbol_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken);
            var prices = await client.GetRealTimePriceAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_empty_list_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task realtime_list_with_null_element_throws_exception_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken);
            var prices = await client.GetRealTimePricesAsync(new string[] { null });
        }

        [TestMethod]
        public async Task realtime_multiple_valid_symbols_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var prices = await client.GetRealTimePricesAsync(Constants.Instance.MultipleTestSymbol);
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count == Constants.Instance.MultipleTestSymbol.Length);
        }

        [TestMethod]
        public async Task realtime_valid_symbol_return_result_async()
        {
            using var  client = new EODHistoricalDataAsyncClient(Constants.Instance.ApiToken, true);
            var price = await client.GetRealTimePriceAsync(Constants.Instance.TestSymbol);
            Assert.IsNotNull(price);
        }
    }
}
