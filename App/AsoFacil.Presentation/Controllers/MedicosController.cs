using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Medico;
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
    public class MedicosController : Controller
    {
        private const string entity = "Médico";

        /// <summary>
        /// Endpoint para obter todos os médicos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="crm"></param>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet(Routes.GET_MEDICOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IMedicoApplicationService service, [FromQuery] string crm, [FromQuery] string nome)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<MedicoModel>>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterAsync(crm, nome);
                return Ok(new TaskResult<IEnumerable<MedicoModel>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<MedicoModel>>($"{MessagesApi.Exception(string.Format("{0}{1}", entity, "s"), Routes.GET_MEDICOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um médico
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETBYID_MEDICOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IMedicoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<MedicoModel>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterPorIdAsync(id);
                return Ok(new TaskResult<MedicoModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<MedicoModel>($"{MessagesApi.Exception(entity, Routes.GETBYID_MEDICOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um médico/paciente
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.POST_MEDICOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] IMedicoApplicationService service, [FromBody] ManterMedicoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_MEDICOS)
                           : MessagesApi.Error(entity, Routes.POST_MEDICOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_MEDICOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um médico
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_MEDICOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IMedicoApplicationService service, [FromBody] ManterMedicoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_MEDICOS)
                           : MessagesApi.Error(entity, Routes.PUT_MEDICOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_MEDICOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para excluir um médico
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Routes.DELETE_MEDICOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IMedicoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(id);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.DELETE_MEDICOS)
                           : MessagesApi.Error(entity, Routes.DELETE_MEDICOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.DELETE_MEDICOS)} {ex.Message}"));
            }
        }
    }
}