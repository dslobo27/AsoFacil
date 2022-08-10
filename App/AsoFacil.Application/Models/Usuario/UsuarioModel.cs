using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.TipoUsuario;
using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Application.Models.Usuario
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }

        public TipoUsuarioModel TipoUsuario { get; set; }
        public EmpresaModel Empresa { get; set; }

        public string Token { get; set; }
    }

    public class UsuarioLoginModel
    {
        [Required(ErrorMessage = "Por favor, informe o usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha.")]
        public string Senha { get; set; }
    }

    public class CriarUsuarioModel
    {
        public Guid TipoUsuarioId { get; set; }
        public Guid EmpresaId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}