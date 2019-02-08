using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();

        Task<Cliente> Find(int id);

        Task Add(Cliente item);

        Task Update(Cliente item);

        Task Remove(int id);
    }
}
