using AsoFacil.Application.Models.Medico;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IMedicoApplicationService
    {
        Task<IEnumerable<MedicoModel>> ObterAsync(string crm, string nome, Guid empresaId);

        Task<MedicoModel> ObterPorIdAsync(Guid id);

        Task<bool> AlterarAsync(ManterMedicoModel model);

        Task<bool> CriarAsync(ManterMedicoModel model);

        Task<bool> ExcluirAsync(Guid id);
    }
}