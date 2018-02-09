using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.TestFramework.Environment
{
    public class Client
    {
        private HttpClient _httpClient;

        public Client(Uri baseAddress)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = baseAddress
            };
        }

        public ClientResponse Request(string endpoint, ClientMethod method = ClientMethod.GET, ByteArrayContent content = null)
        {
            Task<HttpResponseMessage> httpResponse = null;
            switch (method)
            {
                case ClientMethod.GET:
                    httpResponse = _httpClient.GetAsync(endpoint);
                    break;
                case ClientMethod.POST:
                    httpResponse = _httpClient.PostAsync(endpoint, content);
                    break;
                case ClientMethod.PUT:
                    httpResponse = _httpClient.PutAsync(endpoint, content);
                    break;
                case ClientMethod.DELETE:
                    httpResponse = _httpClient.DeleteAsync(endpoint);
                    break;
            }

            return new ClientResponse(httpResponse);
        }
    }
}
