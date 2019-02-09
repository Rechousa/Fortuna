using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using Fortuna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services
{
    public class AlertaService : IAlertaService
    {
        private readonly IAlertaRepository _repository;

        public AlertaService(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Alerta>> GetAll(int idCliente)
        {
            return _repository.GetAll(idCliente);
        }

        public Task<Alerta> Find(int idCliente, int id)
        {
            return _repository.Find(idCliente, id);
        }

        public Task Add(int idCliente, Alerta item)
        {
            return _repository.Add(idCliente, item);
        }

        public Task Update(int idCliente, Alerta item)
        {
            return _repository.Update(idCliente, item);
        }

        public Task Remove(int idCliente, int id)
        {
            return _repository.Remove(idCliente, id);
        }
    }
}
