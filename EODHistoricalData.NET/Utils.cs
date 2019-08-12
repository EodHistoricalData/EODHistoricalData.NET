using System;
using System.Collections.Generic;
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
            StringBuilder sb = new StringBuilder();
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
    }
}
