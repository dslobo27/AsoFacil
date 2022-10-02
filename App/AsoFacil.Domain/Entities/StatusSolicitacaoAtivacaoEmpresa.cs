using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class StatusSolicitacaoAtivacaoEmpresa
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public List<SolicitacaoAtivacaoEmpresa> SolicitacoesAtivacoesEmpresas { get; set; }

        protected StatusSolicitacaoAtivacaoEmpresa()
        {
        }

        public StatusSolicitacaoAtivacaoEmpresa(string codigo, string descricao)
        {
            Id = Guid.NewGuid();
            Codigo = codigo;
            Descricao = descricao;
        }

        public void Alterar(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}