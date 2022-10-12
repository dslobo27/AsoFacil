using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> DeleteAsync(Usuario usuario);

        Task<IEnumerable<Usuario>> GetAllAsync(string email, Guid empresaId);

        Task<Usuario> GetByIdAsync(Guid usuarioId);

        Task<Usuario> Login(string login, string senha);

        Task InsertAsync(Usuario usuario);

        Task<bool> UpdateAsync(Usuario usuario);

        Task<Guid> GetByEmailAsync(string email);
    }
}