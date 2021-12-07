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

        private readonly bool _useProxy;

        public Task<List<HistoricalPrice>> GetHistoricalPricesAsync(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetHistoricalPricesAsync(symbol, startDate, endDate);
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

            return _optionsDataAsyncClient.GetOptions(symbol, startDate, endDate);
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

        public void Dispose()
        {
            _stockPriceDataAsyncClient?.Dispose();
            _splitDividendAsyncClient?.Dispose();
            _optionsDataAsyncClient?.Dispose();
            _calendarDataAsyncClient?.Dispose();
            _fundamentalDataAsyncClient?.Dispose();
            _exchangesDataAsyncClient?.Dispose();
        }
    }
}
