using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace Azure4Alexa.Helper
{
    public class ApiClient
    {
        private readonly string _authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyIiOiIifQ.CaBX0LuTC5yliNtMt_anrHQcp2lIVY-4UwiFIbc-EBU";

        public ApiClient()
        {
        }

        public HttpResponseMessage Get(string apiMethod)
        {
            var uri = new Uri(apiMethod);
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                ConfigureClient(client);
                return client.GetAsync(uri).Result;
            }
        }

        public T Get<T>(string apiMethod)
        {
            var httpResponse = Get(apiMethod);
            httpResponse.EnsureSuccessStatusCode();
            var result = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(result); ;
        }

        public async Task<HttpResponseMessage> GetAsync(string apiMethod)
        {
            var uri = new Uri(apiMethod);
            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                ConfigureClient(client);
                return await client.GetAsync(uri);
            }
        }

        public async Task<T> GetAsync<T>(string apiMethod)
        {
            var httpResponse = await GetAsync(apiMethod);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpResponseException(httpResponse.StatusCode);
            }

            var result = await httpResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<HttpResponseMessage> SendAsAsync(HttpMethod method, string apiMethod, object content)
        {
            string json = JsonConvert.SerializeObject(content);
            var message = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(apiMethod)
            };

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                ConfigureClient(client);
                var httpResponse = await client.SendAsync(message);
                return httpResponse;
            }
        }
        public async Task<T> SendAsAsync<T>(HttpMethod method, string apiMethod, object content)
        {
            var response = await SendAsAsync(method, apiMethod, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }


        public async Task<HttpResponseMessage> PostAsAsync(string apiMethod, object content)
        {
            string json = JsonConvert.SerializeObject(content);
            var message = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(apiMethod),
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            using (var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                ConfigureClient(client);
                return await client.SendAsync(message);
            }
        }

        public async Task<T> PostAsAsync<T>(string apiMethod, object content)
        {
            var response = await PostAsAsync(apiMethod, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);

        }

        private void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"DirectLogin token={_authToken}");
        }
    }
}