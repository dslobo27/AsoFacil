using AsoFacil.Application.Models.Empresa;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IEmpresaApplicationService
    {
        Task<bool> CriarAsync(CriarEmpresaModel model);
    }
}