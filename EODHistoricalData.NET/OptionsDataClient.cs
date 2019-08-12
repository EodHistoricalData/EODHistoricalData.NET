using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EODHistoricalData.NET
{
    internal class OptionsDataClient : HttpApiClient
    {
        const string OptionsDataUrl = "https://eodhistoricaldata.com/api/options/{0}?&api_token={1}{2}";


        internal OptionsDataClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal Options GetOptions(string symbol, DateTime? startDate, DateTime? endDate, DateTime? tradeStartDate = null, DateTime? tradeEndDate = null)
        {
            string dateParameters = Utils.GetDateParametersAsString(startDate, endDate, "&");
            string tradeDateParameters = string.Empty;
            if (tradeStartDate != null || tradeEndDate != null)
                tradeDateParameters = Utils.GetDateParametersAsString(tradeStartDate, tradeEndDate, "trade_date_from", "trade_date_to", " & ");
            return ExecuteQuery(string.Format(OptionsDataUrl, symbol, _apiToken, $"{dateParameters}{tradeDateParameters}"), GetOptionsFromResponse);
        }

        private Options GetOptionsFromResponse(HttpResponseMessage response)
        {
            return Options.FromJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}
