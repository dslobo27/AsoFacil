using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class AgendamentoConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.DataHora);

            builder.Property(x => x.EmpresaId)
                .IsRequired();

            builder.Property(x => x.CandidatoId)
                .IsRequired();

            builder.Property(x => x.StatusAgendamentoId)
                .IsRequired();

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.EmpresaId);

            builder.HasOne(x => x.Candidato)
                .WithOne(x => x.Agendamento);

            builder.HasOne(x => x.StatusAgendamento)
                .WithMany(x => x.Agendamentos)
                .HasForeignKey(x => x.StatusAgendamentoId);
        }
    }
}