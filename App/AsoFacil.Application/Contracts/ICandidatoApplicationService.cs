﻿using AsoFacil.Application.Models.Candidato;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ICandidatoApplicationService
    {
        Task<IEnumerable<CandidatoModel>> ObterAsync(string nome, string rg, string email);

        Task<CandidatoModel> ObterPorIdAsync(Guid id);

        Task<bool> AlterarAsync(ManterCandidatoModel model);

        Task<bool> CriarAsync(ManterCandidatoModel model);

        Task<bool> ExcluirAsync(Guid id);
    }
}