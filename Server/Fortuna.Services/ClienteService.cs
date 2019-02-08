using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using Fortuna.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fortuna.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<Cliente> Find(int id)
        {
            return _repository.Find(id);
        }

        public Task Add(Cliente item)
        {
            return _repository.Add(item);
        }

        public Task Update(Cliente item)
        {
            return _repository.Update(item);
        }

        public Task Remove(int id)
        {
            return _repository.Remove(id);
        }
    }
}
