using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.TestFramework.Environment
{
    public class ClientResponse
    {
        public HttpStatusCode StatusCode { get; private set; }
        public HttpResponseHeaders Headers { get; private set; }
        public string StringBody { get; private set; }
        public JToken JsonBody { get; private set; }

        public ClientResponse(Task<HttpResponseMessage> response)
        {
            StringBody = string.Empty;

            if (response != null)
            {
                Headers = response.Result.Headers;
                StatusCode = response.Result.StatusCode;

                using (HttpContent httpContent = response.Result.Content)
                {
                    Task<string> contentBody = httpContent.ReadAsStringAsync();
                    StringBody = contentBody.Result;
                    JsonBody = JToken.Parse(StringBody);
                }
            }
        }

        public T JsonPath<T>(string path = "$")
        {
            return JsonBody.SelectToken(path).ToObject<T>();
        }
    }
}
