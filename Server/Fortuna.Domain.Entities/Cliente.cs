using System;

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

        public Cliente(int idCliente, string nome, string morada, string cidade, string codigoPostal, string telefone, string numeroContribuinte, string convencao)
        {
            IdCliente = idCliente;
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
