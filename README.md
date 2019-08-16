# EODHistoricalData.NET


EODHistoricalData.NET is an easy-to-use .NET wrapper for EODHistoricalData REST API written in C#.

## Getting Started
EODHistoricalData.NET is a stand-alone .NET project.
You can download the sources and add it as a project if you think you will need Debug possibilities.
Or you can download the binary from the Release folder and add it as a file reference.

## Usage

### Instantiation
Usage of a wrapper can't be more easy.
You instantiate the EODHistoricalDataClient object, which is a Facade pattern, using your API token and you're good to go : 

    EODHistoricalDataClient client = new EODHistoricalDataClient(Consts.ApiToken, true);

The boolean parameter, which is optional, is the use of system-defined proxy.
Specific full proxy configuration is not supported yet.

### Api calls
Then you just have to call the API you want, which returns the response in the corresponding structure.
Here are a few examples : 

    List<HistoricalPrice> prices = client.GetHistoricalPrices(Consts.TestSymbol, Consts.StartDate, Consts.EndDate);

    List<RealTimePrice> prices = client.GetRealTimePrices(Consts.MultipleTestSymbol);

Each method as its own set of parameters corresponding of the REST API parameters.

For an exhaustive list of possible calls, you can check the units tests in the folder EODHistoricalData.NET.Tests folder.

## Authors

### Fred Blot  : initial work
Autoquant (https://www.autoquant.fr)
going-striker (https://github.com/going-striker)

### EODHistoricalData
https://eodhistoricaldata.com/