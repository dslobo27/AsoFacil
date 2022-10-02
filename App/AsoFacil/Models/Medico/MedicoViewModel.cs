using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Medico
{
    public class MedicoViewModel
    {
        public Guid Id { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
    }

    public class ManterMedicoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o CRM!")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }
    }
}