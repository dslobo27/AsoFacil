using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AsoFacil.InfraStructure.DataContext
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoConfiguration());
            modelBuilder.ApplyConfiguration(new AnamneseConfiguration());
            modelBuilder.ApplyConfiguration(new CandidatoConfiguration());
            modelBuilder.ApplyConfiguration(new CargoConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentoConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new SolicitacaoAtivacaoEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new StatusAgendamentoConfiguration());
            modelBuilder.ApplyConfiguration(new StatusSolicitacaoAtivacaoEmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoUsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<SolicitacaoAtivacaoEmpresa> SolicitacoesAtivacaoEmpresas { get; set; }
        public DbSet<StatusAgendamento> StatusAgendamentos { get; set; }
        public DbSet<StatusSolicitacaoAtivacaoEmpresa> StatusSolicitacoesAtivacaoEmpresas { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}