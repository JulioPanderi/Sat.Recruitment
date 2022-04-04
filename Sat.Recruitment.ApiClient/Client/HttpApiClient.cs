using System;
using System.Net.Http;

namespace Sat.Recruitment.ApiClient
{
    public class HttpApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpApiClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void CreateClients()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:44300/");
            client.DefaultRequestHeaders.Add("Authorization", "YOUR_ASSEMBLY_AI_TOKEN");
        }
    }
}
