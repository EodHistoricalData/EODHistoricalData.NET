﻿using System;

namespace EODHistoricalData.NET.Tests
{
    internal class Consts
    {
        internal const string ApiToken = "OeAFFmMliFG5orCUuwAKQ8l4WWFQ67YX";
        internal const string TestSymbol = "AAPL.US";
        internal const string TestSymbolNonParsingData = "ALF.US";
        internal const string TestSymbolNullData = "AEDAUD.FOREX";
        internal const string TestSymbolReturnsEmpty = "VRGWX.NMFQS";
        internal const string TestIndex = "FCHI.INDX";
        internal const string TestETF = "VTI.US";
        internal const string TestFund = "SWPPX.US";
        internal const string Exchange = "PA";
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
