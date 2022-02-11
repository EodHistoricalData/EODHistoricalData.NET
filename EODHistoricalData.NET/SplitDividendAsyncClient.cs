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
        private const string BulkLastDayDividendDataUrl = "https://eodhistoricaldata.com/api/eod-bulk-last-day/US?api_token={0}&type=dividends&fmt=json";
        private const string BulkLastDaySplitDataUrl = "https://eodhistoricaldata.com/api/eod-bulk-last-day/US?api_token={0}&type=splits&fmt=json";

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

        internal Task<List<BulkDividend>> GetLastDayDividendsAsync(DateTime? endOfDayDate)
        {
            var dateParameter = Utils.GetDateParameterAsString(endOfDayDate, Prefix);

            var optionalParameters = "";
            if (string.IsNullOrWhiteSpace(dateParameter))
                optionalParameters = dateParameter;

            return ExecuteQueryAsync(string.Format(BulkLastDayDividendDataUrl, _apiToken) + optionalParameters, GetBulkDividendsFromResponseAsync);
        }

        private async Task<List<BulkDividend>> GetBulkDividendsFromResponseAsync(HttpResponseMessage response)
        {
            return BulkDividend.FromJson(await response.Content.ReadAsStringAsync());
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

        internal Task<List<BulkShareSplit>> GetLastDaySplitsAsync(DateTime? endOfDayDate)
        {
            var dateParameter = Utils.GetDateParameterAsString(endOfDayDate, Prefix);

            var optionalParameters = "";
            if (string.IsNullOrWhiteSpace(dateParameter))
                optionalParameters = dateParameter;

            return ExecuteQueryAsync(string.Format(BulkLastDaySplitDataUrl, _apiToken) + optionalParameters, GetBulkSplitsFromResponseAsync);
        }

        private async Task<List<BulkShareSplit>> GetBulkSplitsFromResponseAsync(HttpResponseMessage response)
        {
            return BulkShareSplit.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
