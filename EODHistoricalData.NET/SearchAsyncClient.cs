using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class SearchAsyncClient : HttpApiAsyncClient
    {
        private const string SearchUrl = @"https://eodhistoricaldata.com/api/search/{0}?api_token={1}";

        internal SearchAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        public Task<List<SearchInstrument>> SearchAsync(string isin)
        {
            return ExecuteQueryAsync(string.Format(SearchUrl, isin, _apiToken), SearchAsync);
        }
        
        private async Task<List<SearchInstrument>> SearchAsync(HttpResponseMessage response)
        {
            return SearchInstrument.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
