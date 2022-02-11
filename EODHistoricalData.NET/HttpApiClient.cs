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

            _httpClient.Timeout = TimeSpan.FromSeconds(250);
        }

        protected delegate T QueryHandler<T>(HttpResponseMessage response);

        protected T ExecuteQuery<T>(string uri, QueryHandler<T> handler)
        {
            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(response => Utils.CheckStatus(response.StatusCode))
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(retryCount: Utils.MAX_HTTP_RETRIES,
                                   sleepDurationProvider: Utils.CalculateRetryInterval,
                                   onRetry: (exception, sleepDuration, attemptNumber, context) =>
                                   {
                                       //Console.WriteLine($"Too many requests. Retrying in {sleepDuration}. {attemptNumber} / {Utils.MAX_HTTP_RETRIES}");
                                   });

            var response = retryPolicy.ExecuteAndCaptureAsync(() => _httpClient.GetAsync(uri)).Result;

            if (response.Outcome == OutcomeType.Successful)
            {
                if (response.Result.IsSuccessStatusCode)
                    return handler(response.Result);

                throw new HttpRequestException($"There was an error while executing the HTTP query.",
                    new BusinessObjects.EODException(response.Result.StatusCode, response.Result.ReasonPhrase, response.Result.ToString()));
            }
            else
            {
                var reason = response.FinalHandledResult != null ? response.FinalHandledResult.ReasonPhrase : response.FinalException.Message;
                throw new HttpRequestException($"The HTTP query failed. Reason: {reason}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}