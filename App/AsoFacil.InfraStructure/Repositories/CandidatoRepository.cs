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
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly Context _context;

        public CandidatoRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Candidato entity)
        {
            _context.Candidatos.Remove(entity);
            return await Commit();
        }

        public async Task<IEnumerable<Candidato>> GetAllAsync(string nome, string rg, string email, Guid empresaId)
        {
            var query = _context.Candidatos
                .Include(a => a.Anamnese)
                    .ThenInclude(m => m.Medico)
                .Include(c => c.Cargo)
                .Include(e => e.Empresa)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.Contains(nome));

            if (!string.IsNullOrEmpty(rg))
                query = query.Where(x => x.RG.Contains(rg));

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email.Contains(email));

            if (empresaId != default)
                query = query.Where(x => x.EmpresaId == empresaId);

            return await query.ToListAsync();
        }

        public async Task<Candidato> GetByIdAsync(Guid id)
        {
            return await _context.Candidatos
                .Include(a => a.Anamnese)
                    .ThenInclude(m => m.Medico)
                .Include(c => c.Cargo)
                .Include(e => e.Empresa)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Anamnese> GetAnamneseByCandidatoIdAsync(Guid id)
        {
            return await _context.Anamneses
                .Include(c => c.Candidato)
                .FirstOrDefaultAsync(x => x.Candidato.Id == id);
        }

        public async Task<Anamnese> GetAnamneseByIdAsync(Guid id)
        {
            return await _context.Anamneses
                .Include(c => c.Candidato)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertAsync(Candidato entity)
        {
            _context.Candidatos.Add(entity);
            return await Commit();
        }

        public async Task<bool> InsertAnamneseAsync(Anamnese entity)
        {
            _context.Anamneses.Add(entity);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(Candidato entity)
        {
            _context.Candidatos.Update(entity);
            return await Commit();
        }

        public async Task<bool> UpdateAnamneseAsync(Anamnese entity)
        {
            _context.Anamneses.Update(entity);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}