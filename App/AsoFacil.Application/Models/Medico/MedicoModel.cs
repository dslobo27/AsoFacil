using System;

namespace AsoFacil.Application.Models.Medico
{
    public class MedicoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public Guid UsuarioId { get; set; }
    }

    public class ManterMedicoModel
    {
        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}