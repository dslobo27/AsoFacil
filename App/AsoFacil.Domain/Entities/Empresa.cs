using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class Empresa
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string CNPJ { get; private set; }
        public string RazaoSocial { get; private set; }
        public string Email { get; private set; }
        public bool Ativa { get; private set; }
        public bool FlagClinica { get; private set; }
        public Guid SolicitacaoAtivacaoEmpresaId { get; private set; }

        #endregion Propriedades

        #region Navegação

        public List<SolicitacaoAtivacaoEmpresa> SolicitacoesAtivacaoEmpresa { get; set; }
        public List<Candidato> Candidatos { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public List<Usuario> Usuarios { get; set; }

        #endregion 

        protected Empresa()
        {
        }

        public Empresa(string cnpj, string razaoSocial, string email, bool flagClinica)
        {
            Id = Guid.NewGuid();
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            Email = email;
            FlagClinica = flagClinica;
        }

        public void SetAtiva(bool value)
        {
            Ativa = value;
        }

        public void Alterar(string cnpj, string razaoSocial, string email, bool flagClinica, bool ativa)
        {
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            Email = email;
            FlagClinica = flagClinica;
            Ativa = ativa;
        }

        public void SetSolicitacaoAtivacaoEmpresa(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            SolicitacaoAtivacaoEmpresaId = solicitacaoAtivacaoEmpresa.Id;
        }
    }
}