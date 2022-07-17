using AsoFacil.Models.Conta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var client = new HttpClient();
                var uri = new Uri($"{Config.base_uri}/api/usuarios/v1/login");

                var content = new StringContent(JsonConvert.SerializeObject(model), 
                                    Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    var token = await response.Content.ReadAsStringAsync();
                    HttpContext.Session.SetString("token", token);
                    return RedirectToAction("Index", "Home");
                }

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
