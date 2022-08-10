using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.TipoUsuario;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
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

        public async Task<TipoUsuarioModel> ObterPorCodigo(string code)
        {
            var tipoUsuario = await _tipoUsuarioDomainService.GetByCodeAsync(code);
            return ConvertToDto(tipoUsuario);
        }

        #region private

        private TipoUsuarioModel ConvertToDto(TipoUsuario tipoUsuario)
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