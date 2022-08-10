using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.TipoUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class TiposUsuariosController : Controller
    {
        /// <summary>
        /// Endpoint para obter um tipo de usuário pelo código
        /// </summary>
        /// <param name="service"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("/api/tiposusuarios/v1/getbycodeasync/{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCodeAsync([FromServices] ITipoUsuarioApplicationService service, string code)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<TipoUsuarioModel>(ModelState.GetErrors()));

            try
            {
                var tipoUsuario = await service.ObterPorCodigo(code);
                return Ok(new TaskResult<TipoUsuarioModel>(tipoUsuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<TipoUsuarioModel>($"Ocorreu um erro ao obter tipo de usuário! {ex.Message}"));
            }
        }
    }
}