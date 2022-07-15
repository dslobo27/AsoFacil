using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Login)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.Senha)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.TipoUsuarioId);
            builder.Property(x => x.EmpresaId);

            builder.HasOne(x => x.TipoUsuario)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.TipoUsuarioId);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}