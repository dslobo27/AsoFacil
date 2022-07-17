using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Domain.Contracts.Services;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuarioApplicationService(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        public async Task<UsuarioModel> Login(string login, string senha)
        {
            var model = new UsuarioModel();
            var usuario = await _usuarioDomainService.Login(login, senha);

            if (usuario != null)
                model.Id = usuario.Id;

            return model;
        }
    }
}