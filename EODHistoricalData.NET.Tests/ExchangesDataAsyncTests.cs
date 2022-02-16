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
    }
}
