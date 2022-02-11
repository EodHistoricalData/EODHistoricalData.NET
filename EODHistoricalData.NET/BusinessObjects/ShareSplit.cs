﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EODHistoricalData.NET;
//
//    var shareSplit = ShareSplit.FromJson(jsonString);

namespace EODHistoricalData.NET
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class BulkShareSplit : ShareSplit
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

    public partial class ShareSplit
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("split")]
        public string Split { get; set; }

        [JsonIgnore]
        public decimal BaseNumber { get; set; }

        [JsonIgnore]
        public decimal SplitFactor { get; set; }
    }

    public partial class ShareSplit
    {
        public static List<ShareSplit> FromJson(string json)
        {
            List<ShareSplit> splits = JsonConvert.DeserializeObject<List<ShareSplit>>(json, EODHistoricalData.NET.ConverterShareSplit.Settings);
            foreach (ShareSplit split in splits)
            {
                string[] factors = split.Split.Split('/');
                split.SplitFactor = decimal.Parse(factors[0], CultureInfo.InvariantCulture);
                split.BaseNumber = decimal.Parse(factors[1], CultureInfo.InvariantCulture);
            }
            return splits;
        }
    }

    public partial class BulkShareSplit
    {
        public static new List<BulkShareSplit> FromJson(string json)
        {
            List<BulkShareSplit> splits = JsonConvert.DeserializeObject<List<BulkShareSplit>>(json, EODHistoricalData.NET.ConverterShareSplit.Settings);
            foreach (BulkShareSplit split in splits)
            {
                string[] factors = split.Split.Split('/');
                split.SplitFactor = decimal.Parse(factors[0], CultureInfo.InvariantCulture);
                split.BaseNumber = decimal.Parse(factors[1], CultureInfo.InvariantCulture);
            }
            return splits;
        }
    }

    public static class SerializeShareSplit
    {
        public static string ToJson(this List<ShareSplit> self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterShareSplit.Settings);
    }

    public static class SerializeBulkShareSplit
    {
        public static string ToJson(this List<BulkShareSplit> self) => JsonConvert.SerializeObject(self, EODHistoricalData.NET.ConverterShareSplit.Settings);
    }

    internal static class ConverterShareSplit
    {
        public static List<string> Errors = new List<string>();
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal },
                new NullConverter(),
            },
            Error = delegate (object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
            {
                Errors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            },
        };
    }
}
