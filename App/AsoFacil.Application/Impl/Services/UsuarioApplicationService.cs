using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.TipoUsuario;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
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

        public async Task<bool> CriarAsync(CriarUsuarioModel model)
        {
            var usuario = new Usuario(model.Login, model.Senha, model.TipoUsuarioId, model.EmpresaId);
            return await _usuarioDomainService.InsertAsync(usuario);
        }

        public async Task<UsuarioModel> Login(string login, string senha)
        {
            UsuarioModel model = null;

            var usuario = await _usuarioDomainService.Login(login, senha);

            if (usuario != null)
            {
                model = new UsuarioModel
                {
                    Id = usuario.Id,
                    TipoUsuario = new TipoUsuarioModel
                    {
                        Id = usuario.TipoUsuario.Id,
                        Codigo = usuario.TipoUsuario.Codigo,
                        Descricao = usuario.TipoUsuario.Descricao,
                        MenuSistema = usuario.TipoUsuario.MenuSistema
                    },
                    Empresa = new EmpresaModel
                    {
                        Id = usuario.Empresa.Id,
                        Ativa = usuario.Empresa.Ativa,
                        CNPJ = usuario.Empresa.CNPJ,
                        Email = usuario.Empresa.Email,
                        RazaoSocial = usuario.Empresa.RazaoSocial,
                        SolicitacaoAtivacaoEmpresaId = usuario.Empresa.SolicitacaoAtivacaoEmpresaId
                    }
                };
            }                

            return model;
        }
    }
}