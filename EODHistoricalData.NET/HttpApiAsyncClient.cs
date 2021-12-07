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
                var myHandler = new HttpClientHandler();
                myHandler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;
                _httpClient = new HttpClient(myHandler);
            }
            else
                _httpClient = new HttpClient();
        }

        protected delegate T QueryHandler<T>(HttpResponseMessage response);
        
        protected async Task<T> ExecuteQueryAsync<T>(string uri, Func<HttpResponseMessage, Task<T>> handler)
        {
            var response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
                return await handler(response);
            throw new HttpRequestException($"There was an error while executing the HTTP query. Reason: {response.ReasonPhrase}");
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
