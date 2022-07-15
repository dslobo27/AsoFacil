using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class StatusAgendamentoConfiguration : IEntityTypeConfiguration<StatusAgendamento>
    {
        public void Configure(EntityTypeBuilder<StatusAgendamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.HasMany(x => x.Agendamentos)
                .WithOne(x => x.StatusAgendamento)
                .HasForeignKey(x => x.StatusAgendamentoId);
        }
    }
}