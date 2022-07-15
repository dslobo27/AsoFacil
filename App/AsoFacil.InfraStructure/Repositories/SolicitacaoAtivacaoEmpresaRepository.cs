using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
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

        public async Task Create(SolicitacaoAtivacaoEmpresa solicitacaoAtivacaoEmpresa)
        {
            _context.SolicitacoesAtivacaoEmpresas.Add(solicitacaoAtivacaoEmpresa);
            await _context.SaveChangesAsync();
        }
    }
}