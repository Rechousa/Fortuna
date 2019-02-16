using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortuna.Infrastructure.Data
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly WebApiContext db;
        private readonly IClienteRepository clienteRepository;

        public HistoricoRepository(WebApiContext dbContext)
        {
            db = dbContext;
            clienteRepository = new ClienteRepository(dbContext);
        }

        public Task<IEnumerable<Historico>> GetAll(int idCliente)
        {
            return Task.FromResult(db.Historico.Where(t => t.IdCliente == idCliente).AsEnumerable());
        }

        public Task<Historico> Find(int id)
        {
            return db.FindAsync<Historico>(id);
        }

        public Task Add(int idCliente, Historico item)
        {
            var cliente = clienteRepository.Find(idCliente).Result;
            cliente.Historico.Add(item);

            return db.SaveChangesAsync();
        }

        public Task Update(Historico item)
        {
            var record = Find(item.IdHistorico).Result;
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
