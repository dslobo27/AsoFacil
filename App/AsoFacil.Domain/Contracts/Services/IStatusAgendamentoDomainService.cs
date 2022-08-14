using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IStatusAgendamentoDomainService
    {
        Task<StatusAgendamento> GetByIdAsync(Guid statusAgendamentoId);

        Task<bool> UpdateAsync(StatusAgendamento statusAgendamento);

        Task<bool> InsertAsync(StatusAgendamento statusAgendamento);

        Task<bool> DeleteAsync(StatusAgendamento statusAgendamento);

        Task<IEnumerable<StatusAgendamento>> GetAllAsync(string descricao);
    }
}