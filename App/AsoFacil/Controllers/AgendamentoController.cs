using AsoFacil.Models.Agendamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class AgendamentoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("agendamento/modal")]
        public IActionResult Modal([FromBody] ManterAgendamentoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var agendamento = GetByIdAsync(model.Id).Result;
                model.Data = agendamento.Data;
            }

            return PartialView("_Modal", model);
        }

        #endregion Views

        #region Actions

        [HttpGet("agendamento/getasync")]
        public async Task<IEnumerable<AgendamentoViewModel>> GetAsync([FromQuery] string nome, [FromQuery] string rg, [FromQuery] string dtInicio, [FromQuery] string dtFim)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/getasync?nome={nome}&rg={rg}&dtInicio={dtInicio}&dtFim={dtFim}", null, TypeRequest.GetAsync, User);
            var agendamentos = JsonConvert.DeserializeObject<List<AgendamentoViewModel>>(taskResult?.Data.ToString());
            return agendamentos;
        }

        [HttpGet("agendamento/getbyidasync")]
        public async Task<AgendamentoViewModel> GetByIdAsync(Guid agendamentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/getbyidasync/{agendamentoId}", null, TypeRequest.GetAsync, User);
            var agendamento = JsonConvert.DeserializeObject<AgendamentoViewModel>(taskResult?.Data.ToString());
            return agendamento;
        }

        [HttpPost("agendamento/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterAgendamentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/agendamentos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("agendamento/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterAgendamentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("agendamento/deleteasync/{agendamentoId}")]
        public async Task<ActionResult> DeleteAsync(Guid agendamentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/deleteasync/{agendamentoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions
    }
}