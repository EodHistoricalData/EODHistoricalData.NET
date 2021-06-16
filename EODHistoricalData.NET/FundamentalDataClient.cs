using System.Collections.Generic;
using System.Net.Http;

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
