using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<TipoUsuario> GetByCodeAsync(string code);
    }
}