using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface ISolicitacaoAtivacaoEmpresaDomainService
    {
        Task<List<SolicitacaoAtivacaoEmpresa>> GetAllForActivationAsync();
        Task<SolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid solicitacaoAtivacaoEmpresaId);
        Task UpdateAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
    }
}