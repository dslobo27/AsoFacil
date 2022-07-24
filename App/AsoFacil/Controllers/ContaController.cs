using AsoFacil.Models.Conta;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class ContaController : BaseController
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Cadastro", "Agendamento");
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UsuarioLoginModel model)
        {
            var (response, taskResult) = await CreateAndMakeAnonymousRequestToApi("/api/usuarios/v1/login", model);
            if (response.IsSuccessStatusCode && taskResult.IsSuccess)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, taskResult.Data.ToString())
                    };

                var id = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(id);
                Thread.CurrentPrincipal = claimsPrincipal;

                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            }

            return Json(taskResult);
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Conta");
        }
    }
}