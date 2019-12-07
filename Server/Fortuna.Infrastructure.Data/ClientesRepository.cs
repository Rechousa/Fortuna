using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortuna.Infrastructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly WebApiContext db;

        public ClienteRepository(WebApiContext dbContext)
        {
            db = dbContext;
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            return Task.FromResult(db.Clientes.AsEnumerable());
        }

        public Task<Cliente> Find(int id)
        {
            return db.FindAsync<Cliente>(id);
        }

        public Task Add(Cliente item)
        {
            db.Clientes.Add(item);
            return db.SaveChangesAsync();
        }

        public Task Update(Cliente item)
        {
            var record = db.Clientes.Single(t => t.IdCliente == item.IdCliente);
            record.Nome = item.Nome;
            record.Morada = item.Morada;
            record.Cidade = item.Cidade;
            record.CodigoPostal = item.CodigoPostal;
            record.Telefone = item.Telefone;
            record.NumeroUtente = item.NumeroUtente;
            record.NumeroContribuinte = item.NumeroContribuinte;
            record.Email = item.Email;
            record.NomeConvencao = item.NomeConvencao;
            record.NumeroConvencao = item.NumeroConvencao;

            db.Update(record);
            return db.SaveChangesAsync();
        }

        public Task Remove(int id)
        {
            var item = Find(id).Result;

            db.Remove(item);
            return db.SaveChangesAsync();
        }
    }
}
