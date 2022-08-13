using System;

namespace AsoFacil.Application.Models
{
    public class CargoModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }

    public class CriarCargoModel
    {
        public string Descricao { get; set; }
    }

    public class AlterarCargoModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }
}