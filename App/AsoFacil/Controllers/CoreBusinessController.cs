using AsoFacil.Models.Agendamento;
using AsoFacil.Models.Anamnese;
using AsoFacil.Models.Candidato;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class CoreBusinessController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Anamnese(AnamneseRequest request)
        {
            var (_, taskResult) = await CreateAndMakeAnonymousRequestToApi($"/api/agendamentos/v1/getbyidasync/{request.Agendamento}", null, TypeRequest.GetAsync);
            var agendamentoModel = JsonConvert.DeserializeObject<AgendamentoViewModel>(taskResult?.Data.ToString());

            if (agendamentoModel == null)
                return View("Error");

            (_, taskResult) = await CreateAndMakeAnonymousRequestToApi($"/api/candidatos/v1/getbyidasync/{request.Candidato}", null, TypeRequest.GetAsync);
            var candidatoModel = JsonConvert.DeserializeObject<CandidatoViewModel>(taskResult?.Data.ToString());

            if (agendamentoModel == null)
                return View("Error");

            var anamneseModel = new AnamneseViewModel
            {
                CandidatoId = candidatoModel.Id,
                Candidato = candidatoModel
            };

            return View(anamneseModel);
        }

        [HttpPost("anamnese/postasync")]
        [AllowAnonymous]
        public async Task<ActionResult> PostAsync([FromBody] AnamneseViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAnonymousRequestToApi("/api/candidatos/v1/anamnesepostasync", model, TypeRequest.PostAsync);
            return Json(taskResult);
        }

        [HttpPut("anamnese/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] AnamneseViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/anamneseputasync", model, TypeRequest.PutAsync, User);
            return Json(taskResult);
        }
    }

    [BindProperties]
    public class AnamneseRequest
    {
        public string Candidato { get; set; }
        public string Agendamento { get; set; }
    }
}