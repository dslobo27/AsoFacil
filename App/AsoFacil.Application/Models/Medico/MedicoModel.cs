using AsoFacil.Application.Models.Empresa;
using System;

namespace AsoFacil.Application.Models.Medico
{
    public class MedicoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public Guid UsuarioId { get; set; }
        public EmpresaModel Empresa { get; set; }
    }

    public class ManterMedicoModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public string Email { get; set; }
        public Guid? UsuarioId { get; set; }
        public Guid? EmpresaId { get; set; }
    }
}