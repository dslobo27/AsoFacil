using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.Domain.Enums;
using AsoFacil.Domain.Extensions;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsoFacil.InfraStructure.Repositories
{
    public class SolicitacaoAtivacaoEmpresaRepository : ISolicitacaoAtivacaoEmpresaRepository
    {
        private readonly Context _context;

        public SolicitacaoAtivacaoEmpresaRepository(Context context)
        {
            _context = context;
        }
        
        public async Task<List<SolicitacaoAtivacaoEmpresa>> GetAllForActivationAsync()
        {
            return await _context.SolicitacoesAtivacaoEmpresas
                .Include(x => x.Empresa)
                .Include(x => x.StatusSolicitacaoAtivacaoEmpresa)
                .Where(x => x.StatusSolicitacaoAtivacaoEmpresa.Descricao.Equals(
                    EnumExtensions.GetDescription(StatusSolicitacaoAtivacaoEmpresaEnum.Solicitada))).ToListAsync();
        }

        public async Task<SolicitacaoAtivacaoEmpresa> GetByIdAsync(Guid solicitacaoAtivacaoEmpresaId)
        {
            return await _context.SolicitacoesAtivacaoEmpresas
                .Include(x => x.Empresa)
                .Include(x => x.StatusSolicitacaoAtivacaoEmpresa)
                .FirstOrDefaultAsync(x => x.Id.Equals(solicitacaoAtivacaoEmpresaId));
        }

        public async Task InsertAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            _context.SolicitacoesAtivacaoEmpresas.Add(solicitacaoAtivacaoEmpresa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            _context.SolicitacoesAtivacaoEmpresas.Update(solicitacaoAtivacaoEmpresa);
            await _context.SaveChangesAsync();
        }
    }
}