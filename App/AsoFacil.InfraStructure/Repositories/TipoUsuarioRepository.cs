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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Context _context;

        public TipoUsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(TipoUsuario tipoUsuario)
        {
            _context.TiposUsuarios.Remove(tipoUsuario);
            return await Commit();
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync(string codigo, string descricao)
        {
            var query = _context.TiposUsuarios.AsQueryable();

            if (!string.IsNullOrEmpty(codigo))
                query = query.Where(x => x.Codigo.Contains(codigo));

            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(x => x.Descricao.Contains(descricao));

            return await query.ToListAsync();
        }

        public async Task<TipoUsuario> GetByCodeAsync(string code)
        {
            return await _context.TiposUsuarios.FirstOrDefaultAsync(x => x.Codigo.Equals(code));
        }

        public async Task<TipoUsuario> GetByIdAsync(Guid tipoUsuarioId)
        {
            return await _context.TiposUsuarios.FindAsync(tipoUsuarioId);
        }

        public async Task<bool> InsertAsync(TipoUsuario tipoUsuario)
        {
            _context.TiposUsuarios.Add(tipoUsuario);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(TipoUsuario tipoUsuario)
        {
            _context.TiposUsuarios.Update(tipoUsuario);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}