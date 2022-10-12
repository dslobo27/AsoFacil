using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using AsoFacil.Domain.Enums;
using AsoFacil.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IEmpresaDomainService _empresaDomainService;
        private readonly IStatusSolicitacaoAtivacaoEmpresaDomainService _statusSolicitacaoAtivacaoEmpresaDomainService;

        public EmpresaApplicationService(IEmpresaDomainService empresaDomainService, IStatusSolicitacaoAtivacaoEmpresaDomainService statusSolicitacaoAtivacaoEmpresaDomainService)
        {
            _empresaDomainService = empresaDomainService;
            _statusSolicitacaoAtivacaoEmpresaDomainService = statusSolicitacaoAtivacaoEmpresaDomainService;
        }

        public async Task<bool> AlterarAsync(ManterEmpresaModel model)
        {
            var empresa = await _empresaDomainService.GetByIdAsync(model.Id.Value);
            empresa.Alterar(model.CNPJ, model.RazaoSocial, model.Email, model.FlagClinica, model.Ativa);

            return await _empresaDomainService.UpdateAsync(empresa);
        }

        public async Task<bool> CriarAsync(ManterEmpresaModel model)
        {
            var empresa = new Empresa(model.CNPJ, model.RazaoSocial, model.Email, model.FlagClinica);
            empresa.SetAtiva(model.Ativa);

            var statusSolicitacaoAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByDescription(
                EnumExtensions.GetDescription(model.Ativa ? StatusSolicitacaoAtivacaoEmpresaEnum.Aprovada : StatusSolicitacaoAtivacaoEmpresaEnum.Solicitada));

            var solicitacaoAtivacaoEmpresa = new SolicitacaoAtivacaoEmpresa(empresa.Id, statusSolicitacaoAtivacaoEmpresa.Id);

            empresa.SetSolicitacaoAtivacaoEmpresa(solicitacaoAtivacaoEmpresa);

            return await _empresaDomainService.InsertAsync(empresa, solicitacaoAtivacaoEmpresa);
        }

        public async Task<bool> ExcluirAsync(Guid empresaId)
        {
            var empresa = await _empresaDomainService.GetByIdAsync(empresaId);
            return await _empresaDomainService.DeleteAsync(empresa);
        }

        public async Task<IEnumerable<EmpresaModel>> ObterAsync(string cnpj, string razaoSocial, Guid empresaId)
        {
            var empresas = await _empresaDomainService.GetAllAsync(cnpj, razaoSocial, empresaId);
            return ConvertToDto(empresas);
        }

        public async Task<EmpresaModel> ObterPorIdAsync(Guid empresaId)
        {
            var empresa = await _empresaDomainService.GetByIdAsync(empresaId);
            return ConvertToDto(empresa);
        }

        #region private

        private static List<EmpresaModel> ConvertToDto(IEnumerable<Empresa> empresas)
        {
            var empresasModels = new List<EmpresaModel>();
            foreach (var e in empresas)
            {
                empresasModels.Add(ConvertToDto(e));
            }
            return empresasModels;
        }

        private static EmpresaModel ConvertToDto(Empresa e)
        {
            return new EmpresaModel
            {
                Id = e.Id,
                CNPJ = e.CNPJ,
                RazaoSocial = e.RazaoSocial,
                Email = e.Email,
                Ativa = e.Ativa,
                SolicitacaoAtivacaoEmpresaId = e.SolicitacaoAtivacaoEmpresaId,
                FlagClinica = e.FlagClinica
            };
        }

        #endregion private
    }
}