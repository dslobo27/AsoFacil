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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Context _context;

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            return await Commit();
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(string email, Guid empresaId)
        {
            var query = _context.Usuarios
                .Include(u => u.Empresa)
                .Include(u => u.TipoUsuario)
                .AsQueryable();

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Login.Contains(email));

            if (empresaId != default)
                query = query.Where(x => x.EmpresaId == empresaId);

            return await query.ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid usuarioId)
        {
            return await _context.Usuarios
                .Include(u => u.Empresa)
                .Include(u => u.TipoUsuario)
                .FirstOrDefaultAsync(x => x.Id == usuarioId);
        }

        public async Task<Guid> GetByEmailAsync(string email)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(x => x.Login == email);

            return usuario.Id;
        }

        public async Task InsertAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            return await _context.Usuarios
                .Include(x => x.TipoUsuario)
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Login.Equals(login)
                    && x.Senha.Equals(senha));
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}