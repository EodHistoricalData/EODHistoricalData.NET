using Newtonsoft.Json;

namespace EODHistoricalData.NET.BusinessObjects
{
    public class FundamentalTechnicals
    {
        [JsonProperty("Beta")]
        public decimal? Beta { get; set; }

        [JsonProperty("52WeekHigh")]
        public decimal? The52WeekHigh { get; set; }

        [JsonProperty("52WeekLow")]
        public decimal? The52WeekLow { get; set; }

        [JsonProperty("50DayMA")]
        public decimal? The50DayMa { get; set; }

        [JsonProperty("200DayMA")]
        public decimal? The200DayMa { get; set; }

        [JsonProperty("SharesShort")]
        public decimal? SharesShort { get; set; }

        [JsonProperty("SharesShortPriorMonth")]
        public decimal? SharesShortPriorMonth { get; set; }

        [JsonProperty("ShortRatio")]
        public decimal? ShortRatio { get; set; }

        [JsonProperty("ShortPercent")]
        public decimal? ShortPercent { get; set; }
    }
}
