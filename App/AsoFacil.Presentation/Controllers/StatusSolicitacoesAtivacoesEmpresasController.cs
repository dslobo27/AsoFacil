using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.StatusSolicitacaoAtivacaoEmpresa;
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
    public class StatusSolicitacoesAtivacoesEmpresasController : Controller
    {
        /// <summary>
        /// Endpoint para obter todos os status de solicitações de ativação de empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet("api/statussolicitacoesativacoesempresas/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IStatusSolicitacaoAtivacaoEmpresaApplicationService service, [FromQuery] string codigo, [FromQuery] string descricao)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<StatusSolicitacaoAtivacaoEmpresaModel>>(ModelState.GetErrors()));

            try
            {
                var statussolicitacoesativacoesempresas = await service.ObterAsync(codigo, descricao);
                return Ok(new TaskResult<IEnumerable<StatusSolicitacaoAtivacaoEmpresaModel>>(statussolicitacoesativacoesempresas));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<StatusSolicitacaoAtivacaoEmpresaModel>>($"Ocorreu um erro ao obter status de solicitações de ativações de empresas! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um Status de solicitação de ativação de empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="statusSolicitacaoAgendamentoId"></param>
        /// <returns></returns>
        [HttpGet("api/statussolicitacoesativacoesempresas/v1/getbyidasync/{statusSolicitacaoAgendamentoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IStatusSolicitacaoAtivacaoEmpresaApplicationService service, Guid statusSolicitacaoAgendamentoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<StatusSolicitacaoAtivacaoEmpresaModel>(ModelState.GetErrors()));

            try
            {
                var statusSolicitacaoAgendamento = await service.ObterPorIdAsync(statusSolicitacaoAgendamentoId);
                return Ok(new TaskResult<StatusSolicitacaoAtivacaoEmpresaModel>(statusSolicitacaoAgendamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<StatusSolicitacaoAtivacaoEmpresaModel>($"Ocorreu um erro ao obter status de solicitação de ativação de empresa! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um Status de solicitação de ativação de empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("api/statussolicitacoesativacoesempresas/v1/putasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IStatusSolicitacaoAtivacaoEmpresaApplicationService service, [FromBody] ManterStatusSolicitacaoAtivacaoEmpresaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(result ? "Status de solicitação de ativação de empresa alterado com sucesso!" : "Status de solicitação de ativação de empresa não foi alterado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao alterar status de solicitação de ativação de empresa! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um Status de solicitação de ativação de empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/statussolicitacoesativacoesempresas/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] IStatusSolicitacaoAtivacaoEmpresaApplicationService service, [FromBody] ManterStatusSolicitacaoAtivacaoEmpresaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(result ? "Status de solicitação de ativação de empresa cadastrado com sucesso!" : "Status de solicitação de ativação de empresa não foi cadastrado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao cadastrar status de solicitação de ativação de empresa! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para excluir um Status de solicitação de ativação de empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="statusSolicitacaoAgendamentoId"></param>
        /// <returns></returns>
        [HttpDelete("api/statussolicitacoesativacoesempresas/v1/deleteasync/{statusSolicitacaoAgendamentoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IStatusSolicitacaoAtivacaoEmpresaApplicationService service, Guid statusSolicitacaoAgendamentoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(statusSolicitacaoAgendamentoId);
                return Ok(new TaskResult<string>(result ? "Status de solicitação de ativação de empresa excluído com sucesso!" : "Status de solicitação de ativação de empresa não foi excluído. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao excluir status de solicitação de ativação de empresa! {ex.Message}"));
            }
        }
    }
}