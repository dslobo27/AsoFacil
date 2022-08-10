using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
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

        public async Task<TipoUsuario> GetByCodeAsync(string code)
        {
            return await _tipoUsuarioRepository.GetByCodeAsync(code);
        }
    }
}