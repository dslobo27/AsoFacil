using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.StatusAgendamento;
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
    public class StatusAgendamentosController : Controller
    {
        /// <summary>
        /// Endpoint para obter todos os status de agendamentos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet("api/statusagendamentos/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IStatusAgendamentoApplicationService service, [FromQuery] string descricao)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<StatusAgendamentoModel>>(ModelState.GetErrors()));

            try
            {
                var statusAgendamentos = await service.ObterAsync(descricao);
                return Ok(new TaskResult<IEnumerable<StatusAgendamentoModel>>(statusAgendamentos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<StatusAgendamentoModel>>($"Ocorreu um erro ao obter status de agendamentos! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um status de agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="statusAgendamentoId"></param>
        /// <returns></returns>
        [HttpGet("api/statusagendamentos/v1/getbyidasync/{statusAgendamentoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IStatusAgendamentoApplicationService service, Guid statusAgendamentoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<StatusAgendamentoModel>(ModelState.GetErrors()));

            try
            {
                var statusAgendamento = await service.ObterPorIdAsync(statusAgendamentoId);
                return Ok(new TaskResult<StatusAgendamentoModel>(statusAgendamento));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<StatusAgendamentoModel>($"Ocorreu um erro ao obter status de agendamento! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um status de agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("api/statusagendamentos/v1/putasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IStatusAgendamentoApplicationService service, [FromBody] ManterStatusAgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(result ? "Status de agendamento alterado com sucesso!" : "Status de agendamento não foi alterado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao alterar status de agendamento! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um status de agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/statusagendamentos/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] IStatusAgendamentoApplicationService service, [FromBody] ManterStatusAgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(result ? "Status de agendamento cadastrado com sucesso!" : "Status de agendamento não foi cadastrado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao cadastrar status de agendamento! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um status de agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cargoId"></param>
        /// <returns></returns>
        [HttpDelete("api/statusagendamentos/v1/deleteasync/{statusAgendamentoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IStatusAgendamentoApplicationService service, Guid statusAgendamentoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(statusAgendamentoId);
                return Ok(new TaskResult<string>(result ? "Status de agendamento excluído com sucesso!" : "Status de agendamento não foi excluído. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao excluir status de agendamento! {ex.Message}"));
            }
        }
    }
}