using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortuna.Infrastructure.Data
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly WebApiContext db;
        private readonly IClienteRepository clienteRepository;

        public AlertaRepository(WebApiContext dbContext)
        {
            db = dbContext;
            clienteRepository = new ClienteRepository(dbContext);
        }

        public Task<IEnumerable<Alerta>> GetAll(int idCliente)
        {
            return Task.FromResult(db.Alertas.Where(t => t.IdCliente == idCliente).AsEnumerable());
        }

        public Task<Alerta> Find(int id)
        {
            return db.FindAsync<Alerta>(id);
        }

        public Task Add(int idCliente, Alerta item)
        {
            var cliente = clienteRepository.Find(idCliente).Result;
            cliente.Alertas.Add(item);

            return db.SaveChangesAsync();
        }

        public Task Update(Alerta item)
        {
            var record = Find(item.IdAlerta).Result;
            record.Descricao = item.Descricao;
            record.DataHora = item.DataHora;

            db.Update(record);
            return db.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var item = Find(id);

            db.Remove(item);
            return db.SaveChangesAsync();
        }
    }
}
