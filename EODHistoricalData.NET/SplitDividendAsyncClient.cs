using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class SplitDividendAsyncClient : HttpApiAsyncClient
    {
        private const string DividendDataUrl = "https://eodhistoricaldata.com/api/div/{0}?api_token={1}{2}&fmt=json";
        private const string SplitDataUrl = "https://eodhistoricaldata.com/api/splits/{0}?api_token={1}{2}&fmt=json";

        private const string Prefix = "&";

        internal SplitDividendAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal Task<List<Dividend>> GetDividendsAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate, Prefix);
            return ExecuteQueryAsync(string.Format(DividendDataUrl, symbol, _apiToken, dateParameters), GetDividendsFromResponseAsync);
        }

        private async Task<List<Dividend>> GetDividendsFromResponseAsync(HttpResponseMessage response)
        {
            return Dividend.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<List<ShareSplit>> GetShareSplitsAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate, Prefix);
            return ExecuteQueryAsync(string.Format(SplitDataUrl, symbol, _apiToken, dateParameters), GetSplitsFromResponseAsync);
        }

        private async Task<List<ShareSplit>> GetSplitsFromResponseAsync(HttpResponseMessage response)
        {
            return ShareSplit.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
