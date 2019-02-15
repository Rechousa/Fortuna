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

        public Historico(int idHistorico, int idCliente, string descricao, DateTime dataHora)
        {
            IdHistorico = idHistorico;
            IdCliente = idCliente;
            Descricao = descricao;
            DataHora = dataHora;
        }
    }
}
