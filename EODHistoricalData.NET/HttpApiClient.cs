using System.Net;
using System.Net.Http;

namespace EODHistoricalData.NET
{
    internal class HttpApiClient : AuthentifiedClient
    {
        protected HttpClient _httpClient;

        internal HttpApiClient(string apiToken, bool useProxy) : base(apiToken)
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            if (useProxy)
            {
                HttpClientHandler myHandler = new HttpClientHandler();
                myHandler.DefaultProxyCredentials = CredentialCache.DefaultCredentials;
                _httpClient = new HttpClient(myHandler);
            }
            else
                _httpClient = new HttpClient();
        }

        protected delegate T QueryHandler<T>(HttpResponseMessage response);

        protected T ExecuteQuery<T>(string uri, QueryHandler<T> handler)
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
                return handler(response);
            throw new HttpRequestException($"There was an error while executing the HTTP query. Reason: {response.ReasonPhrase}");
        }
    }
}
