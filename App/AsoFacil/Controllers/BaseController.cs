using AsoFacil.Helpers;
using AsoFacil.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeRequestToApi(string url, object model, HttpClient client, TypeRequest typeRequest)
        {
            var uri = new Uri($"{Config.base_uri}{url}");

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            switch (typeRequest)
            {
                case TypeRequest.GetAsync:
                    response = await client.GetAsync(uri);
                    break;
                case TypeRequest.PostAsync:
                    response = await client.PostAsync(uri, content);
                    break;
                case TypeRequest.PutAsync:
                    response = await client.PutAsync(uri, content);
                    break;
                case TypeRequest.DeleteAsync:
                    response = await client.DeleteAsync(uri);
                    break;
                default:
                    break;
            }
            
            var apiResponseContent = await response.Content.ReadAsStringAsync();
            var taskResult = JsonConvert.DeserializeObject<TaskResult>(apiResponseContent);

            return (response, taskResult);
        }

        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeAnonymousRequestToApi(string url, object model, TypeRequest typeRequest)
        {
            return await CreateAndMakeRequestToApi(url, model, new HttpClient(), typeRequest);
        }

        protected async Task<(HttpResponseMessage, TaskResult)> CreateAndMakeAuthenticatedRequestToApi(string url, object model, TypeRequest typeRequest, ClaimsPrincipal User)
        {
            return await CreateAndMakeRequestToApi(url, model, HttpClientHelper.GetHttpClient(HttpContext, User), typeRequest);
        }
    }

    public enum TypeRequest
    {
        GetAsync,
        PostAsync,
        PutAsync,
        DeleteAsync
    }
}