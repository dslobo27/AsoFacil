using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface ISolicitacaoAtivacaoEmpresaRepository
    {
        Task Create(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa);
    }
}