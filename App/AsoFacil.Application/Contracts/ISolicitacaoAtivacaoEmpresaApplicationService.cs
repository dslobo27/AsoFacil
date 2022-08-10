using AsoFacil.Application.Models.SolicitacaoAtivacaoEmpresa;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ISolicitacaoAtivacaoEmpresaApplicationService
    {
        Task<List<SolicitacaoAtivacaoEmpresaModel>> ObterParaAtivacaoAsync();
        Task<SolicitacaoAtivacaoEmpresaModel> AlterarAsync(Guid solicitacaoAtivacaoEmpresaId);
    }
}