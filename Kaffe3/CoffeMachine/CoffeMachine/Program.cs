using System;
using System.Threading.Tasks;

namespace CoffeMakker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ThreadStart();
        }
        public static async Task ThreadStart()
        {
            Menu menu = new Menu();
            await menu.Start();
        }
    }
}
