using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IEmpresaRepository
    {
        Task<bool> DeleteAsync(Empresa empresa);

        Task<IEnumerable<Empresa>> GetAllAsync(string cnpj, string razaoSocial);

        Task<Empresa> GetByIdAsync(Guid empresaId);

        Task InsertAsync(Empresa empresa);

        Task<bool> UpdateAsync(Empresa empresa);
    }
}