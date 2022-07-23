using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;

namespace AsoFacil.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetHttpClient(this HttpContext context)
        {
            var client = new HttpClient();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var token = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();

            if (token == null)
                throw new ArgumentNullException(nameof(token));

            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            return client;
        }
    }
}