using AsoFacil.Models.Medico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class MedicoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("medico/modal")]
        public IActionResult Modal([FromBody] ManterMedicoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var medico = GetByIdAsync(model.Id).Result;
                model.CRM = medico.CRM;
                model.Nome = medico.Nome;
            }

            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("medico/getasync")]
        public async Task<IEnumerable<MedicoViewModel>> GetAsync([FromQuery] string crm, [FromQuery] string nome)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/medicos/v1/getasync?crm={crm}&nome={nome}", null, TypeRequest.GetAsync, User);
            var medicos = JsonConvert.DeserializeObject<List<MedicoViewModel>>(taskResult?.Data.ToString());
            return medicos;
        }

        [HttpGet("medico/getbyidasync")]
        public async Task<MedicoViewModel> GetByIdAsync(Guid medicoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/medicos/v1/getbyidasync/{medicoId}", null, TypeRequest.GetAsync, User);
            var medico = JsonConvert.DeserializeObject<MedicoViewModel>(taskResult?.Data.ToString());
            return medico;
        }

        [HttpPost("medico/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterMedicoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/medicos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("medico/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterMedicoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/medicos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("medico/deleteasync/{medicoId}")]
        public async Task<ActionResult> DeleteAsync(Guid medicoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/medicos/v1/deleteasync/{medicoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion
    }
}