using AsoFacil.Application.Models.TipoUsuario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ITipoUsuarioApplicationService
    {
        Task<TipoUsuarioModel> ObterPorCodigo(string code);

        Task<IEnumerable<TipoUsuarioModel>> ObterAsync(string codigo, string descricao);

        Task<TipoUsuarioModel> ObterPorIdAsync(Guid tipoUsuarioId);

        Task<bool> AlterarAsync(ManterTipoUsuarioModel model);

        Task<bool> CriarAsync(ManterTipoUsuarioModel model);

        Task<bool> ExcluirAsync(Guid tipoUsuarioId);
    }
}