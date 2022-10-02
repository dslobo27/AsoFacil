using System;

namespace AsoFacil.Domain.Entities
{
    public class Documento
    {
        public Guid Id { get; set; }
        public string NomeArquivo { get; set; }


        public Candidato Candidato { get; set; }

        protected Documento()
        {
        }
    }
}