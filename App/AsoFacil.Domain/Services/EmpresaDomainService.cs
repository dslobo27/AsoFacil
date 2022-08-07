using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace AsoFacil.Domain.Services
{
    public class EmpresaDomainService : IEmpresaDomainService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ISolicitacaoAtivacaoEmpresaRepository _solicitacaoAtivacaoEmpresaRepository;

        public EmpresaDomainService(IEmpresaRepository empresaRepository,
            ISolicitacaoAtivacaoEmpresaRepository solicitacaoAtivacaoEmpresaRepository)
        {
            _empresaRepository = empresaRepository;
            _solicitacaoAtivacaoEmpresaRepository = solicitacaoAtivacaoEmpresaRepository;
        }

        public async Task<bool> CreateAsync(Empresa empresa, SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _solicitacaoAtivacaoEmpresaRepository.Create(solicitacaoAtivacaoEmpresa)
                        .ConfigureAwait(false);

                    empresa.SolicitacaoAtivacaoEmpresa = null;

                    await _empresaRepository.Create(empresa)
                        .ConfigureAwait(false);                    

                    scope.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}