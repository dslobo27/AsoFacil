using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ICargoRepository
    {
        Task<bool> DeleteAsync(Cargo cargo);

        Task<IEnumerable<Cargo>> GetAllAsync(string descricao);

        Task<Cargo> GetByIdAsync(Guid cargoId);

        Task<bool> InsertAsync(Cargo cargo);

        Task<bool> UpdateAsync(Cargo cargo);
    }
}