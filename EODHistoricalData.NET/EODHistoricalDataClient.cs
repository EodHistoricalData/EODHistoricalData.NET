using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EODHistoricalData.NET
{
    public class EODHistoricalDataClient : AuthentifiedClient
    {
        public const string DateFormat = "yyyy-MM-dd";

        public EODHistoricalDataClient(string api, bool useProxy = false) : base(api)
        {
            _useProxy = useProxy;
        }

        StockPriceDataClient _stockPriceDataClient;
        SplitDividendClient _splitDividendClient;
        OptionsDataClient _optionsClient;

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
    }
}
