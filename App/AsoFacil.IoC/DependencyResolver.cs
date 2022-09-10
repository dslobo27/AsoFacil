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
            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            services.AddTransient<ISolicitacaoAtivacaoEmpresaApplicationService, SolicitacaoAtivacaoEmpresaApplicationService>();
            services.AddTransient<ITipoUsuarioApplicationService, TipoUsuarioApplicationService>();
            services.AddTransient<ICargoApplicationService, CargoApplicationService>();
            services.AddTransient<IStatusAgendamentoApplicationService, StatusAgendamentoApplicationService>();
            services.AddTransient<IStatusSolicitacaoAtivacaoEmpresaApplicationService, StatusSolicitacaoAtivacaoEmpresaApplicationService>();
            services.AddTransient<ICandidatoApplicationService, CandidatoApplicationService>();
            services.AddTransient<IMedicoApplicationService, MedicoApplicationService>();
            services.AddTransient<IAgendamentoApplicationService, AgendamentoApplicationService>();

            #endregion ApplicationServices

            #region DomainServices

            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IEmpresaDomainService, EmpresaDomainService>();
            services.AddTransient<IStatusSolicitacaoAtivacaoEmpresaDomainService, StatusSolicitacaoAtivacaoEmpresaDomainService>();
            services.AddTransient<ISolicitacaoAtivacaoEmpresaDomainService, SolicitacaoAtivacaoEmpresaDomainService>();
            services.AddTransient<ITipoUsuarioDomainService, TipoUsuarioDomainService>();
            services.AddTransient<ICargoDomainService, CargoDomainService>();
            services.AddTransient<IStatusAgendamentoDomainService, StatusAgendamentoDomainService>();
            services.AddTransient<ICandidatoDomainService, CandidatoDomainService>();
            services.AddTransient<IMedicoDomainService, MedicoDomainService>();
            services.AddTransient<IAgendamentoDomainService, AgendamentoDomainService>();

            #endregion DomainServices

            #region Repositories

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ISolicitacaoAtivacaoEmpresaRepository, SolicitacaoAtivacaoEmpresaRepository>();
            services.AddTransient<IStatusSolicitacaoAtivacaoEmpresaRepository, StatusSolicitacaoAtivacaoEmpresaRepository>();
            services.AddTransient<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddTransient<ICargoRepository, CargoRepository>();
            services.AddTransient<IStatusAgendamentoRepository, StatusAgendamentoRepository>();
            services.AddTransient<ICandidatoRepository, CandidatoRepository>();
            services.AddTransient<IMedicoRepository, MedicoRepository>();
            services.AddTransient<IAgendamentoRepository, AgendamentoRepository>();

            #endregion Repositories
        }
    }
}