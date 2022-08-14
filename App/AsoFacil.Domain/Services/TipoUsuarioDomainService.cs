using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class TipoUsuarioDomainService : ITipoUsuarioDomainService
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioDomainService(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        public async Task<bool> DeleteAsync(TipoUsuario tipoUsuario)
        {
            return await _tipoUsuarioRepository.DeleteAsync(tipoUsuario);
        }

        public async Task<IEnumerable<TipoUsuario>> GetAllAsync(string codigo, string descricao)
        {
            return await _tipoUsuarioRepository.GetAllAsync(codigo, descricao);
        }

        public async Task<TipoUsuario> GetByCodeAsync(string code)
        {
            return await _tipoUsuarioRepository.GetByCodeAsync(code);
        }

        public async Task<TipoUsuario> GetByIdAsync(Guid tipoUsuarioId)
        {
            return await _tipoUsuarioRepository.GetByIdAsync(tipoUsuarioId);
        }

        public async Task<bool> InsertAsync(TipoUsuario tipoUsuario)
        {
            return await _tipoUsuarioRepository.InsertAsync(tipoUsuario);
        }

        public async Task<bool> UpdateAsync(TipoUsuario tipoUsuario)
        {
            return await _tipoUsuarioRepository.UpdateAsync(tipoUsuario);
        }
    }
}