using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class StatusSolicitacaoAtivacaoEmpresaDomainService : IStatusSolicitacaoAtivacaoEmpresaDomainService
    {
        private readonly IStatusSolicitacaoAtivacaoEmpresaRepository _statusSolicitacaoAtivacaoEmpresaRepository;

        public StatusSolicitacaoAtivacaoEmpresaDomainService(IStatusSolicitacaoAtivacaoEmpresaRepository statusSolicitacaoAtivacaoEmpresaRepository)
        {
            _statusSolicitacaoAtivacaoEmpresaRepository = statusSolicitacaoAtivacaoEmpresaRepository;
        }

        public async Task<bool> DeleteAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.DeleteAsync(statusSolicitacaoAtivacaoEmpresa);
        }

        public async Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresa>> GetAllAsync(string codigo, string descricao)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.GetAllAsync(codigo, descricao);
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.GetByDescription(description);
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid statusSolicitacaoAtivacaoEmpresaId)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.GetByIdAsync(statusSolicitacaoAtivacaoEmpresaId);
        }

        public async Task<bool> InsertAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.InsertAsync(statusSolicitacaoAtivacaoEmpresa);
        }

        public async Task<bool> UpdateAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.UpdateAsync(statusSolicitacaoAtivacaoEmpresa);
        }
    }
}