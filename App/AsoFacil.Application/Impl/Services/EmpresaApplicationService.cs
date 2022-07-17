using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using AsoFacil.Domain.Enums;
using AsoFacil.Domain.Extensions;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class EmpresaApplicationService : IEmpresaApplicationService
    {
        private readonly IEmpresaDomainService _empresaDomainService;
        private readonly IStatusSolicitacaoAtivacaoEmpresaDomainService _statusSolicitacaoAtivacaoEmpresaDomainService;

        public EmpresaApplicationService(IEmpresaDomainService empresaDomainService, IStatusSolicitacaoAtivacaoEmpresaDomainService statusSolicitacaoAtivacaoEmpresaDomainService)
        {
            _empresaDomainService = empresaDomainService;
            _statusSolicitacaoAtivacaoEmpresaDomainService = statusSolicitacaoAtivacaoEmpresaDomainService;
        }

        public async Task<bool> CriarAsync(CriarEmpresaModel model)
        {
            var empresa = new Empresa(model.CNPJ, model.RazaoSocial, model.Email);
            empresa.SetAtiva(false);

            var statusSolicitacaoAtivacaoEmpresa = await _statusSolicitacaoAtivacaoEmpresaDomainService.GetByDescription(
                EnumExtensions.GetDescription(StatusSolicitacaoAtivacaoEmpresaEnum.Solicitada));

            var solicitacaoAtivacaoEmpresa = new SolicitacaoAtivacaoEmpresa(empresa.Id, statusSolicitacaoAtivacaoEmpresa.Id);

            return await _empresaDomainService.CreateAsync(empresa, solicitacaoAtivacaoEmpresa);
        }
    }
}