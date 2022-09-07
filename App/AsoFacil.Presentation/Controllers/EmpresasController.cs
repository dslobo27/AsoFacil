using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Empresa;
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
    public class EmpresasController : Controller
    {
        private const string entity = "Empresa";

        /// <summary>
        /// Endpoint para cadastrar uma empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Routes.POST_EMPRESAS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromServices] IEmpresaApplicationService service, [FromBody] ManterEmpresaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.CriarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.POST_EMPRESAS, EntityGender.Feminino)
                           : MessagesApi.Error(entity, Routes.POST_EMPRESAS, EntityGender.Feminino), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.POST_EMPRESAS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter todos as empresas
        /// </summary>
        /// <param name="service"></param>
        /// <param name="cnpj"></param>
        /// <param name="razaoSocial"></param>
        /// <returns></returns>
        [HttpGet(Routes.GET_EMPRESAS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IEmpresaApplicationService service, [FromQuery] string cnpj, [FromQuery] string razaoSocial)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<EmpresaModel>>(ModelState.GetErrors()));

            try
            {
                var empresas = await service.ObterAsync(cnpj, razaoSocial);
                return Ok(new TaskResult<IEnumerable<EmpresaModel>>(empresas));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<EmpresaModel>>($"{MessagesApi.Exception(string.Format("{0}{1}", entity, "s"), Routes.GET_EMPRESAS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para obter uma empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="empresaId"></param>
        /// <returns></returns>
        [HttpGet(Routes.GETBYID_EMPRESAS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromServices] IEmpresaApplicationService service, Guid empresaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<EmpresaModel>(ModelState.GetErrors()));

            try
            {
                var empresa = await service.ObterPorIdAsync(empresaId);
                return Ok(new TaskResult<EmpresaModel>(empresa));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<EmpresaModel>($"{MessagesApi.Exception(entity, Routes.GETBYID_EMPRESAS)} {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para alterar uma empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut(Routes.PUT_EMPRESAS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] IEmpresaApplicationService service, [FromBody] ManterEmpresaModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.AlterarAsync(model);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.PUT_EMPRESAS, EntityGender.Feminino)
                           : MessagesApi.Error(entity, Routes.PUT_EMPRESAS, EntityGender.Feminino), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.PUT_EMPRESAS)} {ex.Message}"));
            }
        }        

        /// <summary>
        /// Endpoint para excluir uma empresas
        /// </summary>
        /// <param name="service"></param>
        /// <param name="empresaId"></param>
        /// <returns></returns>
        [HttpDelete(Routes.DELETE_EMPRESAS)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromServices] IEmpresaApplicationService service, Guid empresaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<string>(ModelState.GetErrors()));

            try
            {
                var result = await service.ExcluirAsync(empresaId);
                return Ok(new TaskResult<string>(
                    result ? MessagesApi.Sucess(entity, Routes.DELETE_EMPRESAS, EntityGender.Feminino) 
                           : MessagesApi.Error(entity, Routes.DELETE_EMPRESAS, EntityGender.Feminino), null)
                    );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<string>($"{MessagesApi.Exception(entity, Routes.DELETE_EMPRESAS)} {ex.Message}"));
            }
        }
    }
}