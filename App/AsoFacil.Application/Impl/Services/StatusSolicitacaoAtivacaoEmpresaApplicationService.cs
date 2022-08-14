using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.StatusSolicitacaoAtivacaoEmpresa;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class StatusSolicitacaoAtivacaoEmpresaApplicationService : IStatusSolicitacaoAtivacaoEmpresaApplicationService
    {
        private readonly IStatusSolicitacaoAtivacaoEmpresaDomainService _statusSolicitacaoAtivacaoEmpresaDomainService;

        public StatusSolicitacaoAtivacaoEmpresaApplicationService(IStatusSolicitacaoAtivacaoEmpresaDomainService statusSolicitacaoAtivacaoEmpresaDomainService)
        {
            _statusSolicitacaoAtivacaoEmpresaDomainService = statusSolicitacaoAtivacaoEmpresaDomainService;
        }

        public async Task<bool> AlterarAsync(ManterStatusSolicitacaoAtivacaoEmpresaModel model)
        {
            var statusSolicitacaoAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByIdAsync(model.Id.Value);
            statusSolicitacaoAtivacaoEmpresa.Alterar(model.Codigo, model.Descricao);

            return await _statusSolicitacaoAtivacaoEmpresaDomainService.UpdateAsync(statusSolicitacaoAtivacaoEmpresa);
        }

        public async Task<bool> CriarAsync(ManterStatusSolicitacaoAtivacaoEmpresaModel model)
        {
            var statusSolicitacaoAtivacaoEmpresa = new StatusSolicitacaoAtivacaoEmpresa(model.Codigo, model.Descricao);
            return await _statusSolicitacaoAtivacaoEmpresaDomainService.InsertAsync(statusSolicitacaoAtivacaoEmpresa);
        }

        public async Task<bool> ExcluirAsync(Guid statusSolicitacaoAgendamentoId)
        {
            var statusSolicitacaoAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByIdAsync(statusSolicitacaoAgendamentoId);
            return await _statusSolicitacaoAtivacaoEmpresaDomainService.DeleteAsync(statusSolicitacaoAtivacaoEmpresa);
        }

        public async Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresaModel>> ObterAsync(string codigo, string descricao)
        {
            var statusSolicitacoesAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetAllAsync(codigo, descricao);
            return ConvertToDto(statusSolicitacoesAtivacaoEmpresa);
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresaModel> ObterPorIdAsync(Guid statusSolicitacaoAgendamentoId)
        {
            var statusSolicitacaoAgendamento = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByIdAsync(statusSolicitacaoAgendamentoId);
            return ConvertToDto(statusSolicitacaoAgendamento);
        }

        #region private

        private static List<StatusSolicitacaoAtivacaoEmpresaModel> ConvertToDto(IEnumerable<StatusSolicitacaoAtivacaoEmpresa> statusSolicitacoesAtivacaoEmpresa)
        {
            var statusSolicitacoesAtivacaoEmpresaModels = new List<StatusSolicitacaoAtivacaoEmpresaModel>();
            foreach (var s in statusSolicitacoesAtivacaoEmpresa)
            {
                statusSolicitacoesAtivacaoEmpresaModels.Add(ConvertToDto(s));
            }
            return statusSolicitacoesAtivacaoEmpresaModels;
        }

        private static StatusSolicitacaoAtivacaoEmpresaModel ConvertToDto(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            return new StatusSolicitacaoAtivacaoEmpresaModel
            {
                Id = statusSolicitacaoAtivacaoEmpresa.Id,
                Codigo = statusSolicitacaoAtivacaoEmpresa.Codigo,
                Descricao = statusSolicitacaoAtivacaoEmpresa.Descricao
            };
        }

        #endregion private
    }
}