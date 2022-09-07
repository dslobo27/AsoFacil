using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IEmpresaDomainService
    {
        Task<Empresa> GetByIdAsync(Guid empresaId);

        Task<bool> UpdateAsync(Empresa empresa);

        Task<bool> DeleteAsync(Empresa empresa);

        Task<IEnumerable<Empresa>> GetAllAsync(string cnpj, string razaoSocial);

        Task<bool> InsertAsync(Empresa empresa, SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
    }
}