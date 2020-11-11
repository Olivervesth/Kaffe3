using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeMakker
{
    interface IFill
    {
        public void FillWater(int cops);
        public void InsertNewFilter();
        public void FillIngredients(int spoon);
    }
}
