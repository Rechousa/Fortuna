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
        private List<Historico> historico = new List<Historico>()
            {
                new Historico(1, 1, "teste", new DateTime(2018, 1, 24)),
                new Historico(2, 1, "teste 2", new DateTime(2018, 1, 25)),
                new Historico(3, 1, "teste 3", new DateTime(2018, 1, 26)),
                new Historico(4, 2, "ABCD", new DateTime(2018, 1, 27)),
            };

        public Task<IEnumerable<Historico>> GetAll(int idCliente)
        {
            return Task.FromResult(historico.Where(t => t.IdCliente == idCliente));
        }

        public Task<Historico> Find(int id)
        {
            return Task.FromResult(historico.FirstOrDefault(t => t.IdHistorico == id));
        }

        public Task Add(Historico item)
        {
            item.IdHistorico = historico.Max(t => t.IdHistorico) + 1;
            historico.Add(item);

            return Task.FromResult(historico);
        }

        public Task Update(Historico item)
        {
            var record = historico.Single(t => t.IdHistorico == item.IdHistorico);
            record.Descricao = item.Descricao;
            record.DataHora = DateTime.Now;

            return Task.CompletedTask;
        }

        public Task Remove(int id)
        {
            historico.RemoveAll(t => t.IdHistorico == id);
            return Task.CompletedTask;
        }
    }
}
