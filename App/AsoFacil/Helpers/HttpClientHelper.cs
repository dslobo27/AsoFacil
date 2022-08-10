using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;

namespace AsoFacil.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetHttpClient(this HttpContext context, ClaimsPrincipal User)
        {
            var client = new HttpClient();

            var identity = (ClaimsIdentity)User.Identity;
            var token = identity.Claims.Where(c => c.Type.Equals("Token"))
                   .Select(c => c.Value).SingleOrDefault();

            if (token == null)
                throw new ArgumentNullException(nameof(token));

            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            return client;
        }
    }
}