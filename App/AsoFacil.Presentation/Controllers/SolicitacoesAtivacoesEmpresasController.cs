using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.SolicitacaoAtivacaoEmpresa;
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
    public class SolicitacoesAtivacoesEmpresasController : Controller
    {
        /// <summary>
        /// Endpoint para obter todas as solicitações de ativação pendentes
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet("api/solicitacoesativacoesempresas/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] ISolicitacaoAtivacaoEmpresaApplicationService service)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<List<SolicitacaoAtivacaoEmpresaModel>>(ModelState.GetErrors()));

            try
            {
                var solicitacoesAtivacoesEmpresas = await service.ObterParaAtivacaoAsync();
                return Ok(new TaskResult<List<SolicitacaoAtivacaoEmpresaModel>>(solicitacoesAtivacoesEmpresas));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<List<SolicitacaoAtivacaoEmpresaModel>>($"Ocorreu um erro ao obter solicitações de ativação de empresa! {ex.Message}"));
            }
        }

        /// <summary>
        /// Endpoint para ativar uma empresa
        /// </summary>
        /// <param name="service"></param>
        /// <param name="solicitacaoAtivacaoEmpresaId"></param>
        /// <returns></returns>
        [HttpPut("api/solicitacoesativacoesempresas/v1/activatecompany/{solicitacaoAtivacaoEmpresaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync([FromServices] ISolicitacaoAtivacaoEmpresaApplicationService service, Guid solicitacaoAtivacaoEmpresaId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<SolicitacaoAtivacaoEmpresaModel>(ModelState.GetErrors()));

            try
            {
                var solicitacaoAtivacaoEmpresa = await service.AlterarAsync(solicitacaoAtivacaoEmpresaId);
                return Ok(new TaskResult<SolicitacaoAtivacaoEmpresaModel>(solicitacaoAtivacaoEmpresa));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<SolicitacaoAtivacaoEmpresaModel>($"Ocorreu um erro ao alterar solicitação de ativação de empresa! {ex.Message}"));
            }
        }
    }
}