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

        StockPriceDataAsyncClient _stockPriceDataAsyncClient;
        SplitDividendAsyncClient _splitDividendAsyncClient;
        OptionsDataAsyncClient _optionsDataAsyncClient;
        CalendarDataAsyncClient _calendarDataAsyncClient;
        FundamentalDataAsyncClient _fundamentalDataAsyncClient;
        ExchangesDataAsyncClient _exchangesDataAsyncClient;

        bool _useProxy = false;

        public List<HistoricalPrice> GetHistoricalPrices(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetHistoricalPrices(symbol, startDate, endDate);
        }

        public RealTimePrice GetRealTimePrice(string symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetRealTimePrice(symbol);
        }

        public List<RealTimePrice> GetRealTimePrices(string[] symbols)
        {
            if (symbols == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (symbols.Length == 0)
                throw new ArgumentNullException("Symbols list is empty. Cannot get realtime prices.");

            if (symbols.Any(x => x == null))
                throw new ArgumentNullException("Symbols list contains null elements. Cannot get realtime prices.");

            if (_stockPriceDataAsyncClient == null)
                _stockPriceDataAsyncClient = new StockPriceDataAsyncClient(_apiToken, _useProxy);

            return _stockPriceDataAsyncClient.GetRealTimePrices(symbols);
        }

        public List<Dividend> GetDividends(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query dividends.");

            if (_splitDividendAsyncClient == null)
                _splitDividendAsyncClient = new SplitDividendAsyncClient(_apiToken, _useProxy);

            return _splitDividendAsyncClient.GetDividends(symbol, startDate, endDate);
        }

        public List<ShareSplit> GetShareSplits(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query splits.");

            if (_splitDividendAsyncClient == null)
                _splitDividendAsyncClient = new SplitDividendAsyncClient(_apiToken, _useProxy);

            return _splitDividendAsyncClient.GetShareSplits(symbol, startDate, endDate);
        }


        public Options GetOptions(string symbol, DateTime? startDate, DateTime? endDate, DateTime? startTradeDate = null, DateTime? endTradeDate = null)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query options data.");

            if (_optionsDataAsyncClient == null)
                _optionsDataAsyncClient = new OptionsDataAsyncClient(_apiToken, _useProxy);

            return _optionsDataAsyncClient.GetOptions(symbol, startDate, endDate);
        }

        public Earnings GetEarnings(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataAsyncClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetEarnings(startDate, endDate, symbols);
        }

        public Task<Earnings> GetEarningsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetEarningsAsync(startDate, endDate, symbols);
        }
        
        public Ipos GetIpos(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetIpos(startDate, endDate, symbols);
        }

        public IncomingSplits GetIncomingSplits(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calendarDataAsyncClient == null)
                _calendarDataAsyncClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calendarDataAsyncClient.GetIncomingSplits(startDate, endDate, symbols);
        }

        public FundamentalStock GetFundamentalStock(string symbol)
        {
            return GetFundamentalStock((new[] { symbol }).ToList()).FirstOrDefault();
        }

        public async Task<FundamentalStock> GetFundamentalStockAsync(string symbol)
        {
            var results = await GetFundamentalStockAsync((new[] { symbol }).ToList());
            return results.FirstOrDefault();
        }
        
        public IList<FundamentalStock> GetFundamentalStock(IList<string> symbols)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return symbols.Select(x => _fundamentalDataAsyncClient.GetFundamentalStock(x)).ToList();
        }

        public async Task<IList<FundamentalStock>> GetFundamentalStockAsync(IList<string> symbols)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            var list = new List<FundamentalStock>();
            foreach (var symbol in symbols)
            {
                list.Add(await _fundamentalDataAsyncClient.GetFundamentalStockAsync(symbol));
            }
            
            return list;
        }
        
        public FundamentalFund GetFundamentalFund(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalFund(symbol);
        }
        
        public Task<FundamentalFund> GetFundamentalFundAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalFundAsync(symbol);
        }
        
        public FundamentalETF GetFundamentalETF(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalETF(symbol);
        }

        public Task<FundamentalETF> GetFundamentalETFAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetFundamentalETFAsync(symbol);
        }
        
        public IndexComposition GetIndexComposition(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetIndexComposition(symbol);
        }

        public Task<IndexComposition> GetIndexCompositionAsync(string symbol)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetIndexCompositionAsync(symbol);
        }
        
        public List<Instrument> GetExchangeInstruments(string exchangeCode)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetExchangeInstruments(exchangeCode);
        }
        
        public Task<List<Instrument>> GetExchangeInstrumentsAsync(string exchangeCode)
        {
            if (_fundamentalDataAsyncClient == null)
                _fundamentalDataAsyncClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataAsyncClient.GetExchangeInstrumentsAsync(exchangeCode);
        }
        
        public List<Exchange> GetExchangeList()
        {
            if (_exchangesDataAsyncClient == null)
                _exchangesDataAsyncClient = new ExchangesDataClient(_apiToken, _useProxy);

            return _exchangesDataAsyncClient.GetExchanges();
        }
        
        public Task<List<Exchange>> GetExchangeListAsync()
        {
            if (_exchangesDataAsyncClient == null)
                _exchangesDataAsyncClient = new ExchangesDataClient(_apiToken, _useProxy);

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
