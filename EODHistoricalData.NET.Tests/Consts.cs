using System;
using System.Collections.Generic;
using System.Text;

namespace EODHistoricalData.NET.Tests
{
    internal class Consts
    {
        internal const string ApiToken = "OeAFFmMliFG5orCUuwAKQ8l4WWFQ67YX";
        internal const string TestSymbol = "AAPL.US";
        internal static readonly DateTime StartDate = DateTime.Now.AddYears(-10).AddDays(-1).Date;
        internal static readonly DateTime EndDate = DateTime.Now.AddYears(-5).AddDays(-1).Date;
        internal static readonly DateTime OptionsStartDate = DateTime.Now.AddYears(-1).AddDays(-2).Date;
        internal static readonly DateTime OptionsEndDate = DateTime.Now.AddMonths(-1).AddDays(-1).Date;
        internal static readonly DateTime OptionsTradeStartDate = new DateTime(2018, 3, 29);
        internal static readonly DateTime OptionsTradeEndDate = new DateTime(2019, 7, 1);
        internal static readonly string[] MultipleTestSymbol = new[] { TestSymbol, "VTI", "EUR.FOREX" };
        internal static readonly string[] MultipleSymbolEarnings = new[] { "SNPS.US", "MDI.TO" };
    }
}
