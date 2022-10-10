using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Agendamento;
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
    public class AgendamentosController : Controller
    {
        private const string entity = "Agendamento";

        /// <summary>
        /// Endpoint para obter todos os agendamentos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="nome"></param>
        /// <param name="rg"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet(Routes.GET_AGENDAMENTOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IAgendamentoApplicationService service, [FromQuery] string nome, [FromQuery] string rg, [FromQuery] string dtInicio, [FromQuery] string dtFim)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<AgendamentoModel>>(ModelState.GetErrors()));

            try
            {
                DateTime? dataInicio = null;
                DateTime? dataFim = null;

                if (!string.IsNullOrEmpty(dtInicio))
                    dataInicio = DateTime.Parse(dtInicio);

                if (!string.IsNullOrEmpty(dtFim))
                    dataFim = DateTime.Parse($"{dtFim} 23:59:59");

                var result = await service.ObterAsync(nome, rg, dataInicio, dataFim);
                return Ok(new TaskResult<IEnumerable<AgendamentoModel>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<AgendamentoModel>>($"{MessagesApi.Exception(string.Format("{0}{1}", entity, "s"), Routes.GET_AGENDAMENTOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETBYID_AGENDAMENTOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync([FromServices] IAgendamentoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<AgendamentoModel>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterPorIdAsync(id);
                return Ok(new TaskResult<AgendamentoModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<AgendamentoModel>($"{MessagesApi.Exception(entity, Routes.GETBYID_AGENDAMENTOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.POST_AGENDAMENTOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] IAgendamentoApplicationService service, [FromBody] ManterAgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_AGENDAMENTOS)
                           : MessagesApi.Error(entity, Routes.POST_AGENDAMENTOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_AGENDAMENTOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_AGENDAMENTOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IAgendamentoApplicationService service, [FromBody] ManterAgendamentoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_AGENDAMENTOS)
                           : MessagesApi.Error(entity, Routes.PUT_AGENDAMENTOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_AGENDAMENTOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para excluir um agendamento
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Routes.DELETE_AGENDAMENTOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IAgendamentoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(id);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.DELETE_AGENDAMENTOS)
                           : MessagesApi.Error(entity, Routes.DELETE_AGENDAMENTOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.DELETE_AGENDAMENTOS)} {ex.Message}"));
            }
        }
    }
}