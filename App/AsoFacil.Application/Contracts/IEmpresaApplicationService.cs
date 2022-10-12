using AsoFacil.Application.Models.Empresa;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface IEmpresaApplicationService
    {
        Task<IEnumerable<EmpresaModel>> ObterAsync(string cnpj, string razaoSocial, Guid empresaId);

        Task<EmpresaModel> ObterPorIdAsync(Guid statusAgendamentoId);

        Task<bool> AlterarAsync(ManterEmpresaModel model);

        Task<bool> CriarAsync(ManterEmpresaModel model);

        Task<bool> ExcluirAsync(Guid empresaId);
    }
}