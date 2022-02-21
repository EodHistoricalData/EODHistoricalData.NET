using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class ExchangesDataAsyncTests
    {
        [TestMethod]
        public async Task exchange_list_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var exchanges = await client.GetExchangeListAsync();
            Assert.IsNotNull(exchanges);
            Assert.IsNotNull(exchanges.Count > 50);
        }

        [TestMethod]
        public async Task exchange_details_returns_data_no_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var exchangeDetails = await client.GetExchangeDetailsAsync("US", null, null);
            Assert.IsNotNull(exchangeDetails);
            Assert.IsTrue(exchangeDetails.ExchangeHolidays.Count > 0);
        }

        [TestMethod]
        public async Task exchange_details_returns_data_start_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            DateTime startDate = DateTime.Now;

            var exchangeDetails = await client.GetExchangeDetailsAsync("US", startDate, null);
            Assert.IsNotNull(exchangeDetails);
            Assert.IsTrue(exchangeDetails.ExchangeHolidays.Count > 0);

            foreach (ExchangeHoliday holiday in exchangeDetails.ExchangeHolidays.Values)
            {
                Assert.IsTrue(holiday.Date >= startDate);
            }
        }

        [TestMethod]
        public async Task exchange_details_returns_data_end_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            DateTime endDate = DateTime.Now;

            var exchangeDetails = await client.GetExchangeDetailsAsync("US", null, endDate);
            Assert.IsNotNull(exchangeDetails);
            Assert.IsTrue(exchangeDetails.ExchangeHolidays.Count > 0);

            foreach (ExchangeHoliday holiday in exchangeDetails.ExchangeHolidays.Values)
            {
                Assert.IsTrue(holiday.Date <= endDate);
            }
        }

        [TestMethod]
        public async Task exchange_details_returns_data_start_end_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            DateTime startDate = DateTime.Now.Subtract(TimeSpan.FromDays(180));
            DateTime endDate = DateTime.Now.Add(TimeSpan.FromDays(180));

            var exchangeDetails = await client.GetExchangeDetailsAsync("US", startDate, endDate);
            Assert.IsNotNull(exchangeDetails);
            Assert.IsTrue(exchangeDetails.ExchangeHolidays.Count > 0);

            foreach (ExchangeHoliday holiday in exchangeDetails.ExchangeHolidays.Values)
            {
                Assert.IsTrue(holiday.Date >= startDate && holiday.Date <= endDate);
            }
        }

        [TestMethod]
        public async Task exchange_bulk_prices_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkPrices = await client.GetExchangeBulkPricesAsync("US", null);
            Assert.IsNotNull(exchangeBulkPrices);
            Assert.IsTrue(exchangeBulkPrices.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_splits_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkSplits = await client.GetExchangeBulkSplitsAsync("US", null);
            Assert.IsNotNull(exchangeBulkSplits);
            Assert.IsTrue(exchangeBulkSplits.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_dividends_returns_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkDividends = await client.GetExchangeBulkPricesAsync("US", null);
            Assert.IsNotNull(exchangeBulkDividends);
            Assert.IsTrue(exchangeBulkDividends.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_prices_returns_symbol_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkPrices = await client.GetExchangeBulkPricesAsync("US", null, "MSFT");
            Assert.IsNotNull(exchangeBulkPrices);
            Assert.IsTrue(exchangeBulkPrices.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_splits_returns_symbol_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkSplits = await client.GetExchangeBulkSplitsAsync("US", null, "MSFT");
            Assert.IsNotNull(exchangeBulkSplits);
            Assert.IsTrue(exchangeBulkSplits.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_dividends_returns_symbols_data_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);

            var exchangeBulkDividends = await client.GetExchangeBulkPricesAsync("US", null, "MSFT");
            Assert.IsNotNull(exchangeBulkDividends);
            Assert.IsTrue(exchangeBulkDividends.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_prices_returns_data_for_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var queryDate = new DateTime(2022, 2, 16);

            var exchangeBulkPrices = await client.GetExchangeBulkPricesAsync("US", queryDate);
            Assert.IsNotNull(exchangeBulkPrices);
            Assert.IsTrue(exchangeBulkPrices.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_splits_returns_data_for_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var queryDate = new DateTime(2022, 2, 16);

            var exchangeBulkSplits = await client.GetExchangeBulkSplitsAsync("US", queryDate);
            Assert.IsNotNull(exchangeBulkSplits);
            Assert.IsTrue(exchangeBulkSplits.Count > 0);
        }

        [TestMethod]
        public async Task exchange_bulk_dividends_returns_data_for_date_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var queryDate = new DateTime(2022, 2, 16);

            var exchangeBulkDividends = await client.GetExchangeBulkPricesAsync("US", queryDate);
            Assert.IsNotNull(exchangeBulkDividends);
            Assert.IsTrue(exchangeBulkDividends.Count > 0);
        }
    }
}
