using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IStatusSolicitacaoAtivacaoEmpresaRepository
    {
        Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description);
    }
}