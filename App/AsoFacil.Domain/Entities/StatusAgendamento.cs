using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class StatusAgendamento
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public List<Agendamento> Agendamentos { get; set; }

        protected StatusAgendamento()
        {
        }

        public StatusAgendamento(string descricao)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
        }

        public void Alterar(string descricao)
        {
            Descricao = descricao;
        }
    }
}