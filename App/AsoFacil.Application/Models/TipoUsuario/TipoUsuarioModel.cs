using System;
using System.Collections.Generic;
using System.Linq;

namespace AsoFacil.Application.Models.TipoUsuario
{
    public class TipoUsuarioModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string MenuSistema { get; set; }

        public List<string> ListaMenuSistema
        {
            get
            {
                var listaMenuSistema = MenuSistema
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

                return listaMenuSistema.ToList();
            }
        }
    }

    public class ManterTipoUsuarioModel
    {
        public Guid? Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public List<string> MenuSistema { get; set; }
    }
}