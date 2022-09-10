using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class CandidatoDomainService : ICandidatoDomainService
    {
        private readonly ICandidatoRepository _repository;

        public CandidatoDomainService(ICandidatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAsync(Candidato entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Candidato>> GetAllAsync(string nome, string rg, string email)
        {
            return await _repository.GetAllAsync(nome, rg, email);
        }

        public async Task<Candidato> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(Candidato entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Candidato entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}