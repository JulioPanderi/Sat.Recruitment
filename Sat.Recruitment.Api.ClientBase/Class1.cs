using System;
using System.Net.Http;

namespace Sat.Recruitment.Api.ClientBase
{
    public class HttpApiClientFactory
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpApiClientFactory(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}
