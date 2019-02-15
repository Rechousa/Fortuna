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

                for (int i = 0; i < 50; i++)
                {
                    context.Clientes.Add(new Cliente($"{listaNomesProprios.GetRandomValue()} {listaNomesFamilia.GetRandomValue()}", "Rua da minha casa", "Morada", "4000-001", "919009090", "512345678", listaConvencoes.GetRandomValue()));
                }
                //context.Clientes.Add(new Cliente("João", "Rua da minha casa", "Morada", "4000-001", "969009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("António", "Rua da minha casa", "Morada", "4000-001", "939009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Filipe", "Rua da minha casa", "Morada", "4000-001", "229009090", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Maria", "Rua da minha casa", "Morada", "4000-001", "216781231", "512345678", "Médis"));
                //context.Clientes.Add(new Cliente("Catarina", "Rua da minha casa", "Morada", "4000-001", "+351 234567890", "512345678", "Médis"));
                context.SaveChanges();
            }
        }

        private static string NomeFamiliaRandom()
        {
            var nomes = "Assunção,Azevedo,Borges,Carvalho,Castro,Costa,Ferreira,Gomes,Henriques,Martins,Matos,Pereira,Proença,Ramos,Sequeira,Silva".Split(',');
            return nomes.ToList().PickRandom();
        }
    }
}
