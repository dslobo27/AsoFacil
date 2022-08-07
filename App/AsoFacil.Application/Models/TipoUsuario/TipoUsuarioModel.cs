using System;

namespace AsoFacil.Application.Models.TipoUsuario
{
    public class TipoUsuarioModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }
    }
}