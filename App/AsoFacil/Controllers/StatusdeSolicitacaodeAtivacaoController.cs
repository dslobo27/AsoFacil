using AsoFacil.Models.StatusSolicitacaoAtivacaoEmpresa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class StatusdeSolicitacaodeAtivacaoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("statussolicitacaoativacao/modal")]
        public IActionResult Modal([FromBody] ManterStatusSolicitacaoAtivacaoEmpresaViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var statusSolicitacaoAtivacao = GetByIdAsync(model.Id).Result;
                model.Codigo = statusSolicitacaoAtivacao.Codigo;
                model.Descricao = statusSolicitacaoAtivacao.Descricao;
            }

            return PartialView("_Modal", model);
        }

        #endregion Views

        #region Actions

        [HttpGet("statussolicitacaoativacao/getasync")]
        public async Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresaViewModel>> GetAsync([FromQuery] string codigo, [FromQuery] string descricao)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statussolicitacoesativacoesempresas/v1/getasync?codigo={codigo}&descricao={descricao}", null, TypeRequest.GetAsync, User);
            var statusSolicitacoesAtivacoes = JsonConvert.DeserializeObject<List<StatusSolicitacaoAtivacaoEmpresaViewModel>>(taskResult?.Data.ToString());
            return statusSolicitacoesAtivacoes;
        }

        [HttpGet("statussolicitacaoativacao/getbyidasync")]
        public async Task<StatusSolicitacaoAtivacaoEmpresaViewModel> GetByIdAsync(Guid statusSolicitacaoAtivacaoEmpresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statussolicitacoesativacoesempresas/v1/getbyidasync/{statusSolicitacaoAtivacaoEmpresaId}", null, TypeRequest.GetAsync, User);
            var statusAgendamento = JsonConvert.DeserializeObject<StatusSolicitacaoAtivacaoEmpresaViewModel>(taskResult?.Data.ToString());
            return statusAgendamento;
        }

        [HttpPost("statussolicitacaoativacao/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterStatusSolicitacaoAtivacaoEmpresaViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/statussolicitacoesativacoesempresas/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("statussolicitacaoativacao/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterStatusSolicitacaoAtivacaoEmpresaViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statussolicitacoesativacoesempresas/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("statussolicitacaoativacao/deleteasync/{statusSolicitacaoAtivacaoEmpresaId}")]
        public async Task<ActionResult> DeleteAsync(Guid statusSolicitacaoAtivacaoEmpresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statussolicitacoesativacoesempresas/v1/deleteasync/{statusSolicitacaoAtivacaoEmpresaId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions
    }
}