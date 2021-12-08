using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class ExchangesDataAsyncClient : HttpApiAsyncClient
    {
        private const string ExchangeListUrl =
            @"https://eodhistoricaldata.com/api/exchanges-list/?api_token={0}&fmt=json";
        
        internal ExchangesDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }
        
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
