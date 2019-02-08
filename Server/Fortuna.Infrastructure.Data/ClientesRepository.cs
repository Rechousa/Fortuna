using Fortuna.Domain.Entities;
using Fortuna.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortuna.Infrastructure.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente(1, "João", "Rua da minha casa", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(2, "Manuel", "Avenida daqui", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(3, "Maria", "Travessa do bom caminho", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(4, "Carolina", "Lugar XPTO", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(5, "Sebastião", "Largo grande", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(6, "Rodrigo", "Caminho das horas", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(7, "Paulo", "Rua deste lado", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(8, "Frederico", "Avenida sempre aqui", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(9, "Abel", "Largo pequeno", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(10, "Camila", "Campo do caminho", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis"),
                new Cliente(11, "Patrícia", "Praceta 01 de janeiro", "Cidade teste", "4000-001 Porto", "909009090", "123456789", "Médis")
            };

        public Task<IEnumerable<Cliente>> GetAll()
        {
            return Task.FromResult(clientes.AsEnumerable());
        }

        public Task<Cliente> Find(int id)
        {
            return Task.FromResult(clientes.FirstOrDefault(t => t.IdCliente == id));
        }

        public Task Add(Cliente item)
        {
            item.IdCliente = clientes.Max(t => t.IdCliente) + 1;
            clientes.Add(item);

            return Task.FromResult(clientes);
        }

        public Task Update(Cliente item)
        {
            var cliente = clientes.Single(t => t.IdCliente == item.IdCliente);
            cliente.Nome = item.Nome;
            cliente.Morada = item.Morada;
            cliente.Cidade = item.Cidade;
            cliente.CodigoPostal = item.CodigoPostal;
            cliente.Telefone = item.Telefone;
            cliente.NumeroContribuinte = item.NumeroContribuinte;
            cliente.Convencao = item.Convencao;

            return Task.CompletedTask;
        }

        public Task Remove(int id)
        {
            clientes.RemoveAll(t => t.IdCliente == id);
            return Task.CompletedTask;
        }
    }
}
