using System;
using System.ComponentModel.DataAnnotations;

namespace AsoFacil.Models.Cargo
{
    public class CargoViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ManterCargoViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição!")]
        public string Descricao { get; set; }
    }
}