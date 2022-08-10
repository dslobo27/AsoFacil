using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface ITipoUsuarioDomainService
    {
        Task<TipoUsuario> GetByCodeAsync(string code);
    }
}