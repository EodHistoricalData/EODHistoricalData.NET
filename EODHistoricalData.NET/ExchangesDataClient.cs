using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class ExchangesDataClient : HttpApiClient
    {
        const string ExchangeListUrl =
            @"https://eodhistoricaldata.com/api/exchanges-list/?api_token={0}&fmt=json";
        
        internal ExchangesDataClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal List<Exchange> GetExchanges()
        {
            return ExecuteQuery(string.Format(ExchangeListUrl, _apiToken), GetExchangesFromResponse);
        }

        private List<Exchange> GetExchangesFromResponse(HttpResponseMessage response)
        {
            return Exchange.FromJson(response.Content.ReadAsStringAsync().Result);
        }
        
        internal Task<List<Exchange>> GetExchangesAsync()
        {
            return ExecuteQueryAsync(string.Format(ExchangeListUrl, _apiToken), GetExchangesFromResponseAsync);
        }

        private async Task<List<Exchange>> GetExchangesFromResponseAsync(HttpResponseMessage response)
        {
            return Exchange.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
