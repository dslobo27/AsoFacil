using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface ICargoDomainService
    {
        Task<bool> UpdateAsync(Cargo cargo);

        Task<bool> InsertAsync(Cargo cargo);

        Task<bool> DeleteAsync(Cargo cargo);

        Task<IEnumerable<Cargo>> GetAllAsync(string descricao);

        Task<Cargo> GetByIdAsync(Guid cargoId);
    }
}