﻿using System;
using System.Collections.Generic;

namespace AsoFacil.Domain.Entities
{
    public class Cargo
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public List<Candidato> Candidatos { get; set; }

        protected Cargo()
        {
        }

        public Cargo(string descricao)
        {
            Descricao = descricao;
        }

        public void Alterar(string descricao)
        {
            Descricao = descricao;
        }
    }
}