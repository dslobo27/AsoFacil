using System.ComponentModel;

namespace AsoFacil.Domain.Enums
{
    public enum StatusSolicitacaoAtivacaoEmpresaEnum
    {
        [Description("Solicitada")]
        Solicitada,

        [Description("Em análise")]
        EmAnalise,

        [Description("Aprovada")]
        Aprovada,

        [Description("Reprovada")]
        Reprovada
    }
}