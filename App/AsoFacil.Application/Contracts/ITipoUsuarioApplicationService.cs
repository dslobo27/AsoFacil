using AsoFacil.Application.Models.TipoUsuario;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ITipoUsuarioApplicationService
    {
        Task<TipoUsuarioModel> ObterPorCodigo(string code);
    }
}