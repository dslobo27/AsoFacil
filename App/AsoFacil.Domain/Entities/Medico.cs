using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class Medico
    {   
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }

        public Guid UsuarioId { get; set; }
        public Guid EmpresaId { get; set; }

        public List<Anamnese> Anamneses { get; set; }

        public Usuario Usuario { get; set; }

        public Empresa Empresa { get; set; }

        protected Medico()
        {
        }

        public Medico(string crm, string nome, string email, Guid? usuarioId, Guid empresaId)
        {
            CRM = crm;
            Nome = nome;
            UsuarioId = usuarioId.GetValueOrDefault();
            Email = email;
            EmpresaId = empresaId;
        }

        public void Alterar(string crm, string nome)
        {
            CRM = crm;
            Nome = nome;
        }
    }
}