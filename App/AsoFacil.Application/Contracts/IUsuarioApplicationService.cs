using AsoFacil.Application.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        Task<IEnumerable<UsuarioModel>> ObterAsync(string email, Guid empresaId);

        Task<UsuarioModel> ObterPorIdAsync(Guid usuarioId);

        Task<bool> AlterarAsync(ManterUsuarioModel model);

        Task<UsuarioModel> Login(string login, string senha);

        Task<bool> CriarAsync(ManterUsuarioModel model);

        Task<bool> ExcluirAsync(Guid usuarioId);
    }
}