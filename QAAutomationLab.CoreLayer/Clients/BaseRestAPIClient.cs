using System.Threading.Tasks;
using RestSharp;

namespace QAAutomationLab.CoreLayer.Clients
{
    public class BaseRestAPIClient
    {
        public BaseRestAPIClient(string url)
        {
            Client = new RestClient(url);
        }

        public RestClient Client { get; private set; }

        public RestRequest CreateRequest(string resourse, Method method)
        {
            var request = new RestRequest(resourse, method);

            return request;
        }

        public void AddHeader(string name, string value)
        {
            Client.AddDefaultHeader(name, value);
        }

        public Task<RestResponse> ExecuteAsyncRequest(RestRequest request)
        {
            var response = Client.ExecuteAsync(request);

            return response;
        }
    }
}
