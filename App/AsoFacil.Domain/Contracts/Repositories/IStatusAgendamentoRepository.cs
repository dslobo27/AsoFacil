using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IStatusAgendamentoRepository
    {
        Task<bool> DeleteAsync(StatusAgendamento statusAgendamento);

        Task<IEnumerable<StatusAgendamento>> GetAllAsync(string descricao);

        Task<StatusAgendamento> GetByIdAsync(Guid statusAgendamentoId);

        Task<bool> InsertAsync(StatusAgendamento statusAgendamento);

        Task<bool> UpdateAsync(StatusAgendamento statusAgendamento);
    }
}