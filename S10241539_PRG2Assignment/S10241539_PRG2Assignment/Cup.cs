using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================================
// Student Number : S10241539
// Student Name : Javier Lim
// Partner Name : Keshav P Chidambaram
// Partner Number : S10257135
//==========================================================

namespace S10241539_PRG2Assignment
{
    //defining Cup as a subclass of IceCream
    class Cup : IceCream
    {
        //Constructor
        public Cup() { }
        public Cup(string option, int scoops, List<Flavour> flavours, List<Topping> toppings) : base(option, scoops, flavours, toppings) { }

        //Since Cup is a subclass of IceCream.cs, override needs to be used to call CalculatePrice()
        public override double CalculatePrice()
        {
            //Initializes the variable, price which will be returned later as the total price of the ice cream
            double price = 0;

            //Price added by scoops
            //Determines price by using the number of scoops
            if (Scoops == 1)
            {
                price = 4;
            }
            else if (Scoops == 2)
            {
                price = 5.50;
            }
            else
            {
                price = 6.50;
            }

            //Price added by toppings
            //Addition of price based on the number of toppings added
            if (Toppings.Count > 0)
            {
                price += 1 * Toppings.Count;
            }

            //Price added by premium flavours
            //Checks for premium flavours in the ice cream 
            foreach (Flavour flavour in Flavours)
            {
                if (flavour.Premium == true)
                {
                    price += 2;
                }
            }

            //returning a int object, price that contains the value of the total price of the ice cream
            return price;
        }

        //Initializing a to string statement that contains all the information on a specific ice cream
        //and allows for easier output printing in other lines of code
        public override string ToString()
        {

            string l = $"Serving Option: {Option}\nScoops: {Scoops}\n";
            l += ("Flavours:\n");
            //A foreach loop to get every flavour in the Flavours list (aka flavours in the ice cream)
            foreach (Flavour f in Flavours)
            {
                l += (f.ToString() + "\n");
            }
            l += ("Toppings:\n");
            //A foreach loop to get every topping in the Toppings list (aka toppings in the ice cream)
            foreach (Topping t in Toppings)
            {
                l += (t.ToString() + "\n");
            }
            //returning a long string containing multiple lines giving all the details of the Cup object
            return l;
        }
    }
}

