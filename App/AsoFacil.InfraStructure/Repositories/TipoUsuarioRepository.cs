using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task<TipoUsuario> GetByCodeAsync(string code)
        {
            return await _context.TiposUsuarios.FirstOrDefaultAsync(x => x.Codigo.Equals(code));
        }
    }
}