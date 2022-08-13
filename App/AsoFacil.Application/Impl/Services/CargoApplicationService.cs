using AsoFacil.Application.Contracts;
using AsoFacil.Application.Models;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Application.Impl.Services
{
    public class CargoApplicationService : ICargoApplicationService
    {
        private readonly ICargoDomainService _cargoDomainService;

        public CargoApplicationService(ICargoDomainService cargoDomainService)
        {
            _cargoDomainService = cargoDomainService;
        }

        public async Task<bool> AlterarAsync(AlterarCargoModel model)
        {
            var cargo = await _cargoDomainService.GetByIdAsync(model.Id);
            cargo.Alterar(model.Descricao);

            return await _cargoDomainService.UpdateAsync(cargo);
        }

        public async Task<bool> CriarAsync(CriarCargoModel model)
        {
            var cargo = new Cargo(model.Descricao);
            return await _cargoDomainService.InsertAsync(cargo);
        }

        public async Task<bool> ExcluirAsync(Guid cargoId)
        {
            var cargo = await _cargoDomainService.GetByIdAsync(cargoId);
            return await _cargoDomainService.DeleteAsync(cargo);
        }

        public async Task<IEnumerable<CargoModel>> ObterAsync(string descricao)
        {
            var cargos = await _cargoDomainService.GetAllAsync(descricao);
            return ConvertToDto(cargos);
        }

        public async Task<CargoModel> ObterPorIdAsync(Guid cargoId)
        {
            var cargo = await _cargoDomainService.GetByIdAsync(cargoId);
            return ConvertToDto(cargo);
        }

        #region private

        private static List<CargoModel> ConvertToDto(IEnumerable<Cargo> cargos)
        {
            var cargosModels = new List<CargoModel>();
            foreach (var c in cargos)
            {
                cargosModels.Add(ConvertToDto(c));
            }
            return cargosModels;
        }

        private static CargoModel ConvertToDto(Cargo c)
        {
            return new CargoModel
            {
                Id = c.Id,
                Descricao = c.Descricao
            };
        }

        #endregion private
    }
}