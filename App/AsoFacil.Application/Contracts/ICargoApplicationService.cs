using AsoFacil.Application.Models.Cargo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ICargoApplicationService
    {
        Task<IEnumerable<CargoModel>> ObterAsync(string descricao);

        Task<CargoModel> ObterPorIdAsync(Guid cargoId);

        Task<bool> AlterarAsync(ManterCargoModel model);

        Task<bool> CriarAsync(ManterCargoModel model);

        Task<bool> ExcluirAsync(Guid cargoId);
    }
}