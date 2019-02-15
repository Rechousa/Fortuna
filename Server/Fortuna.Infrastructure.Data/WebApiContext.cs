using Fortuna.Domain.Entities;
using Fortuna.Infrastructure.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fortuna.Infrastructure.Data
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Historico> Historico { get; set; }
        public DbSet<Alerta> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlertasConfiguration());
            modelBuilder.ApplyConfiguration(new HistoricoConfiguration());

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        }
    }
}
