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
        private List<Flavour> flavours;
        private List<Topping> toppings;

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
            return $"Serving options: {Option}\tScoops: {Scoops}\tFlavours: {Flavours}\tToppings: {Toppings}";
        }
    }
}
