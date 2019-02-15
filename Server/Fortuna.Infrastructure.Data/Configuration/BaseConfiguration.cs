using Fortuna.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data.Configuration
{
    public abstract class BaseConfiguration
    {
        internal const string DATETIME_TYPE = "DATETIME";
        internal const string GETDATE_FUNCTION = "GETDATE()";
    }
}
