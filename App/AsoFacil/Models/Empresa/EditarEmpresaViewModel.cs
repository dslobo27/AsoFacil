using System;

namespace AsoFacil.Models.Empresa
{
    public class EditarEmpresaViewModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
    }
}
