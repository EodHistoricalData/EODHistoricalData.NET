using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class StockPriceDataTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void historical_null_symbol_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var prices = client.GetHistoricalPrices(null, null, null);
        }

        [TestMethod]
        public void historical_valid_symbols_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetHistoricalPrices(Consts.TestSymbol, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public void historical_valid_symbols_with_from_date_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetHistoricalPrices(Consts.TestSymbol, Consts.StartDate, null);
            var minDate = prices.Min(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.StartDate);
        }

        [TestMethod]
        public void historical_valid_symbols_with_to_date_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetHistoricalPrices(Consts.TestSymbol, null, Consts.EndDate);
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(maxDate == Consts.EndDate);
        }

        [TestMethod]
        public void historical_valid_symbols_with_from_and_to_date_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetHistoricalPrices(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);
            var minDate = prices.Min(x => x.Date).Date;
            var maxDate = prices.Max(x => x.Date).Date;
            Assert.IsTrue(minDate == Consts.StartDate);
            Assert.IsTrue(maxDate == Consts.EndDate);
        }

        [TestMethod]
        public void historical_valid_symbols_null_data_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetHistoricalPrices(Consts.TestSymbolNullData, null, null);
            Assert.IsTrue(prices.Count > 0);
        }

        [TestMethod]
        public void historical_valid_symbols_throws_not_found()
        {
            Assert.ThrowsException<System.Net.Http.HttpRequestException>(() =>
            {
                using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
                var prices = client.GetHistoricalPrices(Consts.TestSymbolReturnsEmpty, null, null);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void realtime_null_list_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var prices = client.GetRealTimePrices(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void realtime_null_symbol_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var prices = client.GetRealTimePrice(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void realtime_empty_list_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var prices = client.GetRealTimePrices(new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void realtime_list_with_null_element_throws_exception()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken);
            var prices = client.GetRealTimePrices(new string[] { null });
        }

        [TestMethod]
        public void realtime_multiple_valid_symbols_return_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var prices = client.GetRealTimePrices(Consts.MultipleTestSymbol);
            Assert.IsNotNull(prices);
            Assert.IsTrue(prices.Count == Consts.MultipleTestSymbol.Length);
        }

        [TestMethod]
        public void realtime_valid_symbol_return_result()
        {
            using var client = new EODHistoricalDataClient(Consts.ApiToken, true);
            var price = client.GetRealTimePrice(Consts.TestSymbol);
            Assert.IsNotNull(price);
        }
    }
}
