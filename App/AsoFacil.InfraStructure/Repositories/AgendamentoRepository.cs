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
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly Context _context;

        public AgendamentoRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Agendamento entity)
        {
            _context.Agendamentos.Remove(entity);
            return await Commit();
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync(string nomeCandidato, string rg, DateTime? dataInicio, DateTime? dataFim, Guid empresaId)
        {
            var query = _context.Agendamentos
                .Include(c => c.Candidato)
                .Include(s => s.StatusAgendamento)
                .Include(e => e.Empresa)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nomeCandidato))
                query = query.Where(x => x.Candidato.Nome.Contains(nomeCandidato));

            if (!string.IsNullOrEmpty(rg))
                query = query.Where(x => x.Candidato.RG.Contains(rg));

            if (dataInicio != null)
                query = query.Where(x => x.DataHora >= dataInicio);

            if (dataFim != null)
                query = query.Where(x => x.DataHora <= dataFim);

            if (empresaId != default)
                query = query.Where(x => x.EmpresaId == empresaId);

            return await query.ToListAsync();
        }

        public async Task<Agendamento> GetByIdAsync(Guid id)
        {
            return await _context.Agendamentos
                .Include(c => c.Candidato)
                .Include(s => s.StatusAgendamento)
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertAsync(Agendamento entity)
        {
            _context.Agendamentos.Add(entity);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(Agendamento entity)
        {
            _context.Agendamentos.Update(entity);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}