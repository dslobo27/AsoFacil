using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.StatusSolicitacaoAtivacaoEmpresa
{
    public class StatusSolicitacaoAtivacaoEmpresaViewModel
    {
        public Guid Id { get; set; }

        public string Codigo { get; set; }

        public string Descricao { get; set; }
    }

    public class ManterStatusSolicitacaoAtivacaoEmpresaViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o código!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Informe a descrição!")]
        public string Descricao { get; set; }
    }
}