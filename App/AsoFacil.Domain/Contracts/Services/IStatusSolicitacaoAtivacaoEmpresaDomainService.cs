using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IStatusSolicitacaoAtivacaoEmpresaDomainService
    {
        Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description);

        Task<StatusSolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid statusSolicitacaoAtivacaoEmpresaId);

        Task<bool> UpdateAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);

        Task<bool> InsertAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);

        Task<bool> DeleteAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa);

        Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresa>> GetAllAsync(string codigo, string descricao);
    }
}