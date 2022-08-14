using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class TipoUsuario
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public TipoUsuario(string codigo, string descricao, string menuSistema)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Descricao = descricao;
            MenuSistema = menuSistema;
        }

        public void Alterar(string codigo, string descricao, string menuSistema)
        {
            Codigo = codigo;
            Descricao = descricao;
            MenuSistema = menuSistema;
        }
    }
}