using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Usuario
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
    }

    public class ManterUsuarioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o Email!")]
        public string Login { get; set; }
    }
}