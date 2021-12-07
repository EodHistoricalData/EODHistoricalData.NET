using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EODHistoricalData.NET
{
    internal class SplitDividendClient : HttpApiClient
    {
        private const string DividendDataUrl = "https://eodhistoricaldata.com/api/div/{0}?api_token={1}{2}&fmt=json";
        private const string SplitDataUrl = "https://eodhistoricaldata.com/api/splits/{0}?api_token={1}{2}&fmt=json";

        private const string Prefix = "&";

        internal SplitDividendClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal List<Dividend> GetDividends(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate, Prefix);
            return ExecuteQuery(string.Format(DividendDataUrl, symbol, _apiToken, dateParameters), GetDividendsFromResponse);
        }

        List<Dividend> GetDividendsFromResponse(HttpResponseMessage response)
        {
            return Dividend.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal List<ShareSplit> GetShareSplits(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate, Prefix);
            return ExecuteQuery(string.Format(SplitDataUrl, symbol, _apiToken, dateParameters), GetSplitsFromResponse);
        }

        private List<ShareSplit> GetSplitsFromResponse(HttpResponseMessage response)
        {
            return ShareSplit.FromJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}
