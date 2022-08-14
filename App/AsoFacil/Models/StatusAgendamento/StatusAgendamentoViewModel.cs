using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.StatusAgendamento
{
    public class StatusAgendamentoViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ManterStatusAgendamentoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição!")]
        public string Descricao { get; set; }
    }
}