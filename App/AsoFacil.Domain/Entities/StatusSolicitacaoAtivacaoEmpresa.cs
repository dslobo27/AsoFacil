using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class StatusSolicitacaoAtivacaoEmpresa
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public List<SolicitacaoAtivacaoEmpresa> SolicitacoesAtivacoesEmpresas { get; set; }
    }
}