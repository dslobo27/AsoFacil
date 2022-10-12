using AsoFacil.Application.Contracts;
using AsoFacil.Application.Extensions;
using AsoFacil.Application.Models.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    public class TotalizadoresController : Controller
    {
        /// <summary>
        /// Endpoint para obter os totalizadores
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpGet("api/totalizadores/v1/getasync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromServices] IEmpresaApplicationService empresaService,
                                                  [FromServices] ICandidatoApplicationService candidatoService,
                                                  [FromServices] IAgendamentoApplicationService agendamentoService,
                                                  [FromServices] ISolicitacaoAtivacaoEmpresaApplicationService solicitacaoAtivacaoEmpresaService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new TaskResult<TotalizadoresModel>(ModelState.GetErrors()));

            try
            {
                var empresas = await empresaService.ObterAsync(string.Empty, string.Empty, Guid.Empty);
                var candidatos = await candidatoService.ObterAsync(string.Empty, string.Empty, string.Empty, Guid.Empty);
                var agendamentos = await agendamentoService.ObterAsync(string.Empty, string.Empty, null, null, Guid.Empty);
                var solicitacoesAtivacoesEmpresas = await solicitacaoAtivacaoEmpresaService.ObterParaAtivacaoAsync();

                var totalizador = new TotalizadoresModel
                {
                    TotalAgendamentos = agendamentos.Count(),
                    TotalCandidatos = candidatos.Count(),
                    TotalEmpresas = empresas.Count(),
                    TotalSolicitacoes = solicitacoesAtivacoesEmpresas.Count()
                };

                return Ok(new TaskResult<TotalizadoresModel>(totalizador));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new TaskResult<TotalizadoresModel>($"Ocorreu um erro ao obter totalizadores! {ex.Message}"));
            }
        }
    }
}
