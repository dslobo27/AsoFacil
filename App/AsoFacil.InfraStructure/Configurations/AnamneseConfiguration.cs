using AsoFacil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AsoFacil.InfraStructure.Configurations
{
    public class AnamneseConfiguration : IEntityTypeConfiguration<Anamnese>
    {
        public void Configure(EntityTypeBuilder<Anamnese> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder.Property(x => x.PossuiDoencaCoracao);
            builder.Property(x => x.PossuiDoencaCoracao);
            builder.Property(x => x.ApresentaProblemaPsiquiatrico);
            builder.Property(x => x.ApresentaQuadroAnsiedade);
            builder.Property(x => x.ApresentaQuadroDepressao);
            builder.Property(x => x.ApresentaQuadroInsonia);
            builder.Property(x => x.PossuiHepatite);
            builder.Property(x => x.PossuiHernia);
            builder.Property(x => x.PossuiDoencaRins);
            builder.Property(x => x.PossuiDiabetes);
            builder.Property(x => x.ApresentaDoresCostas);
            builder.Property(x => x.ApresentaDoresOmbros);
            builder.Property(x => x.ApresentaDoresPunhos);
            builder.Property(x => x.ApresentaDoresMaos);
            builder.Property(x => x.DiagnosticoCancer);
            builder.Property(x => x.Fuma);
            builder.Property(x => x.QuantosCigarrosDia);
            builder.Property(x => x.Bebe);
            builder.Property(x => x.PraticaAtividadeFisica);
            builder.Property(x => x.DescricaoAtividadeFisica)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.SofreuAlgumaFratura);
            builder.Property(x => x.DescricaoFaturaSofrida)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.EsteveInternado);
            builder.Property(x => x.DescricaoMotivoInternacao)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.PossuiProblemaAuditivo);
            builder.Property(x => x.DescricaoProblemaAuditivo)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.PossuiProblemaVisao);

            builder.Property(x => x.DescricaoProblemaVisao)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.FezAlgumaCirurgia);
            builder.Property(x => x.JaSofreuAcidenteTrabalho);
            builder.Property(x => x.JaEsteveAfastadoMaisQuinzeDias);

            builder.Property(x => x.MotivoAfastadoMaisQuinzeDias)
            .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.RecebeIndenizacaoAcidenteOuDoencaOcupacional);
            builder.Property(x => x.DescricaoMotivoRecebeIndenizacao)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.JaPassouReabilitacaoProfissionalINSS);

            builder.Property(x => x.DescricaoMotivoReabilitacaoProfissionalINSS)
            .HasColumnType("varchar")
                .HasMaxLength(255);

            builder.Property(x => x.PortadorDeficienciaFisica);
            builder.Property(x => x.PortadorDeficienciaAuditiva);
            builder.Property(x => x.PortadorDeficienciaVisual);
            builder.Property(x => x.PortadorDeficienciaMental);
            builder.Property(x => x.PortadorDeficienciaMultipla);

            builder.Property(x => x.MedicoId);

            builder.Property(x => x.Apto);

            builder.Property(x => x.MotivoInapto)
                .HasColumnType("varchar")
                    .HasMaxLength(4000);

            builder.Property(x => x.Local)
                    .HasColumnType("varchar")
                    .HasMaxLength(255);

            builder.Property(x => x.Data);

            builder.HasOne(x => x.Medico)
                .WithMany(x => x.Anamneses)
                .HasForeignKey(x => x.MedicoId);
        }
    }
}