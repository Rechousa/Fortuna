using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using Fortuna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services
{
    public class HistoricoService : IHistoricoService
    {
        private readonly IHistoricoRepository _repository;

        public HistoricoService(IHistoricoRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Historico>> GetAll(int idCliente)
        {
            return _repository.GetAll(idCliente);
        }

        public Task<Historico> Find(int idCliente, int id)
        {
            return _repository.Find(idCliente, id);
        }

        public Task Add(int idCliente, Historico item)
        {
            return _repository.Add(idCliente, item);
        }

        public Task Update(int idCliente, Historico item)
        {
            return _repository.Update(idCliente, item);
        }

        public Task Remove(int idCliente, int id)
        {
            return _repository.Remove(idCliente, id);
        }
    }
}
