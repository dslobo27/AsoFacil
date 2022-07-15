using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class Medico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }

        public List<Anamnese> Anamneses { get; set; }
    }
}