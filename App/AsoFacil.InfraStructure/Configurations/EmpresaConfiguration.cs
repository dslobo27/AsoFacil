using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.CNPJ)
                .HasColumnType("varchar")
                .HasMaxLength(18);

            builder.Property(x => x.RazaoSocial)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.Ativa);
            builder.Property(x => x.SolicitacaoAtivacaoEmpresaId);

            builder.HasOne(x => x.SolicitacaoAtivacaoEmpresa)
                .WithMany(x => x.Empresas)
                .HasForeignKey(x => x.SolicitacaoAtivacaoEmpresaId);

            builder.HasMany(x => x.Candidatos)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}