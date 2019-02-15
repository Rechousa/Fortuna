using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Domain.Interfaces
{
    public interface IAlertaRepository
    {
        Task<IEnumerable<Alerta>> GetAll(int idCliente);

        Task<Alerta> Find(int id);

        Task Add(int idCliente, Alerta item);

        Task Update(Alerta item);

        Task Remove(int id);
    }
}
