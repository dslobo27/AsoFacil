using AsoFacil.Application.Models.Candidato;
using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.StatusAgendamento;
using System;

namespace AsoFacil.Application.Models.Agendamento
{
    public class AgendamentoModel
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public Guid CandidatoId { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid StatusAgendamentoId { get; set; }

        public CandidatoModel Candidato { get; set; }
        public StatusAgendamentoModel StatusAgendamento { get; set; }
        public EmpresaModel Empresa { get; set; }
    }

    public class ManterAgendamentoModel
    {
        public Guid? Id { get; set; }
        public DateTime DataHora { get; set; }
        public Guid? CandidatoId { get; set; }
        public Guid? StatusAgendamentoId { get; set; }
        public Guid? EmpresaId { get; set; }
    }
}