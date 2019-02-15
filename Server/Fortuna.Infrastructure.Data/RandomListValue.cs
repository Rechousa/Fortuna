using System;
using System.Collections.Generic;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public abstract class RandomListValue
    {
        protected List<string> names = new List<string>();

        public string GetRandomValue()
        {
            return names.PickRandom();
        }
    }
}
