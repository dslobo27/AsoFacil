using AsoFacil.Models.Candidato;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class CandidatoController : BaseController
    {
        #region Views

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost("candidato/modal")]
        public IActionResult Modal([FromBody] ManterCandidatoViewModel model)
        {
            if (model != null && model.Id != Guid.Empty)
            {
                var candidato = GetByIdAsync(model.Id).Result;
                model.Nome = candidato.Nome;
                model.RG = candidato.RG;
                model.Email = candidato.Email;
                model.OrgaoEmissor = candidato.OrgaoEmissor;
                model.UF = candidato.UF;
                model.CargoId = candidato.Cargo.Id;
                model.EmpresaId = candidato.Empresa.Id;
                model.DataNascimento = candidato.DataNascimento;
            }

            ModelState.Clear();
            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("candidato/getasync")]
        public async Task<IEnumerable<CandidatoViewModel>> GetAsync([FromQuery] string nome, [FromQuery] string rg, [FromQuery] string email)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getasync?nome={nome}&rg={rg}&email={email}", null, TypeRequest.GetAsync, User);
            var candidatos = JsonConvert.DeserializeObject<List<CandidatoViewModel>>(taskResult?.Data.ToString());
            return candidatos;
        }

        [HttpGet("candidato/getbyidasync")]
        public async Task<CandidatoViewModel> GetByIdAsync(Guid candidatoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getbyidasync/{candidatoId}", null, TypeRequest.GetAsync, User);
            var candidato = JsonConvert.DeserializeObject<CandidatoViewModel>(taskResult?.Data.ToString());
            return candidato;
        }

        [HttpPost("candidato/postasync")]
        public async Task<ActionResult> PostAsync([FromBody] ManterCandidatoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/candidatos/v1/postasync", model, TypeRequest.PostAsync, User);
            return Json(taskResult);
        }

        [HttpPut("candidato/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterCandidatoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/putasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }

        [HttpDelete("candidato/deleteasync/{candidatoId}")]
        public async Task<ActionResult> DeleteAsync(Guid candidatoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/deleteasync/{candidatoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion
    }
}
