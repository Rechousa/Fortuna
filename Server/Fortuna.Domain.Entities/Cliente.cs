using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fortuna.Domain.Entities
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        public string Morada { get; set; }

        public string Cidade { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefone { get; set; }

        public string NumeroContribuinte { get; set; }

        public string Convencao { get; set; }

        public DateTime DataHora { get; set; }

        public ICollection<Alerta> Alertas { get; set; }

        public ICollection<Historico> Historico { get; set; }

        public Cliente(string nome, string morada, string cidade, string codigoPostal, string telefone, string numeroContribuinte, string convencao)
        {
            Nome = nome;
            Morada = morada;
            Cidade = cidade;
            CodigoPostal = codigoPostal;
            Telefone = telefone;
            NumeroContribuinte = numeroContribuinte;
            Convencao = convencao;
        }
    }
}
