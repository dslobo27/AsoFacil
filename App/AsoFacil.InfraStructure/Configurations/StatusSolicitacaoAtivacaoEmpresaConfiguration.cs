using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class StatusSolicitacaoAtivacaoEmpresaConfiguration : IEntityTypeConfiguration<StatusSolicitacaoAtivacaoEmpresa>
    {
        public void Configure(EntityTypeBuilder<StatusSolicitacaoAtivacaoEmpresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.HasMany(x => x.SolicitacoesAtivacoesEmpresas)
                .WithOne(x => x.StatusSolicitacaoAtivacaoEmpresa)
                .HasForeignKey(x => x.StatusSolicitacaoAtivacaoEmpresaId);
        }
    }
}