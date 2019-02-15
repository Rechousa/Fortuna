using Fortuna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data.Configuration
{
    public class HistoricoConfiguration : BaseConfiguration, IEntityTypeConfiguration<Historico>
    {
        public void Configure(EntityTypeBuilder<Historico> builder)
        {
            builder.HasKey(n => n.IdHistorico);

            builder.Property(dm => dm.DataHora)
                .HasColumnType(DATETIME_TYPE)
                .HasDefaultValueSql(GETDATE_FUNCTION);
        }
    }
}
