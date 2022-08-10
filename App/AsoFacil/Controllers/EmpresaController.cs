using AsoFacil.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class EmpresaController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult EditarCadastro()
        {
            var model = new EmpresaViewModel
            {
                CNPJ = "70.918.873/0001-63",
                RazaoSocial = "IBLUE CONSULTING LTDA",
                Email = "rh@iblueconsulting.com.br",
                Id = Guid.NewGuid()
            };

            return View("EditarCadastro", model);
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