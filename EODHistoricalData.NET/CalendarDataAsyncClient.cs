using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class CalendarDataAsyncClient : HttpApiAsyncClient
    {
        internal CalendarDataAsyncClient(string apiToken, bool useProxy) : base(apiToken, useProxy) { }

        private const string EarningsUrl = @"https://eodhistoricaldata.com/api/calendar/earnings?api_token={0}&fmt=json{1}";
        private const string IposUrl = @"https://eodhistoricaldata.com/api/calendar/ipos?api_token={0}&fmt=json{1}";
        private const string SplitsUrl = @"https://eodhistoricaldata.com/api/calendar/splits?api_token={0}&fmt=json{1}";

        private static StringBuilder HandleParameters(DateTime? startDate, DateTime? endDate, string[] symbols)
        {
            var sb = new StringBuilder();
            if (startDate != null || endDate != null)
                sb.Append(Utils.GetDateParametersAsString(startDate, endDate, "&"));
            if (symbols != null && symbols.Length > 0)
                sb.Append($"&symbols={string.Join(",", symbols)}");
            return sb;
        }

        internal Task<Earnings> GetEarningsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            var sb = HandleParameters(startDate, endDate, symbols);
            return ExecuteQueryAsync(string.Format(EarningsUrl, _apiToken, sb), GetEarningsFromResponseAsync);
        }
        
        private async Task<Earnings> GetEarningsFromResponseAsync(HttpResponseMessage response)
        {
            return Earnings.FromJson(await response.Content.ReadAsStringAsync());
        }
        
        internal Task<Ipos> GetIposAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            var sb = HandleParameters(startDate, endDate, symbols);
            return ExecuteQueryAsync(string.Format(IposUrl, _apiToken, sb), GetIposFromResponseAsync);
        }

        private async Task<Ipos> GetIposFromResponseAsync(HttpResponseMessage response)
        {
            return Ipos.FromJson(await response.Content.ReadAsStringAsync());
        }

        internal Task<IncomingSplits> GetIncomingSplitsAsync(DateTime? startDate = null, DateTime? endDate = null, string[] symbols = null)
        {
            var sb = HandleParameters(startDate, endDate, symbols);
            return ExecuteQueryAsync(string.Format(SplitsUrl, _apiToken, sb), GetIncomingSplitsFromResponseAsync);
        }

        private async Task<IncomingSplits> GetIncomingSplitsFromResponseAsync(HttpResponseMessage response)
        {
            return IncomingSplits.FromJson(await response.Content.ReadAsStringAsync());
        }
    }
}
