using AsoFacil.Helpers.Email;
using AsoFacil.Models.Conta;
using AsoFacil.Models.SolicitacaoAtivacaoEmpresa;
using AsoFacil.Models.TipoUsuario;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class DashBoardController : BaseController
    {
        private readonly EmailService _emailService;
        private const string EMPRESA_ADMIN = "EMPRESA_ADMIN";


        public DashBoardController(EmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("dashboard/solicitacoesativacoesempresas")]
        public async Task<IEnumerable<SolicitacaoAtivacaoEmpresaViewModel>> GetAsync()
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/solicitacoesativacoesempresas/v1/getasync", null, TypeRequest.GetAsync, User);
            var solicitacoesAtivacoesEmpresas = JsonConvert.DeserializeObject<List<SolicitacaoAtivacaoEmpresaViewModel>>(taskResult?.Data.ToString());
            return solicitacoesAtivacoesEmpresas;
        }

        [HttpPut("dashboard/ativarempresa/{solicitacaoAtivacaoEmpresaId}")]
        public async Task<ActionResult> ActivateCompanyAsync(Guid solicitacaoAtivacaoEmpresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/solicitacoesativacoesempresas/v1/activatecompany/{solicitacaoAtivacaoEmpresaId}", null, TypeRequest.PutAsync, User);
            var solicitacaoAtivacaoEmpresaViewModel = JsonConvert.DeserializeObject<SolicitacaoAtivacaoEmpresaViewModel>(taskResult.Data.ToString());

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi($"/api/tiposusuarios/v1/getbycodeasync/{EMPRESA_ADMIN}", null, TypeRequest.GetAsync, User);
            var tipoUsuarioViewModel = JsonConvert.DeserializeObject<TipoUsuarioViewModel>(taskResult.Data.ToString());

            var model = new CriarUsuarioViewModel
            {
                Login = solicitacaoAtivacaoEmpresaViewModel.EmpresaModel.Email,
                Senha = Guid.NewGuid().ToString("N").Substring(0, 8),
                TipoUsuarioId = tipoUsuarioViewModel.Id,
                EmpresaId = solicitacaoAtivacaoEmpresaViewModel.EmpresaModel.Id
            };

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/usuarios/v1/postasync", model, TypeRequest.PostAsync, User);

            await EnviarEmailAtivacao(model);
            return Json(taskResult);
        }

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