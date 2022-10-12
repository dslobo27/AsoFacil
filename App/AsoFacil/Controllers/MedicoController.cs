using AsoFacil.Helpers.Email;
using AsoFacil.Models.Conta;
using AsoFacil.Models.Medico;
using AsoFacil.Models.TipoUsuario;
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
    public class MedicoController : BaseController
    {
        private readonly EmailService _emailService;
        private const string CLINICA_MED = "CLINICA_MED";

        public MedicoController(EmailService emailService)
        {
            _emailService = emailService;
        }

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
                model.EmpresaId = medico.Empresa.Id;
                model.Email = medico.Email;
            }

            ModelState.Clear();
            return PartialView("_Modal", model);
        }

        #endregion

        #region Actions

        [HttpGet("medico/getfordropdownasync")]
        public async Task<IEnumerable<MedicoViewModel>> GetForDropdownAsync()
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/medicos/v1/getfordropdownasync", null, TypeRequest.GetAsync, User);
            var medicos = JsonConvert.DeserializeObject<List<MedicoViewModel>>(taskResult?.Data.ToString());
            return medicos;
        }

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
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/getbycodeasync/{CLINICA_MED}", null, TypeRequest.GetAsync, User);
            var tipoUsuarioViewModel = JsonConvert.DeserializeObject<TipoUsuarioViewModel>(taskResult.Data.ToString());

            var usuarioModel = new CriarUsuarioViewModel
            {
                Login = model.Email,
                Senha = Guid.NewGuid().ToString("N").Substring(0, 8),
                TipoUsuarioId = tipoUsuarioViewModel.Id,
                EmpresaId = model.EmpresaId
            };

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/usuarios/v1/postasync", usuarioModel, TypeRequest.PostAsync, User);            
            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/medicos/v1/postasync", model, TypeRequest.PostAsync, User);

            await EnviarEmailAtivacao(usuarioModel);
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

        private async Task EnviarEmailAtivacao(CriarUsuarioViewModel model)
        {
            var emailRequest = new EmailRequest();

            var sb = new StringBuilder();
            sb.AppendLine("<p>Olá, seja muito bem vindo ao AsoFacil.</p>");
            sb.AppendLine("<p>Acesse a plataforma utilizando os dados abaixo:</p>");
            sb.AppendLine($"<p>Email: <strong>{model.Login}</strong></p>");
            sb.AppendLine($"<p>Senha: <strong>{model.Senha}</strong></p>");

            emailRequest.Assunto = "Cadastro ativado";
            emailRequest.Mensagem = sb.ToString();
            emailRequest.Destinatario = model.Login;

            await _emailService.EnviarEmailAsync(emailRequest);
        }
    }
}