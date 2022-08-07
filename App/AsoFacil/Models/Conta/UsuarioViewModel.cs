using AsoFacil.Models.Empresa;
using AsoFacil.Models.TipoUsuario;
using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Conta
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }

        public TipoUsuarioViewModel TipoUsuario { get; set; }
        public EmpresaViewModel Empresa { get; set; }

        public string Token { get; set; }
    }

    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }

        public bool LembrarDeMim { get; set; }
    }
}