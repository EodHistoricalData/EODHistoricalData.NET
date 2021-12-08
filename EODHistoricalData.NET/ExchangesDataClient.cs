using System.Collections.Generic;
using System.Net.Http;

namespace EODHistoricalData.NET
{
    internal class ExchangesDataClient : HttpApiClient
    {
        private const string ExchangeListUrl =
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
    }
}
