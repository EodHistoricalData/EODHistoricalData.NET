using System;

namespace EODHistoricalData.NET.Tests
{
    internal static class Consts
    {
        internal static string ApiToken => Environment.GetEnvironmentVariable("EOD_API_TOKEN");

        internal static string TestSymbol = "AAPL.US";
        internal static string TestSymbolNonParsingData = "ALF.US";
        internal static string TestSymbolNullData = "AEDAUD.FOREX";
        internal static string TestSymbolReturnsEmpty = "VRGWX.NMFQS";
        internal static string TestIndex = "FCHI.INDX";
        internal static string TestETF = "VTI.US";
        internal static string TestFund = "SWPPX.US";
        internal static string Exchange = "PA";
        internal static string LargeExchange = "LSE";
        internal static string ValidIsinNumber = "AU0000071482";
        internal static string TestCompanyName = "apple";
        internal static DateTime StartDate = new DateTime(2012, 3, 14);
        internal static DateTime EndDate = new DateTime(2017, 3, 14);
        internal static DateTime OptionsStartDate = DateTime.UtcNow.AddYears(-1).AddDays(-2).Date;
        internal static DateTime OptionsEndDate = DateTime.UtcNow.AddMonths(-1).AddDays(-1).Date;
        internal static DateTime OptionsFuture3MonthEndDate = DateTime.UtcNow.AddMonths(3).Date;
        internal static DateTime OptionsTradeStartDate = new DateTime(2018, 3, 29);
        internal static DateTime OptionsTradeEndDate = new DateTime(2019, 7, 1);
        internal static string[] MultipleTestSymbol = new[] { TestSymbol, "VTI", "EUR.FOREX" };
        internal static string[] MultipleSymbolEarnings = new[] { "SNPS.US", "MDI.TO" };
    }
}
