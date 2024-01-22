using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10241539_PRG2Assignment
{
    class Cup : IceCream
    {
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }
        public override double CalculatePrice()
        {
            double price = 0;
            if (Scoops == 1)
            {
                price = 4;
            }else if (Scoops == 2)
            {
                price = 5.50;
            }else
            {
                price = 6.50;
            }
            if (Scoops > 0)
            {
                price += 1 * Scoops;
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
