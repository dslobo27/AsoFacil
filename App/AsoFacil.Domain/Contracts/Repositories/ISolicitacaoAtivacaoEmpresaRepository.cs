using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ISolicitacaoAtivacaoEmpresaRepository
    {
        Task InsertAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
        Task<List<SolicitacaoAtivacaoEmpresa>> GetAllForActivationAsync();
        Task<SolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid solicitacaoAtivacaoEmpresaId);
        Task UpdateAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
    }
}