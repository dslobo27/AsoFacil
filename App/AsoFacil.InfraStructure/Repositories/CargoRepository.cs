using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.InfraStructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly Context _context;

        public CargoRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Cargo cargo)
        {
            _context.Cargos.Remove(cargo);
            return await Commit();
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync(string descricao)
        {
            var query = _context.Cargos.AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(x => x.Descricao.Contains(descricao));

            return await query.ToListAsync();
        }

        public async Task<Cargo> GetByIdAsync(Guid cargoId)
        {
            return await _context.Cargos.FindAsync(cargoId);
        }

        public async Task<bool> InsertAsync(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(Cargo cargo)
        {
            _context.Cargos.Update(cargo);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}