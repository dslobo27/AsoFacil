using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.InfraStructure.Repositories
{
    public class StatusAgendamentoRepository : IStatusAgendamentoRepository
    {
        private readonly Context _context;

        public StatusAgendamentoRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(StatusAgendamento statusAgendamento)
        {
            _context.StatusAgendamentos.Remove(statusAgendamento);
            return await Commit();
        }

        public async Task<IEnumerable<StatusAgendamento>> GetAllAsync(string descricao)
        {
            var query = _context.StatusAgendamentos.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(x => x.Descricao.Contains(descricao));

            return await query.ToListAsync();
        }

        public async Task<StatusAgendamento> GetByIdAsync(Guid statusAgendamentoId)
        {
            return await _context.StatusAgendamentos.FindAsync(statusAgendamentoId);
        }

        public async Task<bool> InsertAsync(StatusAgendamento statusAgendamento)
        {
            _context.StatusAgendamentos.Add(statusAgendamento);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(StatusAgendamento statusAgendamento)
        {
            _context.StatusAgendamentos.Update(statusAgendamento);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}