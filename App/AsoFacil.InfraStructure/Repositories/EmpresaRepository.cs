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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Context _context;

        public EmpresaRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            return await Commit();
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync(string cnpj, string razaoSocial, Guid empresaId)
        {
            var query = _context.Empresas.AsQueryable();

            if (!string.IsNullOrEmpty(cnpj))
                query = query.Where(x => x.CNPJ.Contains(cnpj));

            if (!string.IsNullOrEmpty(razaoSocial))
                query = query.Where(x => x.RazaoSocial.Contains(razaoSocial));

            query = query.Where(x => x.Ativa == true);

            if (empresaId != default)
                query = query.Where(x => x.Id == empresaId);

            return await query.ToListAsync();
        }

        public async Task<Empresa> GetByIdAsync(Guid empresaId)
        {
            return await _context.Empresas.FindAsync(empresaId);
        }

        public async Task InsertAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Empresa empresa)
        {
            _context.Empresas.Update(empresa);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}