using AsoFacil.Domain.Contracts.Repositories;
using AsoFacil.Domain.Entities;
using AsoFacil.InfraStructure.DataContext;
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

        public async Task Create(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
        }
    }
}