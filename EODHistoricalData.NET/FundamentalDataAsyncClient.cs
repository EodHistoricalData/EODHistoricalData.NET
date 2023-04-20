using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class FundamentalDataAsyncClient : HttpApiAsyncClient
    {
        private const string FundamentalUrl = @"https://eodhistoricaldata.com/api/fundamentals/{0}?api_token={1}";
        private const string ExchangeUrl = @"https://eodhistoricaldata.com/api/exchanges/{0}?api_token={1}&fmt=json";
        private const string BulkFundamentalUrl = @"https://eodhistoricaldata.com/api/bulk-fundamentals/{0}?api_token={1}&offset={2}&limit={3}&fmt=json";

        internal FundamentalDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal Task<FundamentalStock> GetFundamentalStockAsync(string symbol)
        {
            return ExecuteQueryAsync(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponseAsync);
        }
        
        private async Task<FundamentalStock> GetFundamentalStockFromResponseAsync(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<BulkFundamentalStocks> GetBulkFundamentalsStocksAsync(string exchange, int offset, int limit)
        {
            // https://eodhistoricaldata.com/financial-apis/stock-etfs-fundamental-data-feeds/#Bulk_Fundamentals_API
            // If the ‘limit’ parameter is bigger than 500, it will be reset to 500.
            limit = limit > 500
                ? 500
                : limit;
            
            return ExecuteQueryAsync(string.Format(BulkFundamentalUrl, exchange, _apiToken, offset, limit), GetBulkFundamentalStocksFromResponseAsync);
        }

        private async Task<BulkFundamentalStocks> GetBulkFundamentalStocksFromResponseAsync(HttpResponseMessage response)
        {
            return BulkFundamentalStocks.FromJson(await response.Content.ReadAsStringAsync());
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
