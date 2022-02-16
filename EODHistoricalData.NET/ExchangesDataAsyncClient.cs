using EODHistoricalData.NET.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class ExchangesDataAsyncClient : HttpApiAsyncClient
    {
        private const string ExchangeListUrl = @"https://eodhistoricaldata.com/api/exchanges-list/?api_token={0}&fmt=json";
        private const string ExchangeDetailsUrl = @"https://eodhistoricaldata.com/api/exchange-details/{0}?api_token={1}&{2}";
        
        internal ExchangesDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }
        
        internal Task<List<Exchange>> GetExchangesAsync()
        {
            return ExecuteQueryAsync(string.Format(ExchangeListUrl, _apiToken), GetExchangesFromResponseAsync);
        }

        private async Task<List<Exchange>> GetExchangesFromResponseAsync(HttpResponseMessage response)
        {
            return Exchange.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<ExchangeDetails> GetExchangeDetailsAsync(string exchange, DateTime? startDate, DateTime? endDate)
        {
            var dateParameters = Utils.GetDateParametersAsString(startDate, endDate);
            return ExecuteQueryAsync(string.Format(ExchangeDetailsUrl, exchange, _apiToken, dateParameters), GetExchangeDetailsFromResponseAsync);
        }

        private async Task<ExchangeDetails> GetExchangeDetailsFromResponseAsync(HttpResponseMessage response)
        {
            return ExchangeDetails.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
