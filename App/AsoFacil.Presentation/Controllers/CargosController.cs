using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Cargo;
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
    public class CargosController : Controller
    {
        /// <summary>
        /// Endpoint para obter todos os cargos
        /// </summary>
        /// <param name="service"></param>
        /// <param name="descricao"></param>
        /// <returns></returns>
        [HttpGet("api/cargos/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] ICargoApplicationService service, [FromQuery] string descricao)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<CargoModel>>(ModelState.GetErrors()));

            try
            {
                var cargos = await service.ObterAsync(descricao);
                return Ok(new TaskResult<IEnumerable<CargoModel>>(cargos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<CargoModel>>($"Ocorreu um erro ao obter cargos! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter um cargo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cargoId"></param>
        /// <returns></returns>
        [HttpGet("api/cargos/v1/getbyidasync/{cargoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] ICargoApplicationService service, Guid cargoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<CargoModel>(ModelState.GetErrors()));

            try
            {
                var cargo = await service.ObterPorIdAsync(cargoId);
                return Ok(new TaskResult<CargoModel>(cargo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<CargoModel>($"Ocorreu um erro ao obter cargo! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um cargo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("api/cargos/v1/putasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] ICargoApplicationService service, [FromBody] ManterCargoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(result ? "Cargo alterado com sucesso!" : "Cargo não foi alterado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao alterar cargo! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para cadastrar um cargo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("api/cargos/v1/postasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromServices] ICargoApplicationService service, [FromBody] ManterCargoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(result ? "Cargo cadastrado com sucesso!" : "Cargo não foi cadastrado. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao cadastrar cargo! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar um cargo
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cargoId"></param>
        /// <returns></returns>
        [HttpDelete("api/cargos/v1/deleteasync/{cargoId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] ICargoApplicationService service, Guid cargoId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(cargoId);
                return Ok(new TaskResult<string>(result ? "Cargo excluído com sucesso!" : "Cargo não foi excluído. Tente novamente!", null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"Ocorreu um erro ao excluir cargo! {ex.Message}"));
            }
        }
    }
}