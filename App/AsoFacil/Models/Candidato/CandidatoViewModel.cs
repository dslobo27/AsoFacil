using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Candidato
{
    public class CandidatoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string RG { get; set; }

        public string Email { get; set; }
    }

    public class ManterCandidatoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o RG!")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Email { get; set; }
    }
}