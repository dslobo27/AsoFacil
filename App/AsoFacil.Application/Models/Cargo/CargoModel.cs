using System;

namespace AsoFacil.Application.Models.Cargo
{
    public class CargoModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ManterCargoModel
    {
        public Guid? Id { get; set; }
        public string Descricao { get; set; }
    }
}