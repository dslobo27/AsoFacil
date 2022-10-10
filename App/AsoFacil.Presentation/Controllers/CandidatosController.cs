using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Candidato;
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
    public class CandidatosController : Controller
    {
        private const string entity = "Candidato";

        /// <summary>
        /// Endpoint para obter todos os candidatos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="nome"></param>
        /// <param name="rg"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet(Routes.GET_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] ICandidatoApplicationService service, [FromQuery] string nome, [FromQuery] string rg, [FromQuery] string email)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<CandidatoModel>>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterAsync(nome, rg, email);
                return Ok(new TaskResult<IEnumerable<CandidatoModel>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<CandidatoModel>>($"{MessagesApi.Exception(string.Format("{0}{1}", entity, "s"), Routes.GET_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um candidato
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETBYID_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync([FromServices] ICandidatoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<CandidatoModel>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterPorIdAsync(id);
                return Ok(new TaskResult<CandidatoModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<CandidatoModel>($"{MessagesApi.Exception(entity, Routes.GETBYID_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter anamnese de um candidato
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETANAMNESEBYID_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnamneseByCandidatoIdAsync([FromServices] ICandidatoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<AnamneseModel>(ModelState.GetErrors()));

            try
            {
                var result = await service.ObterAnamnesePorCandidatoIdAsync(id);
                return Ok(new TaskResult<AnamneseModel>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<AnamneseModel>($"{MessagesApi.Exception(entity, Routes.GETANAMNESEBYID_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um candidato/paciente
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.POST_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] ICandidatoApplicationService service, [FromBody] ManterCandidatoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_CANDIDATOS)
                           : MessagesApi.Error(entity, Routes.POST_CANDIDATOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar a anamnese do candidato/paciente
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.POST_ANAMNESE_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> AnamnesePostAsync([FromServices] ICandidatoApplicationService service, [FromBody] AnamneseModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAnamneseAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_ANAMNESE_CANDIDATOS)
                           : MessagesApi.Error(entity, Routes.POST_ANAMNESE_CANDIDATOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_ANAMNESE_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar a anamnese do candidato/paciente
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_ANAMNESE_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> AnamnesePutAsync([FromServices] ICandidatoApplicationService service, [FromBody] AnamneseModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAnamneseAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_ANAMNESE_CANDIDATOS)
                           : MessagesApi.Error(entity, Routes.PUT_ANAMNESE_CANDIDATOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_ANAMNESE_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um candidato
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] ICandidatoApplicationService service, [FromBody] ManterCandidatoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_CANDIDATOS)
                           : MessagesApi.Error(entity, Routes.PUT_CANDIDATOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_CANDIDATOS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para excluir um candidato
        /// </summary>
        /// <param name="service"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Routes.DELETE_CANDIDATOS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] ICandidatoApplicationService service, Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(id);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.DELETE_CANDIDATOS)
                           : MessagesApi.Error(entity, Routes.DELETE_CANDIDATOS), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.DELETE_CANDIDATOS)} {ex.Message}"));
            }
        }
    }
}