using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> GetAllAsync(string nome, string rg, string email);

        Task<Candidato> GetByIdAsync(Guid id);
        Task<Anamnese> GetAnamneseByIdAsync(Guid id);
        Task<Anamnese> GetAnamneseByCandidatoIdAsync(Guid id);

        Task<bool> InsertAsync(Candidato entity);
        Task<bool> InsertAnamneseAsync(Anamnese entity);

        Task<bool> UpdateAsync(Candidato entity);
        Task<bool> UpdateAnamneseAsync(Anamnese entity);

        Task<bool> DeleteAsync(Candidato entity);
    }
}