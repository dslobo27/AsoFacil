using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class SolicitacaoAtivacaoEmpresaConfiguration : IEntityTypeConfiguration<SolicitacaoAtivacaoEmpresa>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoAtivacaoEmpresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.EmpresaId);
            builder.Property(x => x.StatusSolicitacaoAtivacaoEmpresaId);

            builder.HasMany(x => x.Empresas)
                .WithOne(x => x.SolicitacaoAtivacaoEmpresa)
                .HasForeignKey(x => x.SolicitacaoAtivacaoEmpresaId);

            builder.HasOne(x => x.StatusSolicitacaoAtivacaoEmpresa)
                .WithMany(x => x.SolicitacoesAtivacoesEmpresas)
                .HasForeignKey(x => x.StatusSolicitacaoAtivacaoEmpresaId);
        }
    }
}