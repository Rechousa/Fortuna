using System;
using System.ComponentModel.DataAnnotations;

namespace Fortuna.Domain.Entities
{
    public class Alerta
    {
        public int IdAlerta { get; set; }

        public int IdCliente { get; set; }

        public string Descricao { get; set; }

        public DateTime DataHora { get; set; }

        public Alerta(int idCliente, string descricao)
        {
            IdCliente = idCliente;
            Descricao = descricao;
        }
    }
}
