using AsoFacil.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class EmpresaController : BaseController
    {
        #region Views

        private const string ASOFACIL_ADMIN = "ASOFACIL_ADMIN";

        [AllowAnonymous]
        public IActionResult Cadastro()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var codigoTipoUsuario = identity.Claims.FirstOrDefault(x => x.Type.Equals("CodigoTipoUsuario")).Value;

                return codigoTipoUsuario.Equals(ASOFACIL_ADMIN) ? RedirectToAction("ListarCadastro") : RedirectToAction("EditarCadastro");
            }

            return View();
        }

        public IActionResult EditarCadastro()
        {
            return View("EditarCadastro");
        }

        public IActionResult ListarCadastro()
        {
            return View("ListarCadastro");
        }

        [HttpPost("empresa/modal")]
        public IActionResult Modal([FromBody] ManterEmpresaViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var empresa = GetByIdAsync(model.Id).Result;
                model.CNPJ = empresa.CNPJ;
                model.RazaoSocial = empresa.RazaoSocial;
                model.Email = empresa.Email;
                model.Ativa = empresa.Ativa;
                model.FlagClinica = empresa.FlagClinica;
            }

            return PartialView("_Modal", model);
        }

        #endregion Views

        #region Actions

        [HttpGet("empresa/getasync")]
        public async Task<IEnumerable<EmpresaViewModel>> GetAsync([FromQuery] string cnpj, [FromQuery] string razaoSocial)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/empresas/v1/getasync?cnpj={cnpj}&razaoSocial={razaoSocial}", null, TypeRequest.GetAsync, User);
            var empresas = JsonConvert.DeserializeObject<List<EmpresaViewModel>>(taskResult?.Data.ToString());
            return empresas;
        }

        [HttpGet("empresa/getbyidasync")]
        public async Task<EmpresaViewModel> GetByIdAsync(Guid empresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/empresas/v1/getbyidasync/{empresaId}", null, TypeRequest.GetAsync, User);
            var empresa = JsonConvert.DeserializeObject<EmpresaViewModel>(taskResult?.Data.ToString());
            return empresa;
        }

        [HttpPost("empresa/postasync")]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] ManterEmpresaViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAnonymousRequestToApi("/api/empresas/v1/postasync", model, TypeRequest.PostAsync);
            return Json(taskResult);
        }

        [HttpPut("empresa/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterEmpresaViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/empresas/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("empresa/deleteasync/{empresaId}")]
        public async Task<ActionResult> DeleteAsync(Guid empresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/empresas/v1/deleteasync/{empresaId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions
    }
}