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

        public async Task<IEnumerable<Candidato>> GetAllAsync(string nome, string rg, string email, Guid empresaId)
        {
            return await _repository.GetAllAsync(nome, rg, email, empresaId);
        }

        public async Task<Candidato> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Anamnese> GetAnamneseByIdAsync(Guid id)
        {
            return await _repository.GetAnamneseByIdAsync(id);
        }

        public async Task<Anamnese> GetAnamneseByCandidatoIdAsync(Guid id)
        {
            return await _repository.GetAnamneseByCandidatoIdAsync(id);
        }

        public async Task<bool> InsertAsync(Candidato entity)
        {
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> InsertAnamneseAsync(Anamnese entity, Guid candidatoId)
        {
            entity.Id = Guid.NewGuid();
            var candidato = await _repository.GetByIdAsync(candidatoId);
            candidato.AnamneseId = entity.Id;

            await _repository.InsertAnamneseAsync(entity);

            return await _repository.UpdateAsync(candidato);
        }

        public async Task<bool> UpdateAsync(Candidato entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> UpdateAnamneseAsync(Anamnese entity)
        {
            return await _repository.UpdateAnamneseAsync(entity);
        }
    }
}