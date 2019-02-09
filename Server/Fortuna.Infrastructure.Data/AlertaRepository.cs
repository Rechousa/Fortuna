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
        private List<Alerta> historico = new List<Alerta>()
            {
                new Alerta(1, 1, "Alergia a Penicilina", new DateTime(2018, 1, 24)),
                new Alerta(4, 2, "Alergia à Lactose", new DateTime(2018, 1, 27)),
            };

        public Task<IEnumerable<Alerta>> GetAll(int idCliente)
        {
            return Task.FromResult(historico.Where(t => t.IdCliente == idCliente));
        }

        public Task<Alerta> Find(int idCliente, int id)
        {
            return Task.FromResult(historico.FirstOrDefault(t => t.IdCliente == idCliente && t.IdAlerta == id));
        }

        public Task Add(int idCliente, Alerta item)
        {
            item.IdAlerta = historico.Max(t => t.IdAlerta) + 1;
            item.IdCliente = idCliente;
            historico.Add(item);

            return Task.FromResult(historico);
        }

        public Task Update(int idCliente, Alerta item)
        {
            var record = historico.Single(t => t.IdCliente == idCliente && t.IdAlerta == item.IdAlerta);
            record.Descricao = item.Descricao;
            record.DataHora = DateTime.Now;

            return Task.CompletedTask;
        }

        public Task Remove(int idCliente, int id)
        {
            historico.RemoveAll(t => t.IdCliente == idCliente && t.IdAlerta == id);
            return Task.CompletedTask;
        }
    }
}
