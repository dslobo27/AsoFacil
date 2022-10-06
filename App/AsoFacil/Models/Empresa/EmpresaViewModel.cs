using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Empresa
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public bool Ativa { get; set; }
        public bool FlagClinica { get; set; }
        public Guid SolicitacaoAtivacaoEmpresaId { get; set; }
    }

    public class ManterEmpresaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social!")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Email { get; set; }
        public bool Ativa { get; set; } = false;
        public bool FlagClinica { get; set; } = false;
    }
}
