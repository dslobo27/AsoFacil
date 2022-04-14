using System;

namespace AsoFacil.Domain.Entidades
{
    public class Candidato
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string UF { get; set; }
        public string OrgaoEmissor { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid DocumentoId { get; set; }
        public Guid AnamneseId { get; set; }
        public Guid CargoId { get; set; }
        public Guid EmpresaId { get; set; }

        #endregion Propriedades

        #region Navegação

        public Cargo Cargo { get; set; }
        public Documento Documento { get; set; }
        public Anamnese Anamnese { get; set; }
        public Empresa Empresa { get; set; }

        #endregion Navegação
    }
}