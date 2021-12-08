using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EODHistoricalData.NET.Tests
{
    [TestClass]
    public class CalendarDataTests
    {
        #region EARNINGS

        [TestMethod]
        public void earnings_no_parameters_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var earnings = client.GetEarnings();
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }
        
        [TestMethod]
        public void earnings_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var earnings = client.GetEarnings(Constants.Instance.OptionsStartDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        [TestMethod]
        public void earnings_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var earnings = client.GetEarnings(null, Constants.Instance.OptionsFuture3MonthEndDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        [TestMethod]
        public void earnings_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var earnings = client.GetEarnings(Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate);
            Assert.IsNotNull(earnings);
            Assert.IsTrue(earnings.EarningsData.Count > 0);
        }

        // [TestMethod]
        // public void earnings_with_symbols_list_returns_result()
        // {
        //     using var client = new EODHistoricalDataClient(Consts.Instance.ApiToken, true);
        //     var earnings = client.GetEarnings(null, null, Consts.MultipleSymbolEarnings);
        //     Assert.IsNotNull(earnings);
        //     Assert.IsTrue(earnings.EarningsData.Count > 0);
        // }

        #endregion EARNINGS

        #region IPOS

        [TestMethod]
        public void ipos_no_parameters_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var ipos = client.GetIpos();
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public void ipos_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var ipos = client.GetIpos(Constants.Instance.OptionsStartDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public void ipos_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var ipos = client.GetIpos(null, Constants.Instance.OptionsFuture3MonthEndDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public void ipos_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var ipos = client.GetIpos(Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        [TestMethod]
        public void ipos_with_symbols_list_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var ipos = client.GetIpos(null, null, Constants.Instance.MultipleSymbolEarnings);
            Assert.IsNotNull(ipos);
            Assert.IsTrue(ipos.IposData.Count > 0);
        }

        #endregion IPOS

        #region SPLITS

        [TestMethod]
        public void splits_no_parameters_returns_prices()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var splits = client.GetIncomingSplits();
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public void splits_with_from_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var splits = client.GetIncomingSplits(Constants.Instance.OptionsStartDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public void splits_with_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var splits = client.GetIncomingSplits(null, Constants.Instance.OptionsFuture3MonthEndDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public void splits_with_from_and_to_date_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var splits = client.GetIncomingSplits(Constants.Instance.OptionsStartDate, Constants.Instance.OptionsEndDate);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        [TestMethod]
        public void splits_with_symbols_list_returns_result()
        {
            using var client = new EODHistoricalDataClient(Constants.Instance.ApiToken, true);
            var splits = client.GetIncomingSplits(null, null, Constants.Instance.MultipleSymbolEarnings);
            Assert.IsNotNull(splits);
            Assert.IsTrue(splits.Splits.Count > 0);
        }

        #endregion SPLITS
    }
}
