using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class StatusSolicitacaoAtivacaoEmpresaDomainService : IStatusSolicitacaoAtivacaoEmpresaDomainService
    {
        private readonly IStatusSolicitacaoAtivacaoEmpresaRepository _statusSolicitacaoAtivacaoEmpresaRepository;

        public StatusSolicitacaoAtivacaoEmpresaDomainService(IStatusSolicitacaoAtivacaoEmpresaRepository statusSolicitacaoAtivacaoEmpresaRepository)
        {
            _statusSolicitacaoAtivacaoEmpresaRepository = statusSolicitacaoAtivacaoEmpresaRepository;
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description)
        {
            return await _statusSolicitacaoAtivacaoEmpresaRepository.GetByDescription(description);
        }
    }
}