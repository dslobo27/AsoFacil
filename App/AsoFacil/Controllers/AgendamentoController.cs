using AsoFacil.Helpers.Email;
using AsoFacil.Models.Agendamento;
using AsoFacil.Models.Candidato;
using AsoFacil.Models.StatusAgendamento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    [Authorize]
    public class AgendamentoController : BaseController
    {
        private readonly EmailService _emailService;

        public AgendamentoController(EmailService emailService)
        {
            _emailService = emailService;
        }

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
                model.DataHora = agendamento.DataHora;
                model.CandidatoId = agendamento.Candidato.Id;
                model.StatusAgendamentoId = agendamento.StatusAgendamento.Id;                
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
            model.Id = Guid.NewGuid();
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/agendamentos/v1/postasync", model, TypeRequest.PostAsync, User);
            
            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getbyidasync/{model.CandidatoId}", null, TypeRequest.GetAsync, User);
            var candidato = JsonConvert.DeserializeObject<CandidatoViewModel>(taskResult?.Data.ToString());

            await EnviarEmailAgendamento(model.DataHora, $"/CoreBusiness/Anamnese?candidato={candidato.Id}&agendamento={model.Id}", candidato.Email);
            return Json(taskResult);
        }

        [HttpPut("agendamento/putasync")]
        public async Task<ActionResult> PutAsync([FromBody] ManterAgendamentoViewModel model)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/putasync", model, TypeRequest.PutAsync, User);

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/candidatos/v1/getbyidasync/{model.CandidatoId}", null, TypeRequest.GetAsync, User);
            var candidato = JsonConvert.DeserializeObject<CandidatoViewModel>(taskResult?.Data.ToString());

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/statusagendamentos/v1/getbyidasync/{model.StatusAgendamentoId}", null, TypeRequest.GetAsync, User);
            var statusAgendamento = JsonConvert.DeserializeObject<StatusAgendamentoViewModel>(taskResult?.Data.ToString());

            await EnviarEmailAlteracaoAgendamento(model.DataHora, candidato.Email, statusAgendamento.Descricao);
            return Json(taskResult);
        }

        [HttpDelete("agendamento/deleteasync/{agendamentoId}")]
        public async Task<ActionResult> DeleteAsync(Guid agendamentoId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/agendamentos/v1/deleteasync/{agendamentoId}", null, TypeRequest.DeleteAsync, User);
            return Json(taskResult);
        }

        #endregion Actions

        private async Task EnviarEmailAgendamento(DateTime data, string url, string email)
        {
            var emailRequest = new EmailRequest();
            var uri = new Uri($"{Config.site_uri}{url}");

            var sb = new StringBuilder();
            sb.AppendLine($"<p>Olá, seu exame foi agendado para {data.ToString("dd/MM/yyyy")} às {data.ToString("HH:mm")}hrs</p>");
            sb.AppendLine($"<p>Acesse o link abaixo e preencha a anamnese.</p>");
            sb.AppendLine($"<p><a href=\"{uri}\">{uri}</a></p>");

            emailRequest.Assunto = "Exame agendado";
            emailRequest.Mensagem = sb.ToString();
            emailRequest.Destinatario = email;

            await _emailService.EnviarEmailAsync(emailRequest);
        }

        private async Task EnviarEmailAlteracaoAgendamento(DateTime data, string email, string status)
        {
            var emailRequest = new EmailRequest();
            
            var sb = new StringBuilder();
            sb.AppendLine($"<p>Olá, seu exame foi alterado.</p>");
            sb.AppendLine($"<p>Data: {data.ToString("dd/MM/yyyy")} às {data.ToString("HH:mm")}hrs</p>");
            sb.AppendLine($"<p>Status: <strong>{status}</strong></p>");

            emailRequest.Assunto = "Exame alterado";
            emailRequest.Mensagem = sb.ToString();
            emailRequest.Destinatario = email;

            await _emailService.EnviarEmailAsync(emailRequest);
        }
    }
}