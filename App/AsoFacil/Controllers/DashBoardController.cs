using AsoFacil.Models.Conta;
using AsoFacil.Models.Empresa;
using AsoFacil.Models.SolicitacaoAtivacaoEmpresa;
using AsoFacil.Models.TipoUsuario;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Controllers
{
    public class DashBoardController : BaseController
    {
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
        public async Task ActivateCompanyAsync(Guid solicitacaoAtivacaoEmpresaId)
        {
            var (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/solicitacoesativacoesempresas/v1/activatecompany", solicitacaoAtivacaoEmpresaId, TypeRequest.PutAsync, User);
            var solicitacaoAtivacaoEmpresaViewModel = JsonConvert.DeserializeObject<SolicitacaoAtivacaoEmpresaViewModel>(taskResult.Data.ToString());

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/tiposusuarios/v1/getbycodeasync", "EMPRESA_ADMIN", TypeRequest.GetAsync, User);
            var tipoUsuarioViewModel = JsonConvert.DeserializeObject<TipoUsuarioViewModel>(taskResult.Data.ToString());

            var model = new CriarUsuarioViewModel
            {
                Login = solicitacaoAtivacaoEmpresaViewModel.EmpresaModel.Email,
                Senha = Guid.NewGuid().ToString("N").Substring(0, 8),
                TipoUsuarioId = tipoUsuarioViewModel.Id,
                EmpresaId = solicitacaoAtivacaoEmpresaViewModel.EmpresaModel.Id
            };

            (_, taskResult) = await CreateAndMakeAuthenticatedRequestToApi("/api/usuarios/v1/postasync", model, TypeRequest.PostAsync, User);            
        }
    }
}