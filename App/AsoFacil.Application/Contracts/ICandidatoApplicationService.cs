using AsoFacil.Application.Models.Candidato;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ICandidatoApplicationService
    {
        Task<IEnumerable<CandidatoModel>> ObterAsync(string nome, string rg, string email);

        Task<CandidatoModel> ObterPorIdAsync(Guid id);
        Task<AnamneseModel> ObterAnamnesePorCandidatoIdAsync(Guid id);

        Task<bool> AlterarAsync(ManterCandidatoModel model);
        Task<bool> AlterarAnamneseAsync(AnamneseModel model);

        Task<bool> CriarAsync(ManterCandidatoModel model);
        Task<bool> CriarAnamneseAsync(AnamneseModel model);

        Task<bool> ExcluirAsync(Guid id);
    }
}