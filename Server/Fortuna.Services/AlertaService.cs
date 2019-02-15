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

        public Task<Alerta> Find(int id)
        {
            return _repository.Find(id);
        }

        public Task Add(int idCliente, Alerta item)
        {
            return _repository.Add(idCliente, item);
        }

        public Task Update(Alerta item)
        {
            return _repository.Update(item);
        }

        public Task Remove(int id)
        {
            return _repository.Remove(id);
        }
    }
}
