using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Application.Models.Empresa
{
    public class EmpresaModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public bool Ativa { get; set; }
        public bool FlagClinica { get; set; }
        public Guid SolicitacaoAtivacaoEmpresaId { get; set; }
    }

    public class ManterEmpresaModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CNPJ.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Razão Social.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Por favor, informe um email de contato.")]
        public string Email { get; set; }

        public bool Ativa { get; set; } 
        public bool FlagClinica { get; set; }  

        public Guid? SolicitacaoAtivacaoEmpresaId { get; set; }
    }
}