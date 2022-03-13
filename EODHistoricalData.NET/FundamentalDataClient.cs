using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class FundamentalDataClient : HttpApiClient
    {
        private const string FundamentalUrl = @"https://eodhistoricaldata.com/api/fundamentals/{0}?api_token={1}&fmt=json";
        private const string ExchangeUrl = @"https://eodhistoricaldata.com/api/exchanges/{0}?api_token={1}&fmt=json";
        private const string BulkFundamentalUrl = @"https://eodhistoricaldata.com/api/bulk-fundamentals/{0}?api_token={1}&offset={2}&limit={3}&fmt=json";
        
        internal FundamentalDataClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        internal FundamentalStock GetFundamentalStock(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalStockFromResponse);
        }

        private FundamentalStock GetFundamentalStockFromResponse(HttpResponseMessage response)
        {
            return FundamentalStock.FromJson(response.Content.ReadAsStringAsync().Result);
        }

        internal BulkFundamentalStocks GetBulkFundamentalsStocks(string exchange, int offset, int limit)
        {
            // https://eodhistoricaldata.com/financial-apis/stock-etfs-fundamental-data-feeds/#Bulk_Fundamentals_API
            // If the ‘limit’ parameter is bigger than 500, it will be reset to 500.
            if (limit > 500)
            {
                limit = 500;
            }
            return ExecuteQuery(string.Format(BulkFundamentalUrl, exchange, _apiToken, offset, limit), GetBulkFundamentalStocksFromResponse);
        }

        private BulkFundamentalStocks GetBulkFundamentalStocksFromResponse(HttpResponseMessage response)
        {
            return BulkFundamentalStocks.FromJson(response.Content.ReadAsStringAsync().Result);
        }
        
        internal FundamentalETF GetFundamentalETF(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalETFFromResponse);
        }

        private FundamentalETF GetFundamentalETFFromResponse(HttpResponseMessage response)
        {
            return FundamentalETF.FromJson(response.Content.ReadAsStringAsync().Result);
        }
        
        internal FundamentalFund GetFundamentalFund(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetFundamentalFundFromResponse);
        }

        private FundamentalFund GetFundamentalFundFromResponse(HttpResponseMessage response)
        {
            return FundamentalFund.FromJson(response.Content.ReadAsStringAsync().Result);
        }
        
        internal IndexComposition GetIndexComposition(string symbol)
        {
            return ExecuteQuery(string.Format(FundamentalUrl, symbol, _apiToken), GetIndexCompositionFromResponse);
        }

        private IndexComposition GetIndexCompositionFromResponse(HttpResponseMessage response)
        {
            return IndexComposition.FromJson(response.Content.ReadAsStringAsync().Result);
        }
        
        internal List<Instrument> GetExchangeInstruments(string exchangeCode)
        {
            return ExecuteQuery(string.Format(ExchangeUrl, exchangeCode, _apiToken), GetExchangeInstrumentsFromResponse);
        }

        private List<Instrument> GetExchangeInstrumentsFromResponse(HttpResponseMessage response)
        {
            return Instrument.FromJson(response.Content.ReadAsStringAsync().Result);
        }
    }
}
