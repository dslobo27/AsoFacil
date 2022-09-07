using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
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

        public async Task<bool> DeleteAsync(Empresa empresa)
        {
            return await _empresaRepository.DeleteAsync(empresa);
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync(string cnpj, string razaoSocial)
        {
            return await _empresaRepository.GetAllAsync(cnpj, razaoSocial);
        }

        public async Task<Empresa> GetByIdAsync(Guid empresaId)
        {
            return await _empresaRepository.GetByIdAsync(empresaId);
        }

        public async Task<bool> InsertAsync(Empresa empresa, SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _solicitacaoAtivacaoEmpresaRepository.InsertAsync(solicitacaoAtivacaoEmpresa)
                        .ConfigureAwait(false);

                    empresa.SolicitacoesAtivacaoEmpresa = null;

                    await _empresaRepository.InsertAsync(empresa)
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

        public async Task<bool> UpdateAsync(Empresa empresa)
        {
            return await _empresaRepository.UpdateAsync(empresa);
        }
    }
}