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
        public Guid SolicitacaoAtivacaoEmpresaId { get; private set; }

        #endregion Propriedades

        #region Navegação

        public SolicitacaoAtivacaoEmpresa SolicitacaoAtivacaoEmpresa { get; set; }
        public List<Candidato> Candidatos { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
        public List<Usuario> Usuarios { get; set; }

        #endregion 

        public Empresa()
        {
        }

        public Empresa(string cnpj, string razaoSocial, string email)
        {
            Id = new Guid();
            CNPJ = cnpj;
            RazaoSocial = razaoSocial;
            Email = email;
        }

        public void SetAtiva(bool value)
        {
            Ativa = value;
        }
    }
}