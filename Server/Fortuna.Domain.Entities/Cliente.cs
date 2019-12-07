using System;
using System.Collections.Generic;

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

        public string NumeroUtente { get; set; }

        public string NumeroContribuinte { get; set; }

        public string Email { get; set; }

        public string NomeConvencao { get; set; }

        public string NumeroConvencao { get; set; }

        public DateTime DataHora { get; set; }

        public ICollection<Alerta> Alertas { get; set; }

        public ICollection<Historico> Historico { get; set; }

        public Cliente(string nome, string morada, string cidade, string codigoPostal, string telefone, string numeroUtente, string numeroContribuinte, string email, string nomeConvencao, string numeroConvencao)
        {
            Nome = nome;
            Morada = morada;
            Cidade = cidade;
            CodigoPostal = codigoPostal;
            Telefone = telefone;
            NumeroUtente = numeroUtente;
            NumeroContribuinte = numeroContribuinte;
            Email = email;
            NomeConvencao = nomeConvencao;
            NumeroConvencao = numeroConvencao;
        }
    }
}
