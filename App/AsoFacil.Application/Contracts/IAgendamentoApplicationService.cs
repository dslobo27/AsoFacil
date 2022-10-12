using AsoFacil.Application.Models.Agendamento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IAgendamentoApplicationService
    {
        Task<IEnumerable<AgendamentoModel>> ObterAsync(string nome, string rg, DateTime? dataInicio, DateTime? dataFim, Guid empresaId);

        Task<AgendamentoModel> ObterPorIdAsync(Guid id);

        Task<bool> AlterarAsync(ManterAgendamentoModel model);

        Task<bool> CriarAsync(ManterAgendamentoModel model);

        Task<bool> ExcluirAsync(Guid id);
    }
}