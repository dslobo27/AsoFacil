using AsoFacil.Application.Contracts;
using AsoFacil.Application.Impl.Services;
using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Services;
using AsoFacil.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AsoFacil.IoC
{
    public class DependencyResolver
    {
        public static void Register(IServiceCollection services)
        {
            #region ApplicationServices

            services.AddTransient<IEmpresaApplicationService, EmpresaApplicationService>();

            #endregion ApplicationServices

            #region DomainServices

            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IStatusSolicitacaoAtivacaoEmpresaDomainService, StatusSolicitacaoAtivacaoEmpresaDomainService>();

            #endregion DomainServices

            #region Repositories

            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ISolicitacaoAtivacaoEmpresaRepository, SolicitacaoAtivacaoEmpresaRepository>();
            services.AddTransient<IStatusSolicitacaoAtivacaoEmpresaRepository, StatusSolicitacaoAtivacaoEmpresaRepository>();

            #endregion Repositories
        }
    }
}