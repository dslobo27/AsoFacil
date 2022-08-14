using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ITipoUsuarioRepository
    {
        Task<TipoUsuario> GetByCodeAsync(string code);

        Task<bool> DeleteAsync(TipoUsuario tipoUsuario);

        Task<IEnumerable<TipoUsuario>> GetAllAsync(string codigo, string descricao);

        Task<TipoUsuario> GetByIdAsync(Guid tipoUsuarioId);

        Task<bool> InsertAsync(TipoUsuario tipoUsuario);

        Task<bool> UpdateAsync(TipoUsuario tipoUsuario);
    }
}