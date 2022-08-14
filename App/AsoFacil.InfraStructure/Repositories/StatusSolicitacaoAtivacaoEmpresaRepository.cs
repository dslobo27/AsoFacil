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
    public class StatusSolicitacaoAtivacaoEmpresaRepository : IStatusSolicitacaoAtivacaoEmpresaRepository
    {
        private readonly Context _context;

        public StatusSolicitacaoAtivacaoEmpresaRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            _context.StatusSolicitacoesAtivacaoEmpresas.Remove(statusSolicitacaoAtivacaoEmpresa);
            return await Commit();
        }

        public async Task<IEnumerable<StatusSolicitacaoAtivacaoEmpresa>> GetAllAsync(string codigo, string descricao)
        {
            var query = _context.StatusSolicitacoesAtivacaoEmpresas.AsQueryable();

            if (!string.IsNullOrEmpty(codigo))
                query = query.Where(x => x.Codigo.Contains(codigo));

            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(x => x.Descricao.Contains(descricao));

            return await query.ToListAsync();
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description)
        {
            return await _context.StatusSolicitacoesAtivacaoEmpresas
                .FirstOrDefaultAsync(x => x.Descricao.Equals(description));
        }

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid statusSolicitacaoAtivacaoEmpresaId)
        {
            return await _context.StatusSolicitacoesAtivacaoEmpresas.FindAsync(statusSolicitacaoAtivacaoEmpresaId);
        }

        public async Task<bool> InsertAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            _context.StatusSolicitacoesAtivacaoEmpresas.Add(statusSolicitacaoAtivacaoEmpresa);
            return await Commit();
        }

        public async Task<bool> UpdateAsync(StatusSolicitacaoAtivacaoEmpresa statusSolicitacaoAtivacaoEmpresa)
        {
            _context.StatusSolicitacoesAtivacaoEmpresas.Update(statusSolicitacaoAtivacaoEmpresa);
            return await Commit();
        }

        private async Task<bool> Commit()
        {
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}