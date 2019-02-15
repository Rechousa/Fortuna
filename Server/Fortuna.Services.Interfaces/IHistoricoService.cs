using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services.Interfaces
{
    public interface IHistoricoService
    {
        Task<IEnumerable<Historico>> GetAll(int idCliente);

        Task<Historico> Find(int id);

        Task Add(int idCliente, Historico item);

        Task Update(Historico item);

        Task Remove(int id);
    }
}
