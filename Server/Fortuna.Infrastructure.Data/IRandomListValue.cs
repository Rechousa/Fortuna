using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public interface IRandomListValue
    {
        string GetRandomValue();
    }

    public interface IRandomListValue<T>
    {
        T GetRandomValue();
    }
}
