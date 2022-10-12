using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsync(string crm, string nome, Guid empresaId);

        Task<Medico> GetByIdAsync(Guid id);

        Task<bool> InsertAsync(Medico entity);

        Task<bool> UpdateAsync(Medico entity);

        Task<bool> DeleteAsync(Medico entity);
    }
}