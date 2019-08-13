using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EODHistoricalData.NET
{
    internal class FundamentalDataClient : HttpApiClient
    {
        const string FundamentalUrl = @"https://eodhistoricaldata.com/api/fundamentals/{0}?api_token={1}";

        internal FundamentalDataClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal FundamentalStock GetFundamentalStock(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponse);
        }

        private FundamentalStock GetFundamentalStockFromResponse(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal FundamentalETF GetFundamentalETF(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalETFFromResponse);
        }

        private FundamentalETF GetFundamentalETFFromResponse(HttpResponseMessage response)
        {
            return FundamentalETF.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal FundamentalFund GetFundamentalFund(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalFundFromResponse);
        }

        private FundamentalFund GetFundamentalFundFromResponse(HttpResponseMessage response)
        {
            return FundamentalFund.FromJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}
