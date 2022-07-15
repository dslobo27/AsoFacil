using System;

namespace AsoFacil.Domain.Entities
{
    public class SolicitacaoAtivacaoEmpresa
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public Guid EmpresaId { get; private set; }
        public Guid StatusSolicitacaoAtivacaoEmpresaId { get; private set; }

        #endregion Propriedades

        #region

        public Empresa Empresa { get; set; }
        public StatusSolicitacaoAtivacaoEmpresa StatusSolicitacaoAtivacaoEmpresa { get; set; }

        #endregion

        public SolicitacaoAtivacaoEmpresa(Guid empresaId, Guid statusSolicitacaoAtivacaoEmpresaId)
        {
            Id = new Guid();
            EmpresaId = empresaId;
            StatusSolicitacaoAtivacaoEmpresaId = statusSolicitacaoAtivacaoEmpresaId;
        }
    }
}