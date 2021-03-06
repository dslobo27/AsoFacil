using AsoFacil.Domain.Entities;
using System.Threading.Tasks;

namespace AsoFacil.Domain.Contracts.Repositories
{
    public interface IEmpresaRepository
    {
        Task Create(Empresa empresa);
    }
}