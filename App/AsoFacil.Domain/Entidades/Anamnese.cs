using System;

namespace AsoFacil.Domain.Entidades
{
    public class Anamnese
    {
        public Guid Id { get; set; }

        #region Perguntas

        public bool PossuiDoencaCoracao { get; set; }
        public bool ApresentaProblemaPsiquiatrico { get; set; }
        public bool ApresentaQuadroAnsiedade { get; set; }
        public bool ApresentaQuadroDepressao { get; set; }
        public bool ApresentaQuadroInsonia { get; set; }
        public bool PossuiHepatite { get; set; }
        public bool PossuiHernia { get; set; }
        public bool PossuiDoencaRins { get; set; }
        public bool PossuiDiabetes { get; set; }
        public bool ApresentaDoresCostas { get; set; }
        public bool ApresentaDoresOmbros { get; set; }
        public bool ApresentaDoresPunhos { get; set; }
        public bool ApresentaDoresMaos { get; set; }
        public bool DiagnosticoCancer { get; set; }
        public bool Fuma { get; set; }
        public int QuantosCigarrosDia { get; set; }
        public bool Bebe { get; set; }
        public bool PraticaAtividadeFisica { get; set; }
        public string DescricaoAtividadeFisica { get; set; }
        public bool SofreuAlgumaFratura { get; set; }
        public string DescricaoFaturaSofrida { get; set; }
        public bool EsteveInternado { get; set; }
        public string DescricaoMotivoInternacao { get; set; }
        public bool PossuiProblemaAuditivo { get; set; }
        public string DescricaoProblemaAuditivo { get; set; }
        public bool PossuiProblemaVisao { get; set; }
        public string DescricaoProblemaVisao { get; set; }
        public bool FezAlgumaCirurgia { get; set; }
        public bool JaSofreuAcidenteTrabalho { get; set; }
        public bool JaEsteveAfastadoMaisQuinzeDias { get; set; }
        public string MotivoAfastadoMaisQuinzeDias { get; set; }
        public bool RecebeIndenizacaoAcidenteOuDoencaOcupacional { get; set; }
        public string DescricaoMotivoRecebeIndenizacao { get; set; }
        public bool JaPassouReabilitacaoProfissionalINSS { get; set; }
        public string DescricaoMotivoReabilitacaoProfissionalINSS { get; set; }
        public bool PortadorDeficienciaFisica { get; set; }
        public bool PortadorDeficienciaAuditiva { get; set; }
        public bool PortadorDeficienciaVisual { get; set; }
        public bool PortadorDeficienciaMental { get; set; }
        public bool PortadorDeficienciaMultipla { get; set; }

        #endregion

        public Guid MedicoId { get; set; }

        public bool Apto { get; set; }
        public string MotivoInapto { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }

        public Medico Medico { get; set; }
    }
}