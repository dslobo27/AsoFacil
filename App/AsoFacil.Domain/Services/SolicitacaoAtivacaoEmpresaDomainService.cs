using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class SolicitacaoAtivacaoEmpresaDomainService : ISolicitacaoAtivacaoEmpresaDomainService
    {
        private readonly ISolicitacaoAtivacaoEmpresaRepository _solicitacaoAtivacaoEmpresaRepository;

        public SolicitacaoAtivacaoEmpresaDomainService(ISolicitacaoAtivacaoEmpresaRepository solicitacaoAtivacaoEmpresaRepository)
        {
            _solicitacaoAtivacaoEmpresaRepository = solicitacaoAtivacaoEmpresaRepository;
        }

        public async Task<List<SolicitacaoAtivacaoEmpresa>> GetAllForActivationAsync()
        {
            return await _solicitacaoAtivacaoEmpresaRepository.GetAllForActivationAsync();
        }

        public async Task<SolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid solicitacaoAtivacaoEmpresaId)
        {
            return await _solicitacaoAtivacaoEmpresaRepository.GetByIdAsync(solicitacaoAtivacaoEmpresaId);
        }

        public async Task UpdateAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            await _solicitacaoAtivacaoEmpresaRepository.UpdateAsync(solicitacaoAtivacaoEmpresa);
        }
    }
}