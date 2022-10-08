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
        public Guid EmpresaId { get; set; }

        #endregion Propriedades

        #region Navegação

        public Candidato Candidato { get; set; }
        public Empresa Empresa { get; set; }
        public StatusAgendamento StatusAgendamento { get; set; }

        protected Agendamento()
        {
        }

        public Agendamento(Guid id, Guid? candidatoId, DateTime dataHora, Guid statusAgendamentoId)
        {
            Id = id;
            CandidatoId = candidatoId.GetValueOrDefault();
            DataHora = dataHora;
            StatusAgendamentoId = statusAgendamentoId;
        }

        public void Alterar(Guid? candidatoId, Guid? statusAgendamentoId, DateTime dataHora)
        {
            CandidatoId = candidatoId.GetValueOrDefault();
            StatusAgendamentoId = statusAgendamentoId.GetValueOrDefault();
            DataHora = dataHora;
        }

        #endregion Navegação
    }
}