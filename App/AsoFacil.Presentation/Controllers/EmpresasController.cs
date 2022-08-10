using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Empresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class EmpresasController : Controller
    {
        /// <summary>
        /// Endpoint para cadastrar uma empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/empresas/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] IEmpresaApplicationService service, [FromBody] CriarEmpresaModel model)
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