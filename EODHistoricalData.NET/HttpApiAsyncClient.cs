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
            var retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(response => Utils.CheckStatus(response.StatusCode))
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(retryCount: Utils.MAX_HTTP_RETRIES,
                                   sleepDurationProvider: Utils.CalculateRetryInterval,
                                   onRetry: (exception, sleepDuration, attemptNumber, context) =>
                                   {
                                       //Console.WriteLine($"Too many requests. Retrying in {sleepDuration}. {attemptNumber} / {Utils.MAX_HTTP_RETRIES}");
                                   });

            var response = await retryPolicy.ExecuteAndCaptureAsync(() => _httpClient.GetAsync(uri));

            if (response.Outcome == OutcomeType.Successful)
            {
                if (response.Result.IsSuccessStatusCode)
                    return await handler(response.Result);

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