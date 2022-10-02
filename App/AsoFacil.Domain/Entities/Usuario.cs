using System;

namespace AsoFacil.Domain.Entities
{
    public class Usuario
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Guid TipoUsuarioId { get; set; }
        public Guid? EmpresaId { get; set; }

        #endregion Propriedades

        #region Navegação

        public TipoUsuario TipoUsuario { get; set; }
        public Empresa Empresa { get; set; }

        #endregion Navegação

        protected Usuario()
        {
        }

        public Usuario(string login, string senha, Guid tipoUsuarioId, Guid empresaId)
        {
            Id = Guid.NewGuid();
            Login = login;
            Senha = senha;
            TipoUsuarioId = tipoUsuarioId;
            EmpresaId = empresaId;
        }

        public void Alterar(string senha, Guid tipoUsuarioId, Guid empresaId)
        {
            Senha = senha;
            TipoUsuarioId = tipoUsuarioId;
            EmpresaId = empresaId;
        }
    }
}