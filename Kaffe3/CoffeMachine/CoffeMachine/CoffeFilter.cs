using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMakker
{
    class CoffeeFilter : Filter
    {
        public double Capacity { get; set; }
        public override bool Used { get; set; }
        public double UsedCapacity { get; set; }
        public CoffeeFilter()
        {
            Used = false;
            Capacity = 10;
            UsedCapacity = 0;
        }
    }
}
