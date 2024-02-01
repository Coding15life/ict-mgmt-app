using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10241539_PRG2Assignment
{
    public abstract class IceCream
    {
        private string option;
        private int scoops;

        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> Flavours { get; set; } = new List<Flavour>();
        public List<Topping> Toppings { get; set; } = new List<Topping>();

        public IceCream() { }

        public IceCream(string servingOptions, int numOfScoops, List<Flavour> iceCreamFlavours, List<Topping> iceCreamToppings)
        {
            Option = servingOptions;
            Scoops = numOfScoops;
            Flavours = iceCreamFlavours;
            Toppings = iceCreamToppings;
        }

        public abstract double CalculatePrice();

        public override string ToString()
        {
            string line = "";
            line += $"Serving options: {Option}\tScoops: {Scoops}\tFlavours: \n";
            foreach (Flavour flavour in Flavours)
            {
                line += flavour.ToString() + "\n";
            }
            line += "Toppings: \n";
            foreach (Topping topping in Toppings)
            {
                line += topping.ToString() + "\n";
            }
            return line;
        }
    }
}
