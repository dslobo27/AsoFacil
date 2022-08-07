using System;

namespace AsoFacil.Models.TipoUsuario
{
    public class TipoUsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }
    }
}