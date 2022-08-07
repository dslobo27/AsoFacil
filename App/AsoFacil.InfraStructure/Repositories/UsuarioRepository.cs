using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Usuario> Login(string login, string senha)
        {
            return await _context.Usuarios
                .Include(x => x.TipoUsuario)
                .Include(x => x.Empresa)
                .FirstOrDefaultAsync(x => x.Login.Equals(login)
                    && x.Senha.Equals(senha));
        }
    }
}