using AsoFacil.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Contracts
{
    public interface ICargoApplicationService
    {
        Task<IEnumerable<CargoModel>> ObterAsync(string descricao);

        Task<CargoModel> ObterPorIdAsync(Guid cargoId);

        Task<bool> AlterarAsync(AlterarCargoModel model);

        Task<bool> CriarAsync(CriarCargoModel model);

        Task<bool> ExcluirAsync(Guid cargoId);
    }
}