using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        Task<Usuario> Login(string login, string senha);
        Task<bool> InsertAsync(Usuario usuario);
    }
}