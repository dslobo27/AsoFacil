using System;

namespace AsoFacil.Domain.Entities
{
    public class Agendamento
    {
        #region Propriedades

        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public Guid CandidatoId { get; set; }
        public Guid StatusAgendamentoId { get; set; }

        #endregion Propriedades

        #region Navegação

        public Candidato Candidato { get; set; }
        public StatusAgendamento StatusAgendamento { get; set; }

        #endregion Navegação
    }
}