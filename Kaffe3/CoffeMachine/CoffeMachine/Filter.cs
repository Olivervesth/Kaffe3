using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMakker
{
    abstract class Filter
    {
        public abstract bool Used { get; set; }
        public Ingredient ingredient { get; set; }
    }
}
