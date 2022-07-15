using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
using Microsoft.EntityFrameworkCore;
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

        public async Task<StatusSolicitacaoAtivacaoEmpresa> GetByDescription(string description)
        {
            return await _context.StatusSolicitacoesAtivacaoEmpresas
                .FirstOrDefaultAsync(x => x.Descricao.Equals(description));
        }
    }
}