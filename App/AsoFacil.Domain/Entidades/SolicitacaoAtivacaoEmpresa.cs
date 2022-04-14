using System;

namespace AsoFacil.Domain.Entidades
{
    public class SolicitacaoAtivacaoEmpresa
    {
        #region Propriedades

        public Guid Id { get; set; }
        public Guid EmpresaId { get; set; }
        public Guid StatusSolicitacaoAtivacaoEmpresaId { get; set; }

        #endregion Propriedades

        #region

        public Empresa Empresa { get; set; }
        public StatusSolicitacaoAtivacaoEmpresa StatusSolicitacaoAtivacaoEmpresa { get; set; }

        #endregion
    }
}