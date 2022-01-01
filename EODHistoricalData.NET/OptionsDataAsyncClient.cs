using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class OptionsDataAsyncClient : HttpApiAsyncClient
    {
        private const string OptionsDataUrl = "https://eodhistoricaldata.com/api/options/{0}?&api_token={1}{2}";

        internal OptionsDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal Task<Options> GetOptionsAsync(string symbol, DateTime? startDate, DateTime? endDate, DateTime? tradeStartDate = null, DateTime? tradeEndDate = null)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate, "&");
            var tradeDateParameters = string.Empty;
            if (tradeStartDate != null || tradeEndDate != null)
                tradeDateParameters = Utils.GetDateParametersAsString(tradeStartDate, tradeEndDate, "trade_date_from", "trade_date_to", " & ");
            return ExecuteQueryAsync(string.Format(OptionsDataUrl, symbol, _apiToken, $"{dateParameters}{tradeDateParameters}"), GetOptionsFromResponseAsync);
        }

        private async Task<Options> GetOptionsFromResponseAsync(HttpResponseMessage response)
        {
            return Options.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
