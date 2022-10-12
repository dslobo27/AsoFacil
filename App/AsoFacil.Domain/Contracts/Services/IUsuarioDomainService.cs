using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        Task<Usuario> GetByIdAsync(Guid usuarioId);

        Task<bool> UpdateAsync(Usuario usuario);

        Task<bool> DeleteAsync(Usuario usuario);

        Task<IEnumerable<Usuario>> GetAllAsync(string email, Guid empresaId);

        Task<Usuario> Login(string login, string senha);

        Task<bool> InsertAsync(Usuario usuario);
    }
}