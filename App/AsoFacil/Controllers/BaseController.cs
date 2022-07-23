using AsoFacil.Helpers;
using AsoFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeRequestToApi(string url, object model, HttpClient client)
        {
            var uri = new Uri($"{Config.base_uri}{url}");

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);
            var apiResponseContent = await response.Content.ReadAsStringAsync();
            var taskResult = JsonConvert.DeserializeObject<TaskResult>(apiResponseContent);

            return (response, taskResult);
        }

        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeAnonymousRequestToApi(string url, object model)
        {
            return await CreateAndMakeRequestToApi(url, model, new HttpClient());
        }

        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeAuthenticatedRequestToApi(string url, object model)
        {
            return await CreateAndMakeRequestToApi(url, model, HttpClientHelper.GetHttpClient(HttpContext));
        }
    }
}