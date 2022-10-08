using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.InfraStructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly Context _context;

        public MedicoRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Medico entity)
        {
            _context.Medicos.Remove(entity);
            return await Commit();
        }

        public async Task<IEnumerable<Medico>> GetAllAsync(string crm, string nome)
        {
            var query = _context.Medicos.Include(x => x.Empresa).AsQueryable();

            if (!string.IsNullOrEmpty(crm))
                query = query.Where(x => x.CRM.Contains(crm));

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(x => x.Nome.Contains(nome));

            return await query.ToListAsync();
        }

        public async Task<Medico> GetByIdAsync(Guid id)
        {
            return await _context.Medicos.Include(x => x.Empresa).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> InsertAsync(Medico entity)
        {
            _context.Medicos.Add(entity);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(Medico entity)
        {
            _context.Medicos.Update(entity);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
