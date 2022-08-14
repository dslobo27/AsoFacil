using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class StatusAgendamentoDomainService : IStatusAgendamentoDomainService
    {
        private readonly IStatusAgendamentoRepository _statusAgendamentoRepository;

        public StatusAgendamentoDomainService(IStatusAgendamentoRepository statusAgendamentoRepository)
        {
            _statusAgendamentoRepository = statusAgendamentoRepository;
        }

        public async Task<bool> DeleteAsync(StatusAgendamento statusAgendamento)
        {
            return await _statusAgendamentoRepository.DeleteAsync(statusAgendamento);
        }

        public async Task<IEnumerable<StatusAgendamento>> GetAllAsync(string descricao)
        {
            return await _statusAgendamentoRepository.GetAllAsync(descricao);
        }

        public async Task<StatusAgendamento> GetByIdAsync(Guid statusAgendamentoId)
        {
            return await _statusAgendamentoRepository.GetByIdAsync(statusAgendamentoId);
        }

        public async Task<bool> InsertAsync(StatusAgendamento statusAgendamento)
        {
            return await _statusAgendamentoRepository.InsertAsync(statusAgendamento);
        }

        public async Task<bool> UpdateAsync(StatusAgendamento statusAgendamento)
        {
            return await _statusAgendamentoRepository.UpdateAsync(statusAgendamento);
        }
    }
}