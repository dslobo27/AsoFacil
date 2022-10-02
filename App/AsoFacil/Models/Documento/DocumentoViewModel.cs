using System;

namespace AsoFacil.Models.Documento
{
    public class DocumentoViewModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
    }

    public class ManterDocumentoViewModel
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }
        public string Nome { get; set; }
    }
}