using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QAAutomationLab.CoreLayer.Clients
{
    public class BaseHttpClient : IBaseClient
    {
        private readonly HttpClient _httpClient;

        public BaseHttpClient(string baseUrl)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
            };
        }

        public BaseHttpClient(string baseUrl, string token)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl),
            };

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }

        public void AddHeader(string name, string value)
        {
            _httpClient.DefaultRequestHeaders.Remove(name);
            _httpClient.DefaultRequestHeaders.Add(name, value);
        }

        public async Task<T> Delete<T>(string url, int id)
        {
            var result = await _httpClient.DeleteAsync(url + id);

            return await DeserializeResultAsync<T>(result);
        }

        public async Task<T> Get<T>(string url)
        {
            var result = await _httpClient.GetAsync(url);

            return await DeserializeResultAsync<T>(result);
        }

        public async Task<T> Post<T>(string url, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(url, data);

            return await DeserializeResultAsync<T>(result);
        }

        public async Task<T> Put<T>(string url, int id, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await _httpClient.PutAsync(url + id, data);

            return await DeserializeResultAsync<T>(result);
        }

        private static async Task<T> DeserializeResultAsync<T>(HttpResponseMessage response)
        {
            var message = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(message, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }
    }
}