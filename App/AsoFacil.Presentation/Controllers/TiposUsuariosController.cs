using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.TipoUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Endpoint para obter todos os tipos de usuários
        /// </summary>
        /// <param name="service"></param>
        /// <param name="codigo"></param>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet("api/tiposusuarios/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] ITipoUsuarioApplicationService service, [FromQuery] string codigo, [FromQuery] string descricao)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<IEnumerable<TipoUsuarioModel>>(ModelState.GetErrors()));

            try
            {
                var tiposUsuarios = await service.ObterAsync(codigo, descricao);
                return Ok(new TaskResult<IEnumerable<TipoUsuarioModel>>(tiposUsuarios));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<IEnumerable<TipoUsuarioModel>>($"Ocorreu um erro ao obter tipos de usuários! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um tipo de usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="tipoUsuarioId"></param>
        /// <returns></returns>
        [HttpGet("api/tiposusuarios/v1/getbyidasync/{tipoUsuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] ITipoUsuarioApplicationService service, Guid tipoUsuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<TipoUsuarioModel>(ModelState.GetErrors()));

            try
            {
                var tipoUsuario = await service.ObterPorIdAsync(tipoUsuarioId);
                return Ok(new TaskResult<TipoUsuarioModel>(tipoUsuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<TipoUsuarioModel>($"Ocorreu um erro ao obter tipo de usuário! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um tipo de usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("api/tiposusuarios/v1/putasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] ITipoUsuarioApplicationService service, [FromBody] ManterTipoUsuarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(result ? "Tipo de usuário alterado com sucesso!" : "Tipo de usuário não foi alterado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao alterar tipo de usuário! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um tipo de usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/tiposusuarios/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] ITipoUsuarioApplicationService service, [FromBody] ManterTipoUsuarioModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(result ? "Tipo de usuário cadastrado com sucesso!" : "Tipo de usuário não foi cadastrado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao cadastrar tipo de usuário! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um tipo de usuário
        /// </summary>
        /// <param name="service"></param>
        /// <param name="tipoUsuarioId"></param>
        /// <returns></returns>
        [HttpDelete("api/tiposusuarios/v1/deleteasync/{tipoUsuarioId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] ITipoUsuarioApplicationService service, Guid tipoUsuarioId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(tipoUsuarioId);
                return Ok(new TaskResult<string>(result ? "Tipo de usuário excluído com sucesso!" : "Tipo de usuário não foi excluído. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao excluir tipo de usuário! {ex.Message}"));
            }
        }
    }
}