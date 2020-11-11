using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeMakker
{
    class CoffeeMachine : Machine, IFill, IBrew
    {
        /*
        -----------------------------
        This class is the machine
        its connecting all the dots 
        and provide other services
        with the information
        -----------------------------
         */
        WaterContainer water = new WaterContainer();//we are just getting the information from the different components of the machine here
        Funnel funnel = new Funnel();
        Pot pot = new Pot();
        public async Task BrewDelay()//This is simulating the wait time of a coffemachine brewing
        {

            int delay = 10000;
            await Task.Delay(delay);
            Brew();
        }
        public void Brew()// Here we are simulating the brew
        {
            pot.Usedcapacity = water.UsedCapacity;
            water.UsedCapacity = 0;
            funnel.Filter.Used = true;
        }
        public void FillWater(int cups)//Here we check if there is to much water if not we are good to go
        {
            if (cups + water.UsedCapacity <= water.Capacity)
            {
                water.UsedCapacity = cups;
            }
            else
            {
                throw new Exception("To much water");
            }
        }
        public void FillIngredients(int spoon)// Here it checks if the amount of spoons is to much if its not its good to go
        {
            CoffeeFilter filter = (CoffeeFilter)funnel.Filter;
            if (spoon + filter.UsedCapacity <= filter.Capacity)
            {
                filter.UsedCapacity = spoon;
            }
            else
            {
                throw new Exception("To much coffee");
            }

        }
        public void InsertNewFilter()// "Changing the filter" a nice way to simulate it i think myself
        {
            funnel.Filter = new CoffeeFilter();

        }

        public WaterContainer WaterInCointainer()//Returning the watercontainer information
        {
            return water;
        }

        public CoffeeFilter Filter()// This is returning the filter so we can get some information about it
        {
            return (CoffeeFilter)funnel.Filter;
        }
        public Pot Pot()
        {
            return pot;
        }
        public void InsertIngredient()//Ive have set the Ingredient to be coffe probably not the optimal way of doing it but im learning. grindcoffe is showing what the type is and how to brew it in methods 
        {

            CoffeeFilter filter = (CoffeeFilter)funnel.Filter;
            filter.ingredient = new Espresso();//Change ingredient here
        }
    }
}
