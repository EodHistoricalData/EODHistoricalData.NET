using System;
using System.Text;

namespace EODHistoricalData.NET
{
    internal static class Utils
    {
        internal static string GetDateParametersAsString(DateTime? startDate, DateTime? endDate, string additional = null)
        {
            return GetDateParametersAsString(startDate, endDate, "from", "to", additional);
        }

        internal static string GetDateParametersAsString(DateTime? startDate, DateTime? endDate, string fromField, string toField, string additional = null)
        {
            var sb = new StringBuilder();
            if (additional != null)
                sb.Append(additional);
            if (startDate.HasValue)
                sb.Append($"{fromField}={startDate.Value.ToString(EODHistoricalDataClient.DateFormat)}");
            if (endDate.HasValue)
            {
                if (startDate.HasValue)
                    sb.Append("&");
                sb.Append($"{toField}={endDate.Value.ToString(EODHistoricalDataClient.DateFormat)}");
            }

            return sb.ToString();
        }

        internal static string GetDateParameterAsString(DateTime? date, string dateField = "date")
        {
            if (date.HasValue)
              return $"&{dateField}={date.Value.ToString(EODHistoricalDataClient.DateFormat)}";

            return string.Empty;
        }
    }
}
