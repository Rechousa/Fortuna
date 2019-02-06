using Fortuna.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortuna.Api
{
    public class DummyClientesRepository
    {
        private static readonly List<Cliente> clientes = new List<Cliente>
        {
            new Cliente(1, "João", "", "", new DateTime(2018, 1, 1), new DateTime(2019, 2, 15)),
            new Cliente(2, "Manuel", "", "", new DateTime(2018, 1, 1), new DateTime(2019, 2, 15)),
            new Cliente(3, "Maria", "", "", new DateTime(2018, 1, 1), new DateTime(2019, 2, 15)),
            new Cliente(4, "Carolina", "", "", new DateTime(2018, 1, 1), new DateTime(2019, 2, 15)),
            new Cliente(5, "Sebastião", "", "", new DateTime(2018, 1, 1), new DateTime(2019, 2, 15)),
        };

        public static Task<List<Cliente>> GetAll()
        {
            return Task.FromResult(clientes);
        }

        public static Task<Cliente> Find(int id)
        {
            return Task.FromResult(clientes.FirstOrDefault(t => t.IdCliente == id));
        }

        internal static Task Add(Cliente item)
        {
            item.IdCliente = clientes.Max(t => t.IdCliente) + 1;
            clientes.Add(item);

            return Task.FromResult(clientes);
        }

        internal static Task Update(Cliente item)
        {
            var cliente = clientes.Single(t => t.IdCliente == item.IdCliente);
            cliente.Nome = item.Nome;
            cliente.Morada = item.Morada;
            cliente.Telefone = item.Telefone;
            return Task.CompletedTask;
        }

        internal static Task Remove(int id)
        {
            clientes.RemoveAll(t => t.IdCliente == id);
            return Task.CompletedTask;
        }
    }
}
