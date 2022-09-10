using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class Medico
    {   
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }

        public Guid UsuarioId { get; set; }

        public List<Anamnese> Anamneses { get; set; }

        public Usuario Usuario { get; set; }

        public Medico(string crm, string nome, Guid? usuarioId)
        {
            CRM = crm;
            Nome = nome;
            UsuarioId = usuarioId.GetValueOrDefault();
        }

        public void Alterar(string crm, string nome)
        {
            CRM = crm;
            Nome = nome;
        }
    }
}