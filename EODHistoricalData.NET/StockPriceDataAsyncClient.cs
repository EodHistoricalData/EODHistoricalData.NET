﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class StockPriceDataAsyncClient : HttpApiAsyncClient
    {
        private const string HistoricalDataUrl = "https://eodhistoricaldata.com/api/eod/{0}?{2}&api_token={1}&fmt=json";
        private const string RealTimeDataUrl = "https://eodhistoricaldata.com/api/real-time/{0}?&api_token={1}&fmt=json";
        private const string BulkLastDayDataUrl = "https://eodhistoricaldata.com/api/eod-bulk-last-day/US?api_token={0}&fmt=json";

        private const string Prefix = "&";

        internal StockPriceDataAsyncClient(string api, bool useProxy) : base(api, useProxy) { }

        internal Task<List<HistoricalPrice>> GetHistoricalPricesAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate);
            return ExecuteQueryAsync(string.Format(HistoricalDataUrl, symbol, _apiToken, dateParameters), GetHistoricalPricesFromResponseAsync);
        }

        private async Task<List<BulkHistoricalPrice>> GetBulkHistoricalPricesFromResponseAsync(HttpResponseMessage response)
        {
            return BulkHistoricalPrice.GetListFromJson(await response.Content.ReadAsStringAsync()) ?? new List<BulkHistoricalPrice>();
        }

        private async Task<List<HistoricalPrice>> GetHistoricalPricesFromResponseAsync(HttpResponseMessage response)
        {
            return HistoricalPrice.GetListFromJson(await response.Content.ReadAsStringAsync()) ?? new List<HistoricalPrice>();
        }

        internal Task<List<RealTimePrice>> GetRealTimePricesAsync(string[] symbols)
        {
            var first = symbols[0];
            var others = symbols.Skip(1).ToArray();
            var sb = new StringBuilder();
            sb.Append(string.Format(RealTimeDataUrl, first, _apiToken));
            sb.Append($"&s={string.Join(",", others)}");

            return ExecuteQueryAsync(sb.ToString(), GetRealTimePricesAsync);
        }

        internal Task<RealTimePrice> GetRealTimePriceAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(RealTimeDataUrl, symbol, _apiToken), GetRealTimePriceAsync);
        }

        private async Task<RealTimePrice> GetRealTimePriceAsync(HttpResponseMessage response)
        {
            return RealTimePrice.FromJson(await response.Content.ReadAsStringAsync());
        }

        private async Task<List<RealTimePrice>> GetRealTimePricesAsync(HttpResponseMessage response)
        {
            return SerializeRealTimePrice.GetListFromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<List<BulkHistoricalPrice>> GetLastDayPricesAsync(DateTime? endOfDayDate, string[] symbols = null)
        {
            var symbolList = "";
            if (symbols != null && symbols.Length > 0)
                symbolList = $"&symbols={string.Join(",", symbols)}";

            var dateParameter = Utils.GetDateParameterAsString(endOfDayDate, Prefix);

            var optionalParameters = "";
            if (!string.IsNullOrWhiteSpace(dateParameter) || !string.IsNullOrWhiteSpace(symbolList))
                optionalParameters = string.Format("{0}{1}", dateParameter, symbolList);

            return ExecuteQueryAsync(string.Format(BulkLastDayDataUrl, _apiToken) + optionalParameters, GetBulkHistoricalPricesFromResponseAsync);
        }
    }
}
