using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.TestFramework.Environment
{
    public class Client
    {
        public Method Method { get; set; }
        public ByteArrayContent Content { get; set; }
        public Uri BaseAddress { get; set; }

        public Client()
        {
            Method = Method.GET;
            Content = null;
        }

        public dynamic Request(string endpoint)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = BaseAddress
            };
            Task<HttpResponseMessage> httpResponse = null;
            var response = string.Empty;
            switch (Method)
            {
                case Method.GET:
                    httpResponse = httpClient.GetAsync(endpoint);
                    break;
                case Method.POST:
                    httpResponse = httpClient.PostAsync(endpoint, Content);
                    break;
                case Method.PUT:
                    httpResponse = httpClient.PutAsync(endpoint, Content);
                    break;
                case Method.DELETE:
                    httpResponse = httpClient.DeleteAsync(endpoint);
                    break;
            }

            if (httpResponse != null)
            {
                using (HttpContent content = httpResponse.Result.Content)
                {
                    Task<string> result = content.ReadAsStringAsync();
                    response = result.Result;
                }
            }

            return JsonConvert.DeserializeObject(response);
        }
    }
}
