using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class TipoUsuario
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}