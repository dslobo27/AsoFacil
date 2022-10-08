using AsoFacil.Models.Cargo;
using AsoFacil.Models.Empresa;
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
        public string UF { get; set; }
        public string OrgaoEmissor { get; set; }
        public DateTime DataNascimento { get; set; }
        public CargoViewModel Cargo { get; set; }
        public EmpresaViewModel Empresa { get; set; }
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

        [Required(ErrorMessage = "Informe a UF!")]
        public string UF { get; set; }

        [Required(ErrorMessage = "Informe o Órgão Emissor!")]
        public string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = "Informe a Data de Nascimento!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o Cargo!")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Informe a Empresa!")]
        public Guid EmpresaId { get; set; }
    }
}