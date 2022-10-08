using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(255);
            
            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.CRM)
                .HasColumnType("varchar")
                .HasMaxLength(15);

            builder.Property(x => x.UsuarioId);

            builder.HasMany(x => x.Anamneses)
                .WithOne(x => x.Medico)
                .HasForeignKey(x => x.MedicoId);

            builder.Property(x => x.EmpresaId);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Medicos)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}