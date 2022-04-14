using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entidades
{
    public class Empresa
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public bool Ativa { get; set; }
        public Guid SolicitacaoAtivacaoEmpresaId { get; set; }

        #endregion Propriedades

        #region Navegação

        public SolicitacaoAtivacaoEmpresa SolicitacaoAtivacaoEmpresa { get; set; }
        public List<Candidato> Candidatos { get; set; }

        #endregion Navegação
    }
}