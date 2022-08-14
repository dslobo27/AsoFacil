using AsoFacil.Models.StatusAgendamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class StatusdeAgendamentoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("statusagendamento/modal")]
        public IActionResult Modal([FromBody] ManterStatusAgendamentoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var cargo = GetByIdAsync(model.Id).Result;
                model.Descricao = cargo.Descricao;
            }

            return PartialView("_Modal", model);
        }

        #endregion Views

        #region Actions

        [HttpGet("statusagendamento/getasync")]
        public async Task<IEnumerable<StatusAgendamentoViewModel>> GetAsync([FromQuery] string descricao)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statusagendamentos/v1/getasync?descricao={descricao}", null, TypeRequest.GetAsync, User);
            var statusAgendamentos = JsonConvert.DeserializeObject<List<StatusAgendamentoViewModel>>(taskResult?.Data.ToString());
            return statusAgendamentos;
        }

        [HttpGet("statusagendamento/getbyidasync")]
        public async Task<StatusAgendamentoViewModel> GetByIdAsync(Guid statusAgendamentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statusagendamentos/v1/getbyidasync/{statusAgendamentoId}", null, TypeRequest.GetAsync, User);
            var statusAgendamento = JsonConvert.DeserializeObject<StatusAgendamentoViewModel>(taskResult?.Data.ToString());
            return statusAgendamento;
        }

        [HttpPost("statusagendamento/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterStatusAgendamentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/statusagendamentos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("statusagendamento/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterStatusAgendamentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statusagendamentos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("statusagendamento/deleteasync/{statusAgendamentoId}")]
        public async Task<ActionResult> DeleteAsync(Guid statusAgendamentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statusagendamentos/v1/deleteasync/{statusAgendamentoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions
    }
}