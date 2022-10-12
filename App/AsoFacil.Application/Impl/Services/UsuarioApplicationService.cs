using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.TipoUsuario;
using AsoFacil.Application.Models.Usuario;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<bool> AlterarAsync(ManterUsuarioModel model)
        {
            var usuario = await _usuarioDomainService.GetByIdAsync(model.Id.Value);
            usuario.Alterar(model.Login, model.Senha, model.TipoUsuarioId, model.EmpresaId);

            return await _usuarioDomainService.UpdateAsync(usuario);
        }

        public async Task<bool> CriarAsync(ManterUsuarioModel model)
        {
            var usuario = new Usuario(model.Login, model.Senha, model.TipoUsuarioId, model.EmpresaId);
            return await _usuarioDomainService.InsertAsync(usuario);
        }

        public async Task<bool> ExcluirAsync(Guid usuarioId)
        {
            var usuario = await _usuarioDomainService.GetByIdAsync(usuarioId);
            return await _usuarioDomainService.DeleteAsync(usuario);
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
                        SolicitacaoAtivacaoEmpresaId = usuario.Empresa.SolicitacaoAtivacaoEmpresaId,
                        FlagClinica = usuario.Empresa.FlagClinica
                    }
                };
            }                

            return model;
        }

        public async Task<IEnumerable<UsuarioModel>> ObterAsync(string email, Guid empresaId)
        {
            var usuarios = await _usuarioDomainService.GetAllAsync(email, empresaId);
            return ConvertToDto(usuarios);
        }

        public async Task<UsuarioModel> ObterPorIdAsync(Guid usuarioId)
        {
            var usuario = await _usuarioDomainService.GetByIdAsync(usuarioId);
            return ConvertToDto(usuario);
        }

        #region private

        private static List<UsuarioModel> ConvertToDto(IEnumerable<Usuario> usuarios)
        {
            var usuariosModels = new List<UsuarioModel>();
            foreach (var u in usuarios)
            {
                usuariosModels.Add(ConvertToDto(u));
            }
            return usuariosModels;
        }

        private static UsuarioModel ConvertToDto(Usuario u)
        {
            return new UsuarioModel
            {
                Id = u.Id,      
                Login = u.Login,
                Senha = u.Senha,
                Empresa = new EmpresaModel
                {
                    Id = u.Empresa.Id,
                    Ativa = u.Empresa.Ativa,
                    CNPJ = u.Empresa.CNPJ,
                    Email = u.Empresa.Email,
                    FlagClinica = u.Empresa.FlagClinica,
                    RazaoSocial = u.Empresa.RazaoSocial,
                    SolicitacaoAtivacaoEmpresaId = u.Empresa.SolicitacaoAtivacaoEmpresaId
                },
                TipoUsuario = new TipoUsuarioModel
                {
                    Id = u.TipoUsuario.Id,
                    Codigo = u.TipoUsuario.Codigo,
                    Descricao = u.TipoUsuario.Descricao,
                    MenuSistema = u.TipoUsuario.MenuSistema
                }
            };
        }

        #endregion private
    }
}