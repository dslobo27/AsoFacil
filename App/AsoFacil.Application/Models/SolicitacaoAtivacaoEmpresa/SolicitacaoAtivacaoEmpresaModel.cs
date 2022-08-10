using AsoFacil.Application.Models.Empresa;
using AsoFacil.Application.Models.StatusSolicitacaoAtivacaoEmpresa;
using System;

namespace AsoFacil.Application.Models.SolicitacaoAtivacaoEmpresa
{
    public class SolicitacaoAtivacaoEmpresaModel
    {
        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid StatusSolicitacaoAtivacaoEmpresaId { get; set; }

        public EmpresaModel EmpresaModel { get; set; }
        public StatusSolicitacaoAtivacaoEmpresaModel StatusSolicitacaoAtivacaoEmpresaModel { get; set; }
    }
}