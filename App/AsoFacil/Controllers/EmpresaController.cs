using AsoFacil.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class EmpresaController : BaseController
    {
        private const string ASOFACIL_ADMIN = "ASOFACIL_ADMIN";

        [AllowAnonymous]
        public IActionResult Cadastro()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)User.Identity;
                var codigoTipoUsuario = identity.Claims.FirstOrDefault(x => x.Type.Equals("CodigoTipoUsuario")).Value;

                return codigoTipoUsuario.Equals(ASOFACIL_ADMIN) ? RedirectToAction("ListarCadastro")  : RedirectToAction("EditarCadastro");
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

        [HttpPost("empresa/postasync")]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] CriarEmpresaViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAnonymousRequestToApi("/api/empresas/v1/postasync", model, TypeRequest.PostAsync);
            return Json(taskResult);
        }
    }
}