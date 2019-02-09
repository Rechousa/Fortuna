using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Domain.Interfaces
{
    public interface IHistoricoRepository
    {
        Task<IEnumerable<Historico>> GetAll(int idCliente);

        Task<Historico> Find(int id);

        Task Add(Historico item);

        Task Update(Historico item);

        Task Remove(int id);
    }
}
