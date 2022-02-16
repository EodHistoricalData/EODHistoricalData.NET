using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace EODHistoricalData.NET
{
    internal class StockPriceDataClient : HttpApiClient
    {
        private const string HistoricalDataUrl = "https://eodhistoricaldata.com/api/eod/{0}?{2}&api_token={1}&fmt=json";
        private const string RealTimeDataUrl = "https://eodhistoricaldata.com/api/real-time/{0}?&api_token={1}&fmt=json";

        internal StockPriceDataClient(string api, bool useProxy) : base(api, useProxy) { }

        internal List<HistoricalPrice> GetHistoricalPrices(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate);
            return ExecuteQuery(string.Format(HistoricalDataUrl, symbol, _apiToken, dateParameters), GetHistoricalPricesFromResponse);
        }

        private List<HistoricalPrice> GetHistoricalPricesFromResponse(HttpResponseMessage response)
        {
            return HistoricalPrice.GetListFromJson(response.Content.ReadAsStringAsync().Result) ?? new List<HistoricalPrice>();
        }

        internal List<RealTimePrice> GetRealTimePrices(string[] symbols)
        {
            var first = symbols[0];
            var others = symbols.Skip(1).ToArray();
            var sb = new StringBuilder();
            sb.Append(string.Format(RealTimeDataUrl, first, _apiToken));
            sb.Append($"&s={string.Join(",", others)}");

            return ExecuteQuery(sb.ToString(), GetRealTimePrices);
        }

        internal RealTimePrice GetRealTimePrice(string symbol)
        {
            return ExecuteQuery(string.Format(RealTimeDataUrl, symbol, _apiToken), GetRealTimePrice);
        }

        private RealTimePrice GetRealTimePrice(HttpResponseMessage response)
        {
            return RealTimePrice.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        private List<RealTimePrice> GetRealTimePrices(HttpResponseMessage response)
        {
            return SerializeRealTimePrice.GetListFromJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}
