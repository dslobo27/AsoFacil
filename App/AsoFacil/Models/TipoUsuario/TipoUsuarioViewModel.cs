using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.TipoUsuario
{
    public class TipoUsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }
    }

    public class ManterTipoUsuarioViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o código!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Informe a descrição!")]
        public string Descricao { get; set; }

        public List<string> MenuSistema { get; set; }
    }
}