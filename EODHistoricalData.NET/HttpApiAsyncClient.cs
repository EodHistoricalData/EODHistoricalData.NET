using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace EODHistoricalData.NET
{
    internal class HttpApiAsyncClient : AuthentifiedClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        internal HttpApiAsyncClient(string apiToken, bool useProxy) : base(apiToken)
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            if (useProxy)
            {
                var myHandler = new HttpClientHandler
                {
                    DefaultProxyCredentials = CredentialCache.DefaultCredentials
                };

                _httpClient = new HttpClient(myHandler);
            }
            else
                _httpClient = new HttpClient();
        }

        protected async Task<T> ExecuteQueryAsync<T>(string uri, Func<HttpResponseMessage, Task<T>> handler)
        {
            Polly.Retry.AsyncRetryPolicy<HttpResponseMessage> httpRetryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => r.StatusCode == (HttpStatusCode)429)
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(60),
                    TimeSpan.FromSeconds(90)
                },
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    //included for debug to see what the response is
                });

            var response = await httpRetryPolicy.ExecuteAndCaptureAsync(() => _httpClient.GetAsync(uri));

            if (response.Outcome == OutcomeType.Successful)
            {
                if (response.Result.IsSuccessStatusCode)
                    return await handler(response.Result);

                throw new HttpRequestException($"There was an error while executing the HTTP query. Reason: {response.Result.ReasonPhrase}");
            }
            else
            {
                var reason = response.FinalHandledResult != null ? response.FinalHandledResult.ReasonPhrase : response.FinalException.Message;
                throw new HttpRequestException($"There was an error while executing the HTTP query. Reason: {reason}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}