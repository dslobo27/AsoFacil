using AsoFacil.Application.Models.Usuario;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        Task<UsuarioModel> Login(string login, string senha);
    }
}