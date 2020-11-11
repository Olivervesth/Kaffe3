using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMakker
{
    class WaterContainer
    {
        public int Capacity { get; set; }//Capacity is counted in how many cops you can make out of the amount of water
        public int UsedCapacity { get; set; }
        public WaterContainer()
        {
            UsedCapacity = 0;
           Capacity = 10;
        }

    }
}
