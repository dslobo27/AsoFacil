using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Contracts.Services;
using AsoFacil.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Services
{
    public class CargoDomainService : ICargoDomainService
    {
        private readonly ICargoRepository _cargoRepository;

        public CargoDomainService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public async Task<bool> DeleteAsync(Cargo cargo)
        {
            return await _cargoRepository.DeleteAsync(cargo);
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync(string descricao)
        {
            return await _cargoRepository.GetAllAsync(descricao);
        }

        public async Task<Cargo> GetByIdAsync(Guid cargoId)
        {
            return await _cargoRepository.GetByIdAsync(cargoId);
        }

        public async Task<bool> InsertAsync(Cargo cargo)
        {
            return await _cargoRepository.InsertAsync(cargo);
        }

        public async Task<bool> UpdateAsync(Cargo cargo)
        {
            return await _cargoRepository.UpdateAsync(cargo);
        }
    }
}