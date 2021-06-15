using Newtonsoft.Json;
using System;

namespace EODHistoricalData.NET
{
    public class NullConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(double)) || (objectType == typeof(long));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(double))
            {
                if (reader.TokenType == JsonToken.Float) return reader.Value;
                if (reader.TokenType == JsonToken.Integer) return Convert.ToDouble(reader.Value);
                if (reader.TokenType == JsonToken.Null) return double.NaN;
            }

            if (objectType == typeof(long))
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
