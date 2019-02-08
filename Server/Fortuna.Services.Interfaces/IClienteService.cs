using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAll();

        Task<Cliente> Find(int id);

        Task Add(Cliente item);

        Task Update(Cliente item);

        Task Remove(int id);
    }
}
