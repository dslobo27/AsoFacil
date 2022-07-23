using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Conta
{
    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}