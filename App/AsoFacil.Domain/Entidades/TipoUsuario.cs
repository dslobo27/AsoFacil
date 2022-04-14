using System;

namespace AsoFacil.Domain.Entidades
{
    public class TipoUsuario
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }
    }
}