using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Application.Models.Empresa
{
    public class CriarEmpresaModel
    {
        [Required(ErrorMessage = "Por favor, informe o CNPJ.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Razão Social.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Por favor, informe um email de contato.")]
        public string Email { get; set; }
    }
}