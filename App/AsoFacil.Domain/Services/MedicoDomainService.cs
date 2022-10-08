using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class MedicoDomainService : IMedicoDomainService
    {
        private readonly IMedicoRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;

        public MedicoDomainService(IMedicoRepository repository, IUsuarioRepository usuarioRepository)
        {
            _repository = repository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> DeleteAsync(Medico entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Medico>> GetAllAsync(string crm, string nome)
        {
            return await _repository.GetAllAsync(crm, nome);
        }

        public async Task<Medico> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> InsertAsync(Medico entity)
        {
            var usuarioId = await _usuarioRepository.GetByEmailAsync(entity.Email);
            entity.UsuarioId = usuarioId;

            return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(Medico entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}