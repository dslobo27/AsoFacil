using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface ITipoUsuarioDomainService
    {
        Task<TipoUsuario> GetByCodeAsync(string code);

        Task<TipoUsuario> GetByIdAsync(Guid tipoUsuarioId);

        Task<bool> UpdateAsync(TipoUsuario tipoUsuario);

        Task<bool> InsertAsync(TipoUsuario tipoUsuario);

        Task<bool> DeleteAsync(TipoUsuario tipoUsuario);

        Task<IEnumerable<TipoUsuario>> GetAllAsync(string codigo, string descricao);
    }
}