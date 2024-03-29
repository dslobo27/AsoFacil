﻿using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IAgendamentoRepository
    {
        Task<IEnumerable<Agendamento>> GetAllAsync(string nomeCandidato, string rg, DateTime? dataInicio, DateTime? dataFim, Guid empresaId);

        Task<Agendamento> GetByIdAsync(Guid id);

        Task<bool> InsertAsync(Agendamento entity);

        Task<bool> UpdateAsync(Agendamento entity);

        Task<bool> DeleteAsync(Agendamento entity);
    }
}