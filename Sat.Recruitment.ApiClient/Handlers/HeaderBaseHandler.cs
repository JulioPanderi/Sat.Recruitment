using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Client.Handlers
{
    public class HeaderBaseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            //if (!request.Headers.Contains("AuthToken"))
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest)
            //    {
            //        Content = new StringContent("Unauthorized")
            //    };
            //}

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
