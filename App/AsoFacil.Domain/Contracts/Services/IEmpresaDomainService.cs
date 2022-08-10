using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IEmpresaDomainService
    {
        Task<bool> InsertAsync(Empresa empresa, SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
    }
}