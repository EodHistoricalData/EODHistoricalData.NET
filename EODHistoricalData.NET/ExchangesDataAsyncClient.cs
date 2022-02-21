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
        private const string ExchangeBulkPricesUrl = @"https://eodhistoricaldata.com/api/eod-bulk-last-day/{0}?api_token={1}&fmt=json{2}{3}";
        private const string ExchangeBulkDividendsUrl = @"https://eodhistoricaldata.com/api/eod-bulk-last-day/{0}?api_token={1}&type=dividends&fmt=json{2}{3}";
        private const string ExchangeBulkSplitsUrl = @"https://eodhistoricaldata.com/api/eod-bulk-last-day/{0}?api_token={1}&type=splits&fmt=json{2}{3}";

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

        internal Task<List<ExchangeBulkPrice>> GetExchangeBulkPricesAsync(string exchange, DateTime? date, params string[] symbols)
        {
            var dateParameter = Utils.GetDateParameterAsString(date);
            var symbolsParameter = GetSymbolsQueryParameter(symbols);
            return ExecuteQueryAsync(string.Format(ExchangeBulkPricesUrl, exchange, _apiToken, dateParameter, symbolsParameter), GetExchangeBulkPricesFromResponseAsync);
        }

        private async Task<List<ExchangeBulkPrice>> GetExchangeBulkPricesFromResponseAsync(HttpResponseMessage response)
        {
            return ExchangeBulkPrice.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<List<ExchangeBulkDividend>> GetExchangeBulkDividendsAsync(string exchange, DateTime? date, params string[] symbols)
        {
            var dateParameter = Utils.GetDateParameterAsString(date);
            var symbolsParameter = GetSymbolsQueryParameter(symbols);
            return ExecuteQueryAsync(string.Format(ExchangeBulkDividendsUrl, exchange, _apiToken, dateParameter, symbolsParameter), GetExchangeBulkDividendsFromResponseAsync);
        }

        private async Task<List<ExchangeBulkDividend>> GetExchangeBulkDividendsFromResponseAsync(HttpResponseMessage response)
        {
            return ExchangeBulkDividend.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<List<ExchangeBulkSplit>> GetExchangeBulkSplitsAsync(string exchange, DateTime? date, params string[] symbols)
        {
            var dateParameter = Utils.GetDateParameterAsString(date);
            var symbolsParameter = GetSymbolsQueryParameter(symbols);
            return ExecuteQueryAsync(string.Format(ExchangeBulkSplitsUrl, exchange, _apiToken, dateParameter, symbolsParameter), GetExchangeBulkSplitsFromResponseAsync);
        }

        private async Task<List<ExchangeBulkSplit>> GetExchangeBulkSplitsFromResponseAsync(HttpResponseMessage response)
        {
            return ExchangeBulkSplit.FromJson(await response.Content.ReadAsStringAsync());
        }

        private string GetSymbolsQueryParameter(string[] symbols)
        {
            if (symbols.Length > 0) {
                var joinedSymbols = string.Join(",", symbols);
                return $"&symbols={joinedSymbols}";
            }

            return string.Empty;
        }
    }
}
