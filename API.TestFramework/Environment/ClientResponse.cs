using Newtonsoft.Json;
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
        public string Body { get; private set; }

        public ClientResponse(Task<HttpResponseMessage> response)
        {
            Body = string.Empty;

            if (response != null)
            {
                Headers = response.Result.Headers;
                StatusCode = response.Result.StatusCode;

                using (HttpContent httpContent = response.Result.Content)
                {
                    Task<string> contentBody = httpContent.ReadAsStringAsync();
                    Body = contentBody.Result;
                }
            }
        }

        public dynamic GetDynamic()
        {
            return JsonConvert.DeserializeObject(Body);
        }

        public T GetGeneric<T>()
        {
            return JsonConvert.DeserializeObject<T>(Body);
        }
    }
}
