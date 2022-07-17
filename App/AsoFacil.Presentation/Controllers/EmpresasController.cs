using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/empresas")]
    public class EmpresasController : Controller
    {
        [HttpPost("/v1/create")]
        public async Task<IActionResult> Post([FromServices] IEmpresaApplicationService service, [FromBody] CriarEmpresaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var taskResult = await service.CriarAsync(model);
                if (taskResult)
                    return Ok(new TaskResult<string>("Empresa cadastrada com sucesso!", null));

                throw new Exception("Erro inesperado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao cadastrar empresa! {ex.Message}"));
            }
        }
    }
}