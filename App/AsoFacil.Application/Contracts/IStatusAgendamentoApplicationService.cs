using AsoFacil.Application.Models.StatusAgendamento;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IStatusAgendamentoApplicationService
    {
        Task<IEnumerable<StatusAgendamentoModel>> ObterAsync(string descricao);

        Task<StatusAgendamentoModel> ObterPorIdAsync(Guid statusAgendamentoId);

        Task<bool> AlterarAsync(ManterStatusAgendamentoModel model);

        Task<bool> CriarAsync(ManterStatusAgendamentoModel model);

        Task<bool> ExcluirAsync(Guid statusAgendamentoId);
    }
}