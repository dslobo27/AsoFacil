using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Agendamento
{
    public class AgendamentoViewModel
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }
    }

    public class ManterAgendamentoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a Data!")]
        public DateTime Data { get; set; }
    }
}