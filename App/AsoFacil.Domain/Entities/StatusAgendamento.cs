using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class StatusAgendamento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public List<Agendamento> Agendamentos { get; set; }
    }
}