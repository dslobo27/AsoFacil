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
    }
}