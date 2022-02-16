using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    public class EODHistoricalDataAsyncClient : AuthentifiedClient, IDisposable
    {
        public const string DateFormat = "yyyy-MM-dd";

        public EODHistoricalDataAsyncClient(string api, bool useProxy = false) : base(api)
        {
            _useProxy = useProxy;
        }

        private StockPriceDataAsyncClient _stockPriceDataAsyncClient;
        private SplitDividendAsyncClient _splitDividendAsyncClient;
        private OptionsDataAsyncClient _optionsDataAsyncClient;
        private CalendarDataAsyncClient _calendarDataAsyncClient;
        private FundamentalDataAsyncClient _fundamentalDataAsyncClient;
        private ExchangesDataAsyncClient _exchangesDataAsyncClient;
        private SearchAsyncClient _searchAsyncClient;

        private readonly bool _useProxy;

        public Task<List<HistoricalPrice>> GetHistoricalPricesAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetHistoricalPricesAsync(symbol, startDate, endDate);
        }

        /// <summary>
        /// Obtain historical intraday prices for the given symbol
        /// </summary>
        /// <param name="symbol">Symbol to obtain</param>
        /// <param name="interval">Interval for intraday prices. Can be one of 1m, 5m, 1h</param>
        /// <param name="startDate">Start date for range to obtain. Must be of kind UTC</param>
        /// <param name="endDate">End date for range to obtain. Must be of kind UTC</param>
        /// <returns>Historical intray prices for specified parameters</returns>
        /// <exception cref="ArgumentNullException">Will be thrown when invalid parameters are passed</exception>
        /// <exception cref="Exception">Will be thrown when invalid parameters are passed</exception>
        public Task<List<HistoricalIntradayPrice>> GetHistoricalIntradayPricesAsync(string symbol, string interval, DateTime startDate, DateTime endDate) {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query prices.");
            if (startDate.Kind != DateTimeKind.Utc)
                throw new Exception("Start date is not of UTC kind.");
            if (startDate.Kind != DateTimeKind.Utc)
                throw new Exception("End date is not of UTC kind.");
            if (endDate < startDate)
                throw new Exception("End date needs to be greater than start date");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetHistoricalIntradayPricesAsync(symbol, interval, startDate, endDate);
        }

        public Task<RealTimePrice> GetRealTimePriceAsync(string symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetRealTimePriceAsync(symbol);
        }

        public Task<List<RealTimePrice>> GetRealTimePricesAsync(string[] symbols)
        {
            if (symbols == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (symbols.Length == 0)
                throw new ArgumentNullException("Symbols list is empty. Cannot get realtime prices.");

            if (symbols.Any(x => x == null))
                throw new ArgumentNullException("Symbols list contains null elements. Cannot get realtime prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetRealTimePricesAsync(symbols);
        }

        public Task<List<Dividend>> GetDividendsAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query dividends.");

            if (_splitDividendAsyncClient == null)
                _splitDividendAsyncClient = new SplitDividendAsyncClient(_apiToken, _useProxy);

            return _splitDividendAsyncClient.GetDividendsAsync(symbol, startDate, endDate);
        }

        public Task<List<ShareSplit>> GetShareSplitsAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query splits.");

            if (_splitDividendAsyncClient == null)
                _splitDividendAsyncClient = new SplitDividendAsyncClient(_apiToken, _useProxy);

            return _splitDividendAsyncClient.GetShareSplitsAsync(symbol, startDate, endDate);
        }


        public Task<Options> GetOptionsAsync(string symbol, DateTime? startDate, DateTime? endDate, DateTime? startTradeDate = null, DateTime? endTradeDate = null)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query options data.");

            if (_optionsDataAsyncClient == null)
                _optionsDataAsyncClient = new OptionsDataAsyncClient(_apiToken, _useProxy);

            return _optionsDataAsyncClient.GetOptionsAsync(symbol, startDate, endDate);
        }

        public Task<Earnings> GetEarningsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataAsyncClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetEarningsAsync(startDate, endDate, symbols);
        }
        
        public Task<Ipos> GetIposAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataAsyncClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetIposAsync(startDate, endDate, symbols);
        }

        public Task<IncomingSplits> GetIncomingSplitsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataAsyncClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetIncomingSplitsAsync(startDate, endDate, symbols);
        }

        public async Task<FundamentalStock> GetFundamentalStockAsync(string symbol)
        {
            var results = await GetFundamentalStockAsync((new[] { symbol }).ToList());
            return results.FirstOrDefault();
        }
        
        public async Task<IList<FundamentalStock>> GetFundamentalStockAsync(IList<string> symbols)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);

            var list = new List<FundamentalStock>();
            foreach (var symbol in symbols)
            {
                list.Add(await _fundamentalDataAsyncClient.GetFundamentalStockAsync(symbol));
            }
            
            return list;
        }
        
        /// <summary>
        /// To get an access to bulk fundamentals API,
        /// you should subscribe to ‘Extended Fundamentals’ package,
        /// more details we will provide by request: support@eodhistoricaldata.com.
        /// 
        /// It doesn’t work for entire US exchange,
        /// instead of it you should request each exchange separately,
        /// at the moment we do support:
        /// NASDAQ, NYSE (or ‘NYSE MKT’), BATS, and AMEX.
        /// All non-US exchanges supported as is.
        ///
        /// By default offset = 0 and limit = 1000
        /// </summary>
        /// <param name="exchange">The exchange code</param>
        /// <param name="offset">The number of records to skip</param>
        /// <param name="limit">If the ‘limit’ parameter is bigger than 1000, it will be reset to 1000.</param>
        /// <returns></returns>
        public async Task<IEnumerable<FundamentalStock>> GetBulkFundamentalStocksAsync(string exchange, int offset = 0, int limit = 1000)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);
            var results = await _fundamentalDataAsyncClient.GetBulkFundamentalsStocksAsync(exchange, offset, limit);
            return results?.Values;
        }
        
        public Task<FundamentalFund> GetFundamentalFundAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalFundAsync(symbol);
        }

        public Task<FundamentalETF> GetFundamentalETFAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalETFAsync(symbol);
        }

        public Task<IndexComposition> GetIndexCompositionAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetIndexCompositionAsync(symbol);
        }
        
        public Task<List<Instrument>> GetExchangeInstrumentsAsync(string exchangeCode)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataAsyncClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetExchangeInstrumentsAsync(exchangeCode);
        }
        
        public Task<List<Exchange>> GetExchangeListAsync()
        {
            if (_exchangesDataAsyncClient == null)
                _exchangesDataAsyncClient = new ExchangesDataAsyncClient(_apiToken, _useProxy);

            return _exchangesDataAsyncClient.GetExchangesAsync();
        }

        public Task<ExchangeDetails> GetExchangeDetailsAsync(string exchange, DateTime? startDate, DateTime? endDate)
        {
            if (string.IsNullOrEmpty(exchange))
                throw new ArgumentException("Exchange is null or empty, cannot query exchange details.");

            if (_exchangesDataAsyncClient == null)
                _exchangesDataAsyncClient = new ExchangesDataAsyncClient(_apiToken, _useProxy);

            return _exchangesDataAsyncClient.GetExchangeDetailsAsync(exchange, startDate, endDate);
        }

        public Task<List<SearchInstrument>> SearchAsync(string isin)
        {
            _searchAsyncClient ??= new SearchAsyncClient(_apiToken, _useProxy);

            return _searchAsyncClient.SearchAsync(isin);
        }
        
        public void Dispose()
        {
            _stockPriceDataAsyncClient?.Dispose();
            _splitDividendAsyncClient?.Dispose();
            _optionsDataAsyncClient?.Dispose();
            _calendarDataAsyncClient?.Dispose();
            _fundamentalDataAsyncClient?.Dispose();
            _exchangesDataAsyncClient?.Dispose();
            _searchAsyncClient?.Dispose();
        }
    }
}
