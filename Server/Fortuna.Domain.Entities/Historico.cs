using System;
using System.ComponentModel.DataAnnotations;

namespace Fortuna.Domain.Entities
{
    public class Historico
    {
        public int IdHistorico { get; set; }

        public int IdCliente { get; set; }

        public string Descricao { get; set; }

        public DateTime DataHora { get; set; }

        public Historico(int idCliente, string descricao)
        {
            IdCliente = idCliente;
            Descricao = descricao;
        }
    }
}
