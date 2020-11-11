using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMakker
{
    class Pot
    {
        public int Capacity { get; set; }
        public int Usedcapacity { get; set; }

        public Pot()
        {
            Capacity = 10;
            Usedcapacity = 0;
        }
    }
}
