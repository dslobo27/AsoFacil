using AsoFacil.Application.Models.StatusSolicitacaoAtivacaoEmpresa;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IStatusSolicitacaoAtivacaoEmpresaApplicationService
    {
        Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresaModel>> ObterAsync(string codigo, string descricao);

        Task<StatusSolicitacaoAtivacaoEmpresaModel> ObterPorIdAsync(Guid statusSolicitacaoAgendamentoId);

        Task<bool> AlterarAsync(ManterStatusSolicitacaoAtivacaoEmpresaModel model);

        Task<bool> CriarAsync(ManterStatusSolicitacaoAtivacaoEmpresaModel model);

        Task<bool> ExcluirAsync(Guid statusSolicitacaoAgendamentoId);
    }
}