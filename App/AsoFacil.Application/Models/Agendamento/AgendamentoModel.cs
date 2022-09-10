using System;

namespace AsoFacil.Application.Models.Agendamento
{
    public class AgendamentoModel
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public Guid CandidatoId { get; set; }
        public Guid StatusAgendamentoId { get; set; }
    }

    public class ManterAgendamentoModel
    {
        public Guid? Id { get; set; }
        public DateTime DataHora { get; set; }
        public Guid? CandidatoId { get; set; }
        public Guid? StatusAgendamentoId { get; set; }
    }
}