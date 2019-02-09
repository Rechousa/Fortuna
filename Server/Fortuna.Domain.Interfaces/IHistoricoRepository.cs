using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Domain.Interfaces
{
    public interface IHistoricoRepository
    {
        Task<IEnumerable<Historico>> GetAll(int idCliente);

        Task<Historico> Find(int idCliente, int id);

        Task Add(int idCliente, Historico item);

        Task Update(int idCliente, Historico item);

        Task Remove(int idCliente, int id);
    }
}
