using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.SolicitacaoAtivacaoEmpresa;
using AsoFacil.Application.Models.StatusSolicitacaoAtivacaoEmpresa;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using AsoFacil.Domain.Enums;
using AsoFacil.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class SolicitacaoAtivacaoEmpresaApplicationService : ISolicitacaoAtivacaoEmpresaApplicationService
    {
        private readonly ISolicitacaoAtivacaoEmpresaDomainService _solicitacaoAtivacaoEmpresaDomainService;
        private readonly IStatusSolicitacaoAtivacaoEmpresaDomainService _statusSolicitacaoAtivacaoEmpresaDomainService;

        public SolicitacaoAtivacaoEmpresaApplicationService(ISolicitacaoAtivacaoEmpresaDomainService solicitacaoAtivacaoEmpresaDomainService, 
            IStatusSolicitacaoAtivacaoEmpresaDomainService statusSolicitacaoAtivacaoEmpresaDomainService)
        {
            _solicitacaoAtivacaoEmpresaDomainService = solicitacaoAtivacaoEmpresaDomainService;
            _statusSolicitacaoAtivacaoEmpresaDomainService = statusSolicitacaoAtivacaoEmpresaDomainService;
        }

        public async Task<List<SolicitacaoAtivacaoEmpresaModel>> ObterParaAtivacaoAsync()
        {
            var solicitacoesAtivacoesEmpresas = await _solicitacaoAtivacaoEmpresaDomainService.GetAllForActivationAsync();
            return ConvertToDto(solicitacoesAtivacoesEmpresas);
        }

        public async Task<SolicitacaoAtivacaoEmpresaModel> AlterarAsync(Guid solicitacaoAtivacaoEmpresaId)
        {
            var solicitacaoAtivacaoEmpresa = await _solicitacaoAtivacaoEmpresaDomainService.GetByIdAsync(solicitacaoAtivacaoEmpresaId);
            var statusSolicitacaoAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByDescription(
                EnumExtensions.GetDescription(StatusSolicitacaoAtivacaoEmpresaEnum.Aprovada));

            solicitacaoAtivacaoEmpresa.SetStatus(statusSolicitacaoAtivacaoEmpresa.Id);
            solicitacaoAtivacaoEmpresa.Empresa.SetAtiva(true);

            await _solicitacaoAtivacaoEmpresaDomainService.UpdateAsync(solicitacaoAtivacaoEmpresa);
            solicitacaoAtivacaoEmpresa.StatusSolicitacaoAtivacaoEmpresa = statusSolicitacaoAtivacaoEmpresa;

            return ConvertToDto(solicitacaoAtivacaoEmpresa);
        }


        #region private

        private static List<SolicitacaoAtivacaoEmpresaModel> ConvertToDto(List<SolicitacaoAtivacaoEmpresa> solicitacoesAtivacoesEmpresas)
        {
            var solicitacoesAtivacoesEmpresasModels = new List<SolicitacaoAtivacaoEmpresaModel>();
            foreach (var s in solicitacoesAtivacoesEmpresas)
            {                
                solicitacoesAtivacoesEmpresasModels.Add(ConvertToDto(s));
            }
            return solicitacoesAtivacoesEmpresasModels;
        }

        private static SolicitacaoAtivacaoEmpresaModel ConvertToDto(SolicitacaoAtivacaoEmpresa s)
        {            
            return new SolicitacaoAtivacaoEmpresaModel
            {
                Id = s.Id,
                EmpresaId = s.EmpresaId,
                StatusSolicitacaoAtivacaoEmpresaId = s.StatusSolicitacaoAtivacaoEmpresaId,
                EmpresaModel = new EmpresaModel
                {
                    Id = s.Empresa.Id,
                    Ativa = s.Empresa.Ativa,
                    CNPJ = s.Empresa.CNPJ,
                    Email = s.Empresa.Email,
                    RazaoSocial = s.Empresa.RazaoSocial,
                    SolicitacaoAtivacaoEmpresaId = s.Empresa.SolicitacaoAtivacaoEmpresaId
                },
                StatusSolicitacaoAtivacaoEmpresaModel = new StatusSolicitacaoAtivacaoEmpresaModel
                {
                    Id = s.StatusSolicitacaoAtivacaoEmpresa.Id,
                    Codigo = s.StatusSolicitacaoAtivacaoEmpresa.Codigo,
                    Descricao = s.StatusSolicitacaoAtivacaoEmpresa.Descricao
                }
            };
        }

        #endregion private
    }
}