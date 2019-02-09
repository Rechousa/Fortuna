using Fortuna.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services.Interfaces
{
    public interface IAlertaService
    {
        Task<IEnumerable<Alerta>> GetAll(int idCliente);

        Task<Alerta> Find(int idCliente, int id);

        Task Add(int idCliente, Alerta item);

        Task Update(int idCliente, Alerta item);

        Task Remove(int idCliente, int id);
    }
}
