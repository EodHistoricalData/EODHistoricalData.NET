using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class FundamentalDataClient : HttpApiClient
    {
        const string FundamentalUrl = @"https://eodhistoricaldata.com/api/fundamentals/{0}?api_token={1}";
        const string ExchangeUrl = @"https://eodhistoricaldata.com/api/exchanges/{0}?api_token={1}&fmt=json";

        internal FundamentalDataClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal FundamentalStock GetFundamentalStock(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponse);
        }

        private FundamentalStock GetFundamentalStockFromResponse(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal Task<FundamentalStock> GetFundamentalStockAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponseAsync);
        }
        
        private async Task<FundamentalStock> GetFundamentalStockFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal FundamentalETF GetFundamentalETF(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalETFFromResponse);
        }

        private FundamentalETF GetFundamentalETFFromResponse(HttpResponseMessage response)
        {
            return FundamentalETF.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal Task<FundamentalETF> GetFundamentalETFAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalETFFromResponseAsync);
        }

        private async Task<FundamentalETF> GetFundamentalETFFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalETF.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal FundamentalFund GetFundamentalFund(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalFundFromResponse);
        }

        private FundamentalFund GetFundamentalFundFromResponse(HttpResponseMessage response)
        {
            return FundamentalFund.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal Task<FundamentalFund> GetFundamentalFundAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalFundFromResponseAsync);
        }

        private async Task<FundamentalFund> GetFundamentalFundFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalFund.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal IndexComposition GetIndexComposition(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetIndexCompositionFromResponse);
        }

        private IndexComposition GetIndexCompositionFromResponse(HttpResponseMessage response)
        {
            return IndexComposition.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal Task<IndexComposition> GetIndexCompositionAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetIndexCompositionFromResponseAsync);
        }

        private async Task<IndexComposition> GetIndexCompositionFromResponseAsync(HttpResponseMessage response)
        {
            return IndexComposition.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal List<Instrument> GetExchangeInstruments(string exchangeCode)
        {
            return ExecuteQuery(string.Format(ExchangeUrl, exchangeCode, _apiToken), GetExchangeInstrumentsFromResponse);
        }

        private List<Instrument> GetExchangeInstrumentsFromResponse(HttpResponseMessage response)
        {
            return Instrument.FromJson(response.Content.ReadAsStringAsync().Result);
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
