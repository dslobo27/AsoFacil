using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> DeleteAsync(Usuario usuario)
        {
            return await _usuarioRepository.DeleteAsync(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync(string email, Guid empresaId)
        {
            return await _usuarioRepository.GetAllAsync(email, empresaId);
        }

        public async Task<Usuario> GetByIdAsync(Guid usuarioId)
        {
            return await _usuarioRepository.GetByIdAsync(usuarioId);
        }

        public async Task<bool> InsertAsync(Usuario usuario)
        {
            await _usuarioRepository.InsertAsync(usuario);
            return true;
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            return await _usuarioRepository.Login(login, senha);
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            return await _usuarioRepository.UpdateAsync(usuario);
        }
    }
}