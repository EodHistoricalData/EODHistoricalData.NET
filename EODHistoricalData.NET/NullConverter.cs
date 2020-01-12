using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EODHistoricalData.NET
{
    public class NullConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(System.Double)) || (objectType == typeof(System.Int64));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(System.Double))
            {
                if (reader.TokenType == JsonToken.Float) return reader.Value;
                if (reader.TokenType == JsonToken.Integer) return Convert.ToDouble(reader.Value);
                if (reader.TokenType == JsonToken.Null) return Double.NaN;
            }

            if (objectType == typeof(System.Int64))
            {
                if (reader.TokenType == JsonToken.Integer) return Convert.ToInt64(reader.Value);
                if (reader.TokenType == JsonToken.Null) return (long)0;
            }

            return null;
        }

        public override bool CanWrite { get { return false; } }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
