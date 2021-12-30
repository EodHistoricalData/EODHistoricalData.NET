using Polly;
using System;
using System.Net;
using System.Net.Http;

namespace EODHistoricalData.NET
{
    internal class HttpApiClient : AuthentifiedClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        internal HttpApiClient(string apiToken, bool useProxy) : base(apiToken)
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

        protected delegate T QueryHandler<T>(HttpResponseMessage response);

        protected T ExecuteQuery<T>(string uri, QueryHandler<T> handler)
        {
            Polly.Retry.RetryPolicy<HttpResponseMessage> httpRetryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => r.StatusCode == (HttpStatusCode)429)
                .WaitAndRetry(new[]
                {
                    TimeSpan.FromSeconds(30),
                    TimeSpan.FromSeconds(60),
                    TimeSpan.FromSeconds(90)
                },
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    //included for debug to see what the response is
                });

            var response = httpRetryPolicy.ExecuteAndCapture(() => _httpClient.GetAsync(uri).Result);

            if (response.Outcome == OutcomeType.Successful)
            {
                if (response.Result.IsSuccessStatusCode)
                    return handler(response.Result);

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