using Fortuna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data.Configuration
{
    public class AlertasConfiguration : BaseConfiguration, IEntityTypeConfiguration<Alerta>
    {
        public void Configure(EntityTypeBuilder<Alerta> builder)
        {
            builder.HasKey(n => n.IdAlerta);

            builder.Property(dm => dm.DataHora)
                .HasColumnType(DATETIME_TYPE)
                .HasDefaultValueSql(GETDATE_FUNCTION);
        }
    }
}
