using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public abstract class RandomListValue<T> : IRandomListValue<T>
    {
        protected List<T> names = new List<T>();

        public virtual T GetRandomValue()
        {
            return names.PickRandom();
        }
    }
}
