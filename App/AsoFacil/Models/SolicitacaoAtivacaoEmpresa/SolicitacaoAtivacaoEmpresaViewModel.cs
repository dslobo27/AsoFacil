using AsoFacil.Models.Empresa;
using System;

namespace AsoFacil.Models.SolicitacaoAtivacaoEmpresa
{
    public class SolicitacaoAtivacaoEmpresaViewModel
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid StatusSolicitacaoAtivacaoEmpresaId { get; set; }

        public EmpresaViewModel EmpresaModel { get; set; }
        public StatusSolicitacaoAtivacaoEmpresaViewModel StatusSolicitacaoAtivacaoEmpresaModel { get; set; }
    }
}