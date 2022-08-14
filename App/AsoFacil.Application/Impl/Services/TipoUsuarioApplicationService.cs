using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.TipoUsuario;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class TipoUsuarioApplicationService : ITipoUsuarioApplicationService
    {
        private readonly ITipoUsuarioDomainService _tipoUsuarioDomainService;

        public TipoUsuarioApplicationService(ITipoUsuarioDomainService tipoUsuarioDomainService)
        {
            _tipoUsuarioDomainService = tipoUsuarioDomainService;
        }

        public async Task<bool> AlterarAsync(ManterTipoUsuarioModel model)
        {
            var menusSistema = string.Join(";", model.MenuSistema);

            var tipoUsuario = await _tipoUsuarioDomainService.GetByIdAsync(model.Id.Value);
            tipoUsuario.Alterar(model.Codigo, model.Descricao, menusSistema);

            return await _tipoUsuarioDomainService.UpdateAsync(tipoUsuario);
        }

        public async Task<bool> CriarAsync(ManterTipoUsuarioModel model)
        {
            var menusSistema = string.Join(";", model.MenuSistema);

            var tipoUsuario = new TipoUsuario(model.Codigo, model.Descricao, menusSistema);
            return await _tipoUsuarioDomainService.InsertAsync(tipoUsuario);
        }

        public async Task<bool> ExcluirAsync(Guid tipoUsuarioId)
        {
            var tipoUsuario = await _tipoUsuarioDomainService.GetByIdAsync(tipoUsuarioId);
            return await _tipoUsuarioDomainService.DeleteAsync(tipoUsuario);
        }

        public async Task<IEnumerable<TipoUsuarioModel>> ObterAsync(string codigo, string descricao)
        {
            var tiposUsuarios = await _tipoUsuarioDomainService.GetAllAsync(codigo, descricao);
            return ConvertToDto(tiposUsuarios);
        }

        public async Task<TipoUsuarioModel> ObterPorCodigo(string code)
        {
            var tipoUsuario = await _tipoUsuarioDomainService.GetByCodeAsync(code);
            return ConvertToDto(tipoUsuario);
        }

        public async Task<TipoUsuarioModel> ObterPorIdAsync(Guid tipoUsuarioId)
        {
            var tipoUsuario = await _tipoUsuarioDomainService.GetByIdAsync(tipoUsuarioId);
            return ConvertToDto(tipoUsuario);
        }

        #region private

        private static List<TipoUsuarioModel> ConvertToDto(IEnumerable<TipoUsuario> tiposUsuarios)
        {
            var tiposUsuariosModels = new List<TipoUsuarioModel>();
            foreach (var t in tiposUsuarios)
            {
                tiposUsuariosModels.Add(ConvertToDto(t));
            }
            return tiposUsuariosModels;
        }

        private static TipoUsuarioModel ConvertToDto(TipoUsuario tipoUsuario)
        {
            return new TipoUsuarioModel
            {
                Id = tipoUsuario.Id,
                Codigo = tipoUsuario.Codigo,
                Descricao = tipoUsuario.Descricao,
                MenuSistema = tipoUsuario.MenuSistema
            };
        }

        #endregion private
    }
}