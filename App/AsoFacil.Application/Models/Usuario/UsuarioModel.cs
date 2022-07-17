using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Application.Models.Usuario
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
    }

    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }
}