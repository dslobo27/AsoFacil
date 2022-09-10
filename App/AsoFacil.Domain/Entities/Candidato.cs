using System;

namespace AsoFacil.Domain.Entities
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

        public Agendamento Agendamento { get; set; }

        #endregion Navegação

        public Candidato(Guid? cargoId, DateTime? dataNascimento, string email, Guid empresaId, string nome)
        {
            CargoId = cargoId.GetValueOrDefault();
            DataNascimento = dataNascimento.GetValueOrDefault();
            Email = email;
            EmpresaId = empresaId;
            Nome = nome;
        }

        public void Alterar(Guid? anamneseId, Guid? cargoId, DateTime? dataNascimento, Guid? documentoId, 
            string email, Guid empresaId, string nome, string orgaoEmissor, string rg, string uf)
        {
            AnamneseId = anamneseId.GetValueOrDefault();
            CargoId = cargoId.GetValueOrDefault();
            DataNascimento = dataNascimento.GetValueOrDefault();
            DocumentoId = documentoId.GetValueOrDefault();
            Email = email;
            EmpresaId = empresaId;
            Nome = nome;
            OrgaoEmissor = orgaoEmissor;
            RG = rg;
            UF = uf;
        }

        public void SetRG(string rg, string uf, string orgaoEmissor)
        {
            RG = rg;
            UF = uf;
            OrgaoEmissor = orgaoEmissor;
        }
    }
}