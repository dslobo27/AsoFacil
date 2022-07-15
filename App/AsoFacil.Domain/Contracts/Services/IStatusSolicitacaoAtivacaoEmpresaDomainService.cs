using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Services
{
    public interface IStatusSolicitacaoAtivacaoEmpresaDomainService
    {
        Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description);
    }
}