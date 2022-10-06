using AsoFacil.Models.Empresa;
using AsoFacil.Models.TipoUsuario;
using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Usuario
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }

        public TipoUsuarioViewModel TipoUsuario { get; set; }
        public EmpresaViewModel Empresa { get; set; }
    }

    public class ManterUsuarioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Login { get; set; }
    }
}