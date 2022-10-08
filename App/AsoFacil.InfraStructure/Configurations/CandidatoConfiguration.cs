using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.RG)
                .HasColumnType("varchar")
                .HasMaxLength(12);

            builder.Property(x => x.UF)
                .HasColumnType("varchar")
                .HasMaxLength(2);

            builder.Property(x => x.OrgaoEmissor)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.DocumentoId).IsRequired(false);
            builder.Property(x => x.AnamneseId).IsRequired(false);
            builder.Property(x => x.CargoId);
            builder.Property(x => x.EmpresaId);

            builder.HasOne(x => x.Cargo)
                .WithMany(x => x.Candidatos)
                .HasForeignKey(x => x.CargoId);

            builder.HasOne(x => x.Documento)
                .WithOne(x => x.Candidato);

            builder.HasOne(x => x.Anamnese)
                .WithOne(x => x.Candidato);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Candidatos)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}