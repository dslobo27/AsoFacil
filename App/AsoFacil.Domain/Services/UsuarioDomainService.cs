using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
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

        public async Task<bool> InsertAsync(Usuario usuario)
        {
            await _usuarioRepository.InsertAsync(usuario);
            return true;
        }

        public async Task<Usuario> Login(string login, string senha)
        {
            return await _usuarioRepository.Login(login, senha);
        }
    }
}