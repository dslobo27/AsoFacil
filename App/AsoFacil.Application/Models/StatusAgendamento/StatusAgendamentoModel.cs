using System;

namespace AsoFacil.Application.Models.StatusAgendamento
{
    public class StatusAgendamentoModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ManterStatusAgendamentoModel
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
    }
}