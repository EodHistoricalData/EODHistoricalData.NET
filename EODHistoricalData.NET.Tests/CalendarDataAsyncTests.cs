using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class CalendarDataAsyncTests
    {
        #region EARNINGS

        [TestMethod]
        public async Task earnings_no_parameters_returns_prices_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var earnings = await client.GetEarningsAsync();
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }
        
        [TestMethod]
        public async Task earnings_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var earnings = await client.GetEarningsAsync(Consts.OptionsStartDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        [TestMethod]
        public async Task earnings_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var earnings = await client.GetEarningsAsync(null, Consts.OptionsEndDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        [TestMethod]
        public async Task earnings_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var earnings = await client.GetEarningsAsync(Consts.OptionsStartDate, Consts.OptionsEndDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        [TestMethod]
        public async Task earnings_with_symbols_list_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var earnings = await client.GetEarningsAsync(null, null, Consts.MultipleSymbolEarnings);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        #endregion EARNINGS

        #region IPOS

        [TestMethod]
        public async Task ipos_no_parameters_returns_prices_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var ipos = await client.GetIposAsync();
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public async Task ipos_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var ipos = await client.GetIposAsync(Consts.OptionsStartDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public async Task ipos_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var ipos = await client.GetIposAsync(null, Consts.OptionsEndDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public async Task ipos_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var ipos = await client.GetIposAsync(Consts.OptionsStartDate, Consts.OptionsEndDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public async Task ipos_with_symbols_list_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var ipos = await client.GetIposAsync(null, null, Consts.MultipleSymbolEarnings);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        #endregion IPOS

        #region SPLITS

        [TestMethod]
        public async Task splits_no_parameters_returns_prices_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var splits = await client.GetIncomingSplitsAsync();
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public async Task splits_with_from_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var splits = await client.GetIncomingSplitsAsync(Consts.OptionsStartDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public async Task splits_with_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var splits = await client.GetIncomingSplitsAsync(null, Consts.OptionsEndDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public async Task splits_with_from_and_to_date_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var splits = await client.GetIncomingSplitsAsync(Consts.OptionsStartDate, Consts.OptionsEndDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public async Task splits_with_symbols_list_returns_result_async()
        {
            using var client = new EODHistoricalDataAsyncClient(Consts.ApiToken, true);
            var splits = await client.GetIncomingSplitsAsync(null, null, Consts.MultipleSymbolEarnings);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        #endregion SPLITS
    }
}
