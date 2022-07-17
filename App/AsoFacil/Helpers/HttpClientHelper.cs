using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;

namespace AsoFacil.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient GetHttpClient(this HttpContext context)
        {
            var client = new HttpClient();
            string token = context.Session.GetString("token");

            if (token == null)
                throw new ArgumentNullException(nameof(token));

            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            return client;
        }
    }
}