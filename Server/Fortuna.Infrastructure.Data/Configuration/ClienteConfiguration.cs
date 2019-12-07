using Fortuna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fortuna.Infrastructure.Data.Configuration
{
    public class ClienteConfiguration : BaseConfiguration, IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(n => n.IdCliente);

            builder.HasMany(b => b.Alertas).WithOne();
            builder.HasMany(b => b.Historico).WithOne();

            builder.Property(n => n.Nome).IsRequired().HasMaxLength(200);
            builder.Property(n => n.Morada).HasMaxLength(200);
            builder.Property(n => n.Cidade).HasMaxLength(200);
            builder.Property(n => n.CodigoPostal).HasMaxLength(50);
            builder.Property(n => n.Telefone).IsRequired().HasMaxLength(50);
            builder.Property(n => n.NumeroUtente).HasMaxLength(50);
            builder.Property(n => n.NumeroContribuinte).IsRequired().HasMaxLength(50);
            builder.Property(n => n.Email).HasMaxLength(100);
            builder.Property(n => n.NomeConvencao).HasMaxLength(200);
            builder.Property(n => n.NumeroConvencao).HasMaxLength(200);

            builder.Property(dm => dm.DataHora)
                .HasColumnType(DATETIME_TYPE)
                .HasDefaultValueSql(GETDATE_FUNCTION);
        }
    }
}
