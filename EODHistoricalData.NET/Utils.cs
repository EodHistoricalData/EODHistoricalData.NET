using System;
using System.Net;
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

        internal static int MAX_HTTP_RETRIES = 3;

        internal static bool CheckStatus(HttpStatusCode status)
        {
            return status == (HttpStatusCode)429;
        }

        internal static TimeSpan CalculateRetryInterval(int attempt)
        {
            //try to make this the second half of the minute
            //as this is likely to fail in the first part of the minute
            return TimeSpan.FromSeconds(attempt * 30 + (30 * (attempt - 1)));
        }
    }
}
