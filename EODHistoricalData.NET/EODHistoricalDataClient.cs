using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    public class EODHistoricalDataClient : AuthentifiedClient, IDisposable
    {
        public const string DateFormat = "yyyy-MM-dd";

        public EODHistoricalDataClient(string api, bool useProxy = false) : base(api)
        {
            _useProxy = useProxy;
        }

        StockPriceDataClient _stockPriceDataClient;
        SplitDividendClient _splitDividendClient;
        OptionsDataClient _optionsClient;
        CalendarDataClient _calenderClient;
        FundamentalDataClient _fundamentalDataClient;
        ExchangesDataClient _exchangesDataClient;

        bool _useProxy = false;

        public List<HistoricalPrice> GetHistoricalPrices(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query prices.");

            if (_stockPriceDataClient == null)
                _stockPriceDataClient = new StockPriceDataClient(_apiToken, _useProxy);

            return _stockPriceDataClient.GetHistoricalPrices(symbol, startDate, endDate);
        }

        public RealTimePrice GetRealTimePrice(string symbol)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (_stockPriceDataClient == null)
                _stockPriceDataClient = new StockPriceDataClient(_apiToken, _useProxy);

            return _stockPriceDataClient.GetRealTimePrice(symbol);
        }

        public List<RealTimePrice> GetRealTimePrices(string[] symbols)
        {
            if (symbols == null)
                throw new ArgumentNullException("Symbols list is null. Cannot get realtime prices.");

            if (symbols.Length == 0)
                throw new ArgumentNullException("Symbols list is empty. Cannot get realtime prices.");

            if (symbols.Any(x => x == null))
                throw new ArgumentNullException("Symbols list contains null elements. Cannot get realtime prices.");

            if (_stockPriceDataClient == null)
                _stockPriceDataClient = new StockPriceDataClient(_apiToken, _useProxy);

            return _stockPriceDataClient.GetRealTimePrices(symbols);
        }

        public List<Dividend> GetDividends(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query dividends.");

            if (_splitDividendClient == null)
                _splitDividendClient = new SplitDividendClient(_apiToken, _useProxy);

            return _splitDividendClient.GetDividends(symbol, startDate, endDate);
        }

        public List<ShareSplit> GetShareSplits(string symbol, DateTime? startDate, DateTime? endDate)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query splits.");

            if (_splitDividendClient == null)
                _splitDividendClient = new SplitDividendClient(_apiToken, _useProxy);

            return _splitDividendClient.GetShareSplits(symbol, startDate, endDate);
        }


        public Options GetOptions(string symbol, DateTime? startDate, DateTime? endDate, DateTime? startTradeDate = null, DateTime? endTradeDate = null)
        {
            if (symbol == null)
                throw new ArgumentNullException("Symbol is null, cannot query options data.");

            if (_optionsClient == null)
                _optionsClient = new OptionsDataClient(_apiToken, _useProxy);

            return _optionsClient.GetOptions(symbol, startDate, endDate);
        }

        public Earnings GetEarnings(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calenderClient == null)
                _calenderClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calenderClient.GetEarnings(startDate, endDate, symbols);
        }

        public Task<Earnings> GetEarningsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calenderClient == null)
                _calenderClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calenderClient.GetEarningsAsync(startDate, endDate, symbols);
        }
        
        public Ipos GetIpos(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calenderClient == null)
                _calenderClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calenderClient.GetIpos(startDate, endDate, symbols);
        }

        public IncomingSplits GetIncomingSplits(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            if (_calenderClient == null)
                _calenderClient = new CalendarDataClient(_apiToken, _useProxy);

            return _calenderClient.GetIncomingSplits(startDate, endDate, symbols);
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
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return symbols.Select(x => _fundamentalDataClient.GetFundamentalStock(x)).ToList();
        }

        public async Task<IList<FundamentalStock>> GetFundamentalStockAsync(IList<string> symbols)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            var list = new List<FundamentalStock>();
            foreach (var symbol in symbols)
            {
                list.Add(await _fundamentalDataClient.GetFundamentalStockAsync(symbol));
            }
            
            return list;
        }
        
        public FundamentalFund GetFundamentalFund(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetFundamentalFund(symbol);
        }
        
        public Task<FundamentalFund> GetFundamentalFundAsync(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetFundamentalFundAsync(symbol);
        }
        
        public FundamentalETF GetFundamentalETF(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetFundamentalETF(symbol);
        }

        public Task<FundamentalETF> GetFundamentalETFAsync(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetFundamentalETFAsync(symbol);
        }
        
        public IndexComposition GetIndexComposition(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetIndexComposition(symbol);
        }

        public Task<IndexComposition> GetIndexCompositionAsync(string symbol)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetIndexCompositionAsync(symbol);
        }
        
        public List<Instrument> GetExchangeInstruments(string exchangeCode)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetExchangeInstruments(exchangeCode);
        }
        
        public Task<List<Instrument>> GetExchangeInstrumentsAsync(string exchangeCode)
        {
            if (_fundamentalDataClient == null)
                _fundamentalDataClient = new FundamentalDataClient(_apiToken, _useProxy);

            return _fundamentalDataClient.GetExchangeInstrumentsAsync(exchangeCode);
        }
        
        public List<Exchange> GetExchangeList()
        {
            if (_exchangesDataClient == null)
                _exchangesDataClient = new ExchangesDataClient(_apiToken, _useProxy);

            return _exchangesDataClient.GetExchanges();
        }
        
        public Task<List<Exchange>> GetExchangeListAsync()
        {
            if (_exchangesDataClient == null)
                _exchangesDataClient = new ExchangesDataClient(_apiToken, _useProxy);

            return _exchangesDataClient.GetExchangesAsync();
        }

        public void Dispose()
        {
            _stockPriceDataClient?.Dispose();
            _splitDividendClient?.Dispose();
            _optionsClient?.Dispose();
            _calenderClient?.Dispose();
            _fundamentalDataClient?.Dispose();
            _exchangesDataClient?.Dispose();
        }
    }
}
