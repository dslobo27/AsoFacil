using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Login(string login, string senha);
    }
}