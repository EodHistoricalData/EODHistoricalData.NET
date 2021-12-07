using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class FundamentalDataAsyncClient : HttpApiAsyncClient
    {
        private const string FundamentalUrl = @"https://eodhistoricaldata.com/api/fundamentals/{0}?api_token={1}";
        private const string ExchangeUrl = @"https://eodhistoricaldata.com/api/exchanges/{0}?api_token={1}&fmt=json";

        internal FundamentalDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal Task<FundamentalStock> GetFundamentalStockAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponseAsync);
        }
        
        private async Task<FundamentalStock> GetFundamentalStockFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<FundamentalETF> GetFundamentalETFAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalETFFromResponseAsync);
        }

        private async Task<FundamentalETF> GetFundamentalETFFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalETF.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<FundamentalFund> GetFundamentalFundAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalFundFromResponseAsync);
        }

        private async Task<FundamentalFund> GetFundamentalFundFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalFund.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<IndexComposition> GetIndexCompositionAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetIndexCompositionFromResponseAsync);
        }

        private async Task<IndexComposition> GetIndexCompositionFromResponseAsync(HttpResponseMessage response)
        {
            return IndexComposition.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal Task<List<Instrument>> GetExchangeInstrumentsAsync(string exchangeCode)
        {
            return ExecuteQueryAsync(string.Format(ExchangeUrl, exchangeCode, _apiToken), GetExchangeInstrumentsFromResponseAsync);
        }

        private async Task<List<Instrument>> GetExchangeInstrumentsFromResponseAsync(HttpResponseMessage response)
        {
            return Instrument.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
