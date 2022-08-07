using System;

namespace AsoFacil.Models.Empresa
{
    public class EmpresaViewModel
    {
        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public bool Ativa { get; set; }
        public Guid SolicitacaoAtivacaoEmpresaId { get; set; }
    }

    public class CriarEmpresaViewModel
    {
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public bool Ativa { get; set; } = false;
    }
}
