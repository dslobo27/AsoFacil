using AsoFacil.Models.Candidato;
using AsoFacil.Models.Empresa;
using AsoFacil.Models.StatusAgendamento;
using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Agendamento
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }

        public DateTime DataHora { get; set; }
        public Guid CandidatoId { get; set; }
        public Guid StatusAgendamentoId { get; set; }
        public Guid EmpresaId { get; set; }

        public CandidatoViewModel Candidato { get; set; }
        public StatusAgendamentoViewModel StatusAgendamento { get; set; }
        public EmpresaViewModel Empresa { get; set; }
    }

    public class ManterAgendamentoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a Data!")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Informe o Candidato!")]
        public Guid CandidatoId { get; set; }

        [Required(ErrorMessage = "Informe o Status de Agendamento!")]
        public Guid StatusAgendamentoId { get; set; }        
    }
}