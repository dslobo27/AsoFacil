using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IStatusSolicitacaoAtivacaoEmpresaRepository
    {
        Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description);

        Task<bool> DeleteAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);

        Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresa>> GetAllAsync(string codigo, string descricao);

        Task<StatusSolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid statusSolicitacaoAtivacaoEmpresaId);

        Task<bool> InsertAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);

        Task<bool> UpdateAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);
    }
}