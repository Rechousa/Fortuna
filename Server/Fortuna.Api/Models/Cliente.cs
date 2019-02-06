using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fortuna.Api.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        public string Telefone { get; set; }

        public DateTime? UltimaConsulta { get; set; }

        public DateTime? ProximaConsulta { get; set; }

        public Cliente(int idCliente, string nome, string morada, string telefone, DateTime? ultimaConsulta, DateTime? proximaConsulta)
        {
            IdCliente = idCliente;
            Nome = nome;
            Morada = morada;
            Telefone = telefone;
            UltimaConsulta = ultimaConsulta;
            ProximaConsulta = proximaConsulta;
        }
    }
}
