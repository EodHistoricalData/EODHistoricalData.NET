using System;

namespace EODHistoricalData.NET.Tests
{
    internal class Constants
    {

        private static volatile object _lockObject = new object();
        
        private static Constants _instance;

        internal static Constants Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Constants();
                            _instance.ApiToken = Environment.GetEnvironmentVariable("EOD_API_TOKEN");
                        }
                    }
                }

                return _instance;
            }
        }

        private Constants()
        {
            // ApiToken = Environment.GetEnvironmentVariable("EOD_API_TOKEN");
        }

        internal string ApiToken { get; set; }
        internal string TestSymbol = "AAPL.US";
        internal string TestSymbolNonParsingData = "ALF.US";
        internal string TestSymbolNullData = "AEDAUD.FOREX";
        internal string TestSymbolReturnsEmpty = "VRGWX.NMFQS";
        internal string TestIndex = "FCHI.INDX";
        internal string TestETF = "VTI.US";
        internal string TestFund = "SWPPX.US";
        internal string Exchange = "PA";
        internal string LargeExchange = "LSE";
        internal DateTime StartDate = DateTime.UtcNow.AddYears(-10).AddDays(-1).Date;
        internal DateTime EndDate = DateTime.UtcNow.AddYears(-5).AddDays(-1).Date;
        internal DateTime OptionsStartDate = DateTime.UtcNow.AddYears(-1).AddDays(-2).Date;
        internal DateTime OptionsEndDate = DateTime.UtcNow.AddMonths(-1).AddDays(-1).Date;
        internal DateTime OptionsFuture3MonthEndDate = DateTime.UtcNow.AddMonths(3).Date;
        internal DateTime OptionsTradeStartDate = new DateTime(2018, 3, 29);
        internal DateTime OptionsTradeEndDate = new DateTime(2019, 7, 1);
        internal string[] MultipleTestSymbol = new[] { Instance.TestSymbol, "VTI", "EUR.FOREX" };
        internal string[] MultipleSymbolEarnings = new[] { "SNPS.US", "MDI.TO" };
    }
}
