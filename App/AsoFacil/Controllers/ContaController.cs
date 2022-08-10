using AsoFacil.Models.Conta;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var identity = (ClaimsIdentity)User.Identity;
                var codigoTipoUsuario = identity.Claims.FirstOrDefault(x => x.Type.Equals("CodigoTipoUsuario")).Value;
                var tokenExpirado = identity.Claims.FirstOrDefault(x => x.Type.Equals("Token"));

                if (tokenExpirado != null)
                    identity.RemoveClaim(tokenExpirado);

                var model = new UsuarioViewModel()
                {
                    Login = identity.Claims.FirstOrDefault(x => x.Type.Equals("Login")).Value,
                    Senha = identity.Claims.FirstOrDefault(x => x.Type.Equals("Senha")).Value
                };

                var (response, taskResult) = CreateAndMakeAnonymousRequestToApi("/api/usuarios/v1/login", model, TypeRequest.PostAsync).Result;
                var user = JsonConvert.DeserializeObject<UsuarioModel>(taskResult.Data.ToString());

                identity.AddClaim(new Claim("Token", user.Token));

                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = claimsPrincipal;

                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = null,
                    IsPersistent = true
                };

                HttpContext.SignOutAsync();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

                return Redirect(ObterUrlRedirecionamento(codigoTipoUsuario));
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UsuarioViewModel model)
        {
            var (response, taskResult) = await CreateAndMakeAnonymousRequestToApi("/api/usuarios/v1/login", model, TypeRequest.PostAsync);
            if (response.IsSuccessStatusCode && taskResult.IsSuccess)
            {
                var user = JsonConvert.DeserializeObject<UsuarioModel>(taskResult.Data.ToString());

                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim("Token", user.Token),
                    new Claim("CodigoTipoUsuario", user.TipoUsuario.Codigo),
                    new Claim("MenuSistema", user.TipoUsuario.MenuSistema),
                    new Claim("EmpresaId", user.Empresa.Id.ToString()),
                    new Claim("CNPJ", user.Empresa.CNPJ),
                    new Claim("Email", user.Empresa.Email)
                };

                if (model.LembrarDeMim)
                {
                    claims.Add(new Claim("Login", model.Login));
                    claims.Add(new Claim("Senha", model.Senha));
                }

                taskResult.UrlRedirect = ObterUrlRedirecionamento(user.TipoUsuario.Codigo);

                ClaimsIdentity identity = new ClaimsIdentity(claims, "AsoFacil");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = claimsPrincipal;

                var authenticationProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = model.LembrarDeMim ? null : DateTime.Now.ToLocalTime().AddMinutes(15),
                    IsPersistent = model.LembrarDeMim
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

        #region private

        private string ObterUrlRedirecionamento(string codigoTipoUsuario)
        {
            string urlRedirecionamento = codigoTipoUsuario switch
            {
                "EMPRESA_ADMIN" => "/Agendamento/Cadastro",
                "ASOFACIL_ADMIN" => "/Dashboard/Index",
                "EMPRESA_OPR" => "/Agendamento/Cadastro",
                "CLINICA_ADMIN" => "/Agendamento/Cadastro",
                "CLINICA_OPR" => "/Agendamento/Cadastro",
                "CLINICA_MED" => "/Agendamento/Cadastro",
                _ => "/Conta/Index",
            };
            return urlRedirecionamento;
        }

        #endregion private
    }
}