using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class AgendamentoDomainService : IAgendamentoDomainService
    {
        private readonly IAgendamentoRepository _repository;
        private readonly ICandidatoRepository _candidatoRepository;

        public AgendamentoDomainService(IAgendamentoRepository repository, ICandidatoRepository candidatoRepository)
        {
            _repository = repository;
            _candidatoRepository = candidatoRepository;
        }

        public async Task<bool> DeleteAsync(Agendamento entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync(string nomeCandidato, string rg, DateTime? dataInicio, DateTime? dataFim)
        {
            return await _repository.GetAllAsync(nomeCandidato, rg, dataInicio, dataFim);
        }

        public async Task<Agendamento> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(Agendamento entity)
        {
            var candidato = await _candidatoRepository.GetByIdAsync(entity.CandidatoId);
            entity.EmpresaId = candidato.EmpresaId;
            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Agendamento entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}