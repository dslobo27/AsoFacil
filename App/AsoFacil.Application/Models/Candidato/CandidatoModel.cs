using AsoFacil.Application.Models.Cargo;
using AsoFacil.Application.Models.Empresa;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsoFacil.Application.Models.Candidato
{
    public class CandidatoModel
    {
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

        public CargoModel Cargo { get; set; }
        public EmpresaModel Empresa { get; set; }
        public AnamneseModel Anamnese { get; set; }
    }

    public class ManterCandidatoModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe um email.")]
        public string Email { get; set; }

        public string RG { get; set; }
        public string UF { get; set; }
        public string OrgaoEmissor { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Guid? DocumentoId { get; set; }
        public Guid? AnamneseId { get; set; }
        public Guid? CargoId { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma empresa.")]
        public Guid EmpresaId { get; set; }
    }
}
