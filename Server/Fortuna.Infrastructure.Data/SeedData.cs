using Fortuna.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public static class SeedData
    {
        private const int NUMERO_CLIENTES = 50;
        private const int NUMERO_ALERTAS_POR_CLIENTE = 3;
        private const int NUMERO_HISTORICO_POR_CLIENTE = 25;

        private readonly static Random random = new Random();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<WebApiContext>();
            context.Database.EnsureCreated();
            if (!context.Clientes.Any())
            {
                var listaNomesProprios = new RandomListValuePersonName();
                var listaNomesFamilia = new RandomListValuePersonSurname();
                var listaConvencoes = new RandomListValuePersonConvencao();
                var listaMorada = new RandomListValuePersonAddress();
                var listaCidade = new RandomListValuePersonCity();
                var listaComentario = new RandomListValueComment();

                for (int i = 0; i < NUMERO_CLIENTES; i++)
                {
                    var nome = $"{listaNomesProprios.GetRandomValue()} {listaNomesFamilia.GetRandomValue()}";
                    var morada = listaMorada.GetRandomValue(new IRandomListValue<string>[] { listaNomesProprios, listaNomesFamilia });
                    var cidade = $"{listaCidade.GetRandomValue()}";

                    var cliente = new Cliente(nome, morada, cidade, "4000-001", "919009090", "512345678", listaConvencoes.GetRandomValue());

                    context.Clientes.Add(cliente);

                    for (int j = 0; j < NUMERO_ALERTAS_POR_CLIENTE; j++)
                    {
                        var comentario = listaComentario.GetRandomValue();

                        var alerta = new Alerta(cliente.IdCliente, comentario);
                        context.Alertas.Add(alerta);
                    }

                    for (int j = 0; j < NUMERO_HISTORICO_POR_CLIENTE; j++)
                    {
                        var comentario = listaComentario.GetRandomValue();

                        var historico = new Historico(cliente.IdCliente, comentario);
                        context.Historico.Add(historico);
                    }
                    context.SaveChanges();
                }
                //context.Clientes.Add(new Cliente("João", "Rua da minha casa", "Morada", "4000-001", "969009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("António", "Rua da minha casa", "Morada", "4000-001", "939009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Filipe", "Rua da minha casa", "Morada", "4000-001", "229009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Maria", "Rua da minha casa", "Morada", "4000-001", "216781231", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Catarina", "Rua da minha casa", "Morada", "4000-001", "+351 234567890", "512345678", "Médis"));
            }
        }

        private static string NomeFamiliaRandom()
        {
            var nomes = "Assunção,Azevedo,Borges,Carvalho,Castro,Costa,Ferreira,Gomes,Henriques,Martins,Matos,Pereira,Proença,Ramos,Sequeira,Silva".Split(',');
            return nomes.ToList().PickRandom();
        }
    }
}
