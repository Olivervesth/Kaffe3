using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CoffeMakker
{
    class Menu
    {
        CoffeeMachine coffeemachine = new CoffeeMachine();
        string pickedingredient = "";
        bool customingredient = false;
        public async Task Start()
        {
            WaterContainer water = coffeemachine.WaterInCointainer();
            coffeemachine.InsertNewFilter();
            Filter filter = coffeemachine.Filter();
            while (true)
            {
                coffeemachine.InsertIngredient();
                pickedingredient = filter.ingredient.ToString();
                CheckPot();
                InputWater();
                PickIngredient();
                InputFilter();
                Console.Clear();
                DefaultScreen();
                Console.WriteLine("Waiting for Brew");
                await coffeemachine.BrewDelay();
                Console.Clear();
                DefaultScreen();
                Console.WriteLine("Brew is done!\nPress enter to brew more");
                Console.ReadKey();

            }
        }
        public void PickIngredient()
        {
            if (customingredient == false)
            {
                return;
            }
            Console.Clear();
            DefaultScreen();
            Console.WriteLine("What do you want as ingredient? I would recommend coffee");
            pickedingredient = Console.ReadLine();
            //coffeemachine.InsertIngredient("of"+pickedingredient);
        }
       
        public void CheckPot()//Check the pot is empty before brewing a new one
        {
            CoffeeFilter filter = coffeemachine.Filter();
            Pot pot = coffeemachine.Pot();
            if (pot.Usedcapacity > 0)
            {
                Console.WriteLine("Should you not drink up before making more?\n1.Drink the whole can and eat the filter and replace with new\n2.Throw out the machine and buy a new one");

                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        filter.UsedCapacity = 0;
                        filter.Used = false;
                        pot.Usedcapacity = 0;
                    }
                    else if (input == 2)
                    {
                        ClearMachine();
                    }
                    else
                    {
                        Console.Clear();
                        DefaultScreen();
                        Console.WriteLine("Input is wrong try again");
                        CheckPot();
                    }
                }
                catch (Exception)
                {

                    Console.Clear();
                    DefaultScreen();
                    Console.WriteLine("Input is wrong try again");
                    CheckPot();
                }
            }
        }
        public void ClearMachine()//Throws out 
        {
            
            WaterContainer water = coffeemachine.WaterInCointainer();
            Pot pot = coffeemachine.Pot();
            water.UsedCapacity = 0;
            pot.Usedcapacity = 0;

            coffeemachine.InsertNewFilter();
        }
        public void InputWater()//Inserts the amount of water
        {
            Console.Clear();

            DefaultScreen();
            Console.WriteLine(" how many cups do you want to make?: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
                coffeemachine.FillWater(input);
            }
            catch (Exception)
            {
                InputWater();
            }
        }
        public void InputFilter()//Gives the filter the ingredience
        {
            Console.Clear();
            DefaultScreen();
            if (pickedingredient != "")
            {
                Console.WriteLine($"how many spoons {pickedingredient} do you want to make?: ");
            }
            else
            {
                Console.WriteLine($"how many spoons do you want to fill in the filter?: ");
            }
            try
            {
                int input = int.Parse(Console.ReadLine());
                coffeemachine.FillIngredients(input);

            }
            catch (Exception)
            {

                InputFilter();
            }

        }

        public void MachineInfo()//Gives information about the machine to the user so we know whats happening :D
        {
            CoffeeFilter filter = coffeemachine.Filter();
            WaterContainer water = coffeemachine.WaterInCointainer();
            Pot pot = coffeemachine.Pot();
            Console.WriteLine($"Filter used: {filter.Used}\nFilter capacity: {filter.Capacity - filter.UsedCapacity} spoons\nFilter capacity used: {filter.UsedCapacity}");
            Console.WriteLine($"Water Container Capacity: {water.Capacity - water.UsedCapacity} cups\nWater Container Used Capacity: {water.UsedCapacity} cups");
            Console.WriteLine($"Pot Capacity: {pot.Capacity - pot.Usedcapacity} cups");
            if(filter.ingredient != null)
            Console.WriteLine($"Pot Capacity used: {pot.Usedcapacity} cups of {filter.ingredient.ToString()}");
        }
        public void DefaultScreen()//Default machine screen this is gonna be shown no matter what
        {

            Console.WriteLine("                      .");
            Console.WriteLine("                        `:.");
            Console.WriteLine("                          `:.");
            Console.WriteLine("                  .:'     ,::");
            Console.WriteLine("                 .:'      ;:'");
            Console.WriteLine("                 ::      ;:'");
            Console.WriteLine("                  :    .:'");
            Console.WriteLine("                   `.  :.");
            Console.WriteLine("          _________________________");
            Console.WriteLine("         : _ _ _ _ _ _ _ _ _ _ _ _ :");
            Console.WriteLine("     ,---:\".\".\".\".\".\".\".\".\".\".\".\".\":");
            Console.WriteLine("    : ,'\"`::.:.:.:.:.:.:.:.:.:.:.::'");
            Console.WriteLine("    `.`.  `:-===-===-===-===-===-:'");
            Console.WriteLine("      `.`-._:                   :");
            Console.WriteLine("        `-.__`.               ,'");
            Console.WriteLine("    ,--------`\"`-------------'--------.");
            Console.WriteLine("     `\"--.__                   __.--\"'");
            Console.WriteLine("            `\"\"-------------\"\"'");
            MachineInfo();
            Console.WriteLine("----------------------------------------------------------");
        }
    }

}
